using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBugScript : MonoBehaviour
{

    public int myType;
    public bool start = false;

    public SpriteRenderer sR;
    public BugSpawnerScript bSS;

    public Material matGreen;
    public Material matYellow;
    public Material matRed;
    Material[] matArray = new Material[3];

    public List<Vector3> positions = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void UpdateColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = matArray[myType].color;
    }
    */

    public void NextPos(int num)
    {
        gameObject.transform.position = positions[num];
    }


    private void OnMouseDown()
    {
        bSS.BugPressed(gameObject, myType);
        //Destroy(this.gameObject);
    }
}
