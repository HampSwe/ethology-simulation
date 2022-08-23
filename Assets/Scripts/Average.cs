using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Average : MonoBehaviour
{
    // Start is called before the first frame update

    public Text myText;

    void Start()
    {
        string str = "DATA\n";

        string currentStr = "";

        int[,] dataGens = new int[PlayerPrefs.GetInt("game.0.generations"), GameDataScript.matArray.Length];

        for (int i = 0; i < PlayerPrefs.GetInt("gameNum") + 1; i++)
        {
            for (int j = 0; j < PlayerPrefs.GetInt("game." + i.ToString() + ".generations"); j++)
            {
                //dataGens = [j, ]
            }
        }



        for (int i = 0; i < GameDataScript.gamePassData.GetLongLength(0); i++)
        {
            str += "Gen: " + i + ", " + GameDataScript.colorNameArray[0] + ": " + GameDataScript.gamePassData[i, 0] + ", " + GameDataScript.colorNameArray[1] + ": " + GameDataScript.gamePassData[i, 1] + "\n";
        }

        myText.text = str;
    }


}
