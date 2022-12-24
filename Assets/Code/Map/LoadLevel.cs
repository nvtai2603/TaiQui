using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int iLevelToLoad;
    public string iLevelName; 

    public bool useIntegerToLoadLevel = false;

    private void Start()
    {
         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject= collision.gameObject;

        if (collisionGameObject.name == "Paul")
        {
            LoadScene();
        }
    }
    void LoadScene()
    {
        if (useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(iLevelName); 
        }
    }
}
