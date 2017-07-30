using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool invertCamera;

    public float xSensitivity = 1;
    public float ySensitivity = 1;

    private float xRot;
    private float yRot;

    public LayerMask focusMask;
    public float focusDistance = 1000;
    public GameObject focusObject;

	private void Update () {
        UpdateCameraTransform();
        GetFocusObject();
	}

    private void Start()
    {
        UI.SetCursor(false, true);
    }

    private void UpdateCameraTransform()
    {
        transform.position = GameManager.player.transform.position + new Vector3(0, 0.8f, 0);

        xRot += Input.GetAxis("Mouse X") * xSensitivity;
        yRot += invertCamera? Input.GetAxis("Mouse Y") * ySensitivity : -Input.GetAxis("Mouse Y") * ySensitivity;

        yRot = Mathf.Clamp(yRot, -90, 90);

        transform.rotation = Quaternion.Euler(yRot, xRot, 0);
    }

    public void GetFocusObject()
    {
        RaycastHit focusHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out focusHit, focusDistance, focusMask))
        {
            focusObject = focusHit.transform.gameObject;

            UseableItem focusItem = focusObject.GetComponent<UseableItem>();
            switch (focusItem != null)
            {
                case true:
                    UI.UpdateActionText(focusItem);
                    UI.SetActionText(true);
                    break;

                case false:
                    UI.SetActionText(false);
                    break;
            }
        }
        else
        {
            UI.SetActionText(false);
        }
    }
}