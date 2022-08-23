using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGeneratorScript : MonoBehaviour
{

    public GameObject originalLine;

    public int height;
    public int width;

    public Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform.localPosition = new Vector3(myTransform.localPosition.x - width / 2, myTransform.localPosition.y, myTransform.localPosition.z);


        for (int i = 0; i < GameDataScript.matArray.Length; i++)
        {
            GameObject line = Instantiate(originalLine);
            LineRenderer lR = line.GetComponent<LineRenderer>();

            line.transform.SetParent(gameObject.transform, false);
            line.SetActive(true);

            //line.transform.position = new Vector3(line.transform.position.x - width / 2, line.transform.position.y, line.transform.position.z);

    

            long generations = GameDataScript.gamePassData.GetLongLength(0);
            float yPerBug = (float)height / (float)GameDataScript.startBugs;
            float xPerGen = (float)width / (generations - 1);
            lR.positionCount = (int)generations;

            Vector3 tmp = new Vector3();



            for (int j = 0; j < generations; j++)
            {
                tmp.Set(j * xPerGen, GameDataScript.gamePassData[j, i] * yPerBug, -1);
                lR.SetPosition(j, tmp);
            }

            lR.material.color = GameDataScript.matArray[i].color;
        }



    }

}
