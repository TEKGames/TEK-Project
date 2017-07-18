using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour {

    private void Awake()
    {
        if (!GameObject.Find("__app"))
        {
            SceneManager.LoadScene("_preload");
        }
    }
}