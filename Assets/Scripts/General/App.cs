using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour {

    public int sceneToLoad;
    public bool devDebug;

    private static App activeApplication;

    private void Awake()
    {
        if (!activeApplication)
        {
            activeApplication = this;
            if (devDebug)
                Debug.Log("Application: activeApplication set.");
        }
        else
        {
            if (devDebug)
                Debug.Log("Warning: activeApplication already set. (destroying duplicate)");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(loadDefaultScene ? 1 : sceneToLoad);
        }
    }

    private bool loadDefaultScene
    {
        get
        {
            if (sceneToLoad == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static bool UseDebug
    {
        get
        {
            return activeApplication.devDebug;
        }
    }
}