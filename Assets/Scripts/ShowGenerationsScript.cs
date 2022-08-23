using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGenerationsScript : MonoBehaviour
{

    public Text myText;

    // Start is called before the first frame update
    void Start()
    {
        string str = "DATA\n";


        for (int i = 0; i < GameDataScript.gamePassData.GetLongLength(0); i++)
        {
            str += "Gen: " + i + ", " + GameDataScript.colorNameArray[0] + ": " + GameDataScript.gamePassData[i, 0] + ", " + GameDataScript.colorNameArray[1] + ": " + GameDataScript.gamePassData[i, 1] + "\n";
        }

        myText.text = str;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
