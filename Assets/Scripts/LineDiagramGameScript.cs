using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDiagramGameScript : MonoBehaviour
{

    public int width;
    public int height;

    public LineRenderer lR;

    public int type;

    // Start is called before the first frame update
    void Start()
    {
        long generations = GameDataScript.gamePassData.GetLongLength(0);

        float yPerBug = (float)height / (float)GameDataScript.startBugs;
        float xPerGen = (float)width / (generations - 1);

        //Vector3[] positions = new Vector3[generations - 1];

        Vector3 tmp = new Vector3();

        for (int i = 0; i < generations; i++)
        {
            tmp.Set(i * xPerGen, GameDataScript.gamePassData[i, type] * yPerBug, -1);
            lR.SetPosition(i, tmp);
        }

        lR.material.color = GameDataScript.matArray[type].color;




    }

}
