using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResultTextScript : MonoBehaviour
{

    public Text myText;


    public void SaveGame()
    {
        string gameNumKey = "gameNum";
        int gameNum;

        if (PlayerPrefs.HasKey(gameNumKey))
        {
            gameNum = PlayerPrefs.GetInt(gameNumKey) + 1;
        }
        else
        {
            gameNum = 0;
        }

        PlayerPrefs.SetInt("game." + gameNum.ToString() + ".generations", (int)GameDataScript.gamePassData.GetLongLength(0));


        for (int i = 0; i < GameDataScript.gamePassData.GetLongLength(0); i++)
        {
            PlayerPrefs.SetInt("game." + gameNum + ".gen." + i.ToString() + GameDataScript.colorNameArray[0], GameDataScript.gamePassData[i, 0]);
            PlayerPrefs.SetInt("game." + gameNum + ".gen." + i.ToString() + GameDataScript.colorNameArray[1], GameDataScript.gamePassData[i, 1]);
        }

        PlayerPrefs.Save();
    }





    // Start is called before the first frame update
    void Start()
    {
        string str = "";


        for (int i = 0; i < GameDataScript.matArray.Length; i++)
        {
            float h = ((float)GameDataScript.gamePassData[GameDataScript.gamePassData.GetLongLength(0) - 1, i]);
            float p = (float)GameDataScript.startBugs;
            float k = h / p;
            float j = Mathf.Round(k);
            string t = j.ToString();

            Debug.Log(h);
            Debug.Log(p);
            Debug.Log(k);
            Debug.Log(j);
            Debug.Log(t);



            str += "<color=#" + ColorUtility.ToHtmlStringRGB(GameDataScript.matArray[i].color) + ">" + GameDataScript.colorNameArray[i] + ":</color> " + GameDataScript.gamePassData[GameDataScript.gamePassData.GetLongLength(0) - 1, i].ToString() + " - " + (Mathf.Round(((float)GameDataScript.gamePassData[GameDataScript.gamePassData.GetLongLength(0) - 1, i]) * 100 / ((float)GameDataScript.startBugs))).ToString() + "%\n";
        }


        myText.text = str;

    }



}
