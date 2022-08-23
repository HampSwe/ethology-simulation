using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenePanelScript : MonoBehaviour
{

    public void NextScene1()
    {
        Debug.Log("dawd");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
