using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDiagramAxisScript : MonoBehaviour
{
    public LineRenderer lR;
    public GameObject lG;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = lG.transform.localPosition;

        Vector3 tmp = new Vector3(0, lG.GetComponent<LineGeneratorScript>().height, -2);

        lR.SetPosition(0, tmp);

        tmp.Set(0, 0, -2);

        lR.SetPosition(1, tmp);

        tmp.Set(lG.GetComponent<LineGeneratorScript>().width, 0, -2);

        lR.SetPosition(2, tmp);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
