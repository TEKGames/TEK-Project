using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{

}

public enum ItemType
{

}

public class InventoryManager : MonoBehaviour {

    List<InventoryItem> inventory = new List<InventoryItem>();
    private bool inventoryEnabled;

    private static InventoryManager controller;

    private void Start()
    {
        if (!controller)
        {
            controller = this;
            if (Application.UseDebug)
                Debug.Log("InventoryManager: controller set.");
        }
        else
        {
            if (Application.UseDebug)
                Debug.Log("Warning: InventoryManager controller is already set (Destroying duplicate).");
            Destroy(gameObject);
        }
    }

    public static void EnableInventory()
    {
        controller.inventoryEnabled = !controller.inventoryEnabled;
        UI.SetInventoryMenu(controller.inventoryEnabled);
        UI.SetCursor(controller.inventoryEnabled, !controller.inventoryEnabled);
    }

    public static bool InventoryEnabled
    {
        get
        {
            return controller.inventoryEnabled;
        }
    }
}
