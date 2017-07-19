using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Menu
{
    public GameObject menuGroup;
}

[System.Serializable]
public class ScaleableRect
{
    public string name;
    public RectTransform transform;
    public bool scaleWidthToScreen;
    public bool scaleHeightToScreen;
    public Vector2 sizeOffset;
}

public class UI : MonoBehaviour {

    public static UI controller;

    public Menu inventory;
    public List<ScaleableRect> scaleableObjects;

    private void Start()
    {
        if (!controller)
        {
            controller = this;
            if (Application.UseDebug)
                Debug.Log("UI: set controller.");
        }
        else
        {
            if (Application.UseDebug)
                Debug.Log("Warning: UI controller already set (Destroying duplicate).");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        UpdateScaleableObjects();
    }

    private void UpdateScaleableObjects()
    {
        foreach (ScaleableRect scaleableRect in scaleableObjects)
        {
            if (scaleableRect.scaleWidthToScreen)
            {
                scaleableRect.transform.sizeDelta = new Vector2(Screen.width, scaleableRect.transform.sizeDelta.y);
            }

            if (scaleableRect.scaleHeightToScreen)
            {
                scaleableRect.transform.sizeDelta = new Vector2(scaleableRect.transform.sizeDelta.x, Screen.height);
            }

            if (scaleableRect.sizeOffset != Vector2.zero)
            {
                scaleableRect.transform.sizeDelta = new Vector2(scaleableRect.transform.sizeDelta.x + scaleableRect.sizeOffset.x, scaleableRect.transform.sizeDelta.y + scaleableRect.sizeOffset.y);
            }
        }
    }

    public static void SetInventoryMenu(bool state)
    {
        controller.inventory.menuGroup.SetActive(state);
        controller.inventory.menuGroup.GetComponent<Animator>().SetBool("isInventoryOpen", state);
    }

    public static void SetCursor(bool visible, bool locked)
    {
        Cursor.visible = visible;
        switch (locked)
        {
            case true:
                Cursor.lockState = CursorLockMode.Locked;
                break;

            case false:
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
}