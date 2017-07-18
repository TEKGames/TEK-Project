using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager activeManager;

    private void Awake()
    {
        if (!activeManager)
        {
            activeManager = this;
            if (Application.UseDebug)
                Debug.Log("GameManager: activeManager set.");
        }
        else
        {
            if (Application.UseDebug)
                Debug.Log("Warning: activeManager already set. (destroying duplicate)");
            Destroy(gameObject);
        }
    }
}