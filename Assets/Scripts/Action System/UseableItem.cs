using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    Pickup
}

public class UseableItem : MonoBehaviour {
    public string itemName;
    public ActionType actionType;

    private void Start()
    {
    }

    public string ActionString()
    {
        switch(actionType)
        {
            case ActionType.Pickup:
                return "Press E to pick up " + itemName + ".";

            default:
                return "Warning: ActionString() Failed.";
        }
    }
}