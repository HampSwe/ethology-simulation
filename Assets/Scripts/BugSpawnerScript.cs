using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BugSpawnerScript : MonoBehaviour
{

    public bool shuffle;
    public int fertility;
    public int generations;
    public int numberOfEach; //måste vara ett jämnt tal

    int bugsToEatPerRound;
    int bugsEaten;
    int generation;

    public GameObject bug;
    public GameObject panel;

    public Material[] matArray;
    public string[] colorNameArray;

    public List<GameObject> instanceList = new List<GameObject>();
    public int[] bugArray;

    int[,] gameData;

    bool destroying;
    bool stop;


    //Start is called before the first frame update
    void Start()
    {
        destroying = false;
        stop = false;

        // only the first time
        bugsToEatPerRound = (numberOfEach * matArray.Length) - (numberOfEach * matArray.Length) / fertility;
        bugsEaten = 0;
        generation = 0;

        GameDataScript.startBugs = matArray.Length * numberOfEach;


        bugArray = new int[matArray.Length];

        gameData = new int[generations + 1, bugArray.Length];


        for (int i = 0; i < matArray.Length; i++)
        {
            bugArray[i] = numberOfEach;
            gameData[generation, i] = numberOfEach;
        }


        /*
        matArray[0] = matGreen;
        matArray[1] = matYellow;
        matArray[2] = matRed;
        */

        //0 = green
        //1 = yellow
        //2 = red

        for (int j = 0; j < matArray.Length; j++)
        {
            for (int i = 0; i < bugArray[j]; i++)
            {
                SpawnBug(j);
            }

        }

    }


    void NextGeneration()
    {

        generation++;
        bugsEaten = 0;

        for (int i = 0; i < instanceList.Count; i++)
        {
            Destroy(instanceList[i]);

        }

        instanceList.Clear();


        for (int j = 0; j < matArray.Length; j++)
        {
            for (int i = 0; i < bugArray[j]; i++)
            {
                SpawnBug(j);
            }
        }
    }


    public void SpawnBug(int type)
    {
        //calculates half the screens height and width in units
        float height = Camera.main.orthographicSize;
        float width = ((float)Screen.width / (float)Screen.height) * height;

        float xOffset = (((Camera.main.orthographicSize * 2) / Screen.height) * (bug.transform.localScale.x / 2f));
        float yOffset = (((Camera.main.orthographicSize * 2) / Screen.height) * (bug.transform.localScale.y / 2f));

        /*
        Debug.Log(xOffset);
        Debug.Log(Screen.height);
        Debug.Log(bug.transform.localScale.x);
        Debug.Log(Camera.main.orthographicSize);
        Debug.Log(posY);
        */




        if (shuffle)
        {
            GameObject instance = Instantiate(bug);
            instanceList.Add(instance);

            VirtualBugScript vBS = instance.GetComponent<VirtualBugScript>();

            Vector3 tmpPos = new Vector3();

            for (int i = 0; i < bugsToEatPerRound; i++)
            {
                float posY = Random.Range(-height + yOffset, height - yOffset);
                float posX = Random.Range(-width + xOffset, width - xOffset);

                tmpPos.Set(posX, posY, 0);

                vBS.positions.Add(tmpPos);
            }

            vBS.myType = type;
            instance.GetComponent<SpriteRenderer>().color = matArray[type].color;

            vBS.NextPos(0);
        }
        else
        {
            float posY = Random.Range(-height + yOffset, height - yOffset);
            float posX = Random.Range(-width + xOffset, width - xOffset);
            Vector3 tmp = new Vector3(posX, posY, 0);

            GameObject instance = Instantiate(bug, tmp, Quaternion.identity);
            instanceList.Add(instance);

            instance.GetComponent<VirtualBugScript>().myType = type;
            instance.GetComponent<SpriteRenderer>().color = matArray[type].color;
        }


        /*
        float posY = Random.Range(-height + yOffset, height - yOffset);
        float posX = Random.Range(-width + xOffset, width - xOffset);
        Vector3 tmp = new Vector3(posX, posY, 0);

        GameObject instance = Instantiate(bug, tmp, Quaternion.identity);
        instanceList.Add(instance);
        */




    }

    public void BugPressed(GameObject gO, int type)
    {
        if (!destroying & !stop)
        {
            destroying = true;

            bugArray[type] -= 1;
            bugsEaten++;

            instanceList.Remove(gO);

            Destroy(gO);

            if (bugsEaten >= bugsToEatPerRound)
            {
                for (int i = 0; i < bugArray.Length; i++)
                {
                    bugArray[i] *= fertility;
                    gameData[generation + 1, i] = bugArray[i];
                }

                if (generation < generations - 1)
                {
                    NextGeneration();
                }
                else
                {
                    stop = true;
                    GameDataScript.PassSceneData(gameData, matArray, colorNameArray);
                    panel.SetActive(true);
                    Debug.Log("here");
                }

            }
            else if (shuffle)
            {
                //shuffle
                foreach (GameObject item in instanceList)
                {
                    item.GetComponent<VirtualBugScript>().NextPos(bugsEaten);
                }
            }

            destroying = false;

        }

    }

}


/*
public class BugType
{
    int type;
    int count;

    public BugType(int inType, int inCount)
    {
        type = inType;
        count = inCount;
    }

}
*/
