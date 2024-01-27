using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       
    }

    public void ChangeScene(int index)
    {

        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in gameObjects)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene(index);
    }

    public void exitgame()
    {
        
        Application.Quit();
    }

}
