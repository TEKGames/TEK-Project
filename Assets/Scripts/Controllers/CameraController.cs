using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool invertCamera;

    public float xSensitivity = 1;
    public float ySensitivity = 1;

    private float xRot;
    private float yRot;

	private void FixedUpdate () {
        UpdateCameraTransform();
	}

    private void Start()
    {
        Application.SetCursor(true, true);
    }

    private void UpdateCameraTransform()
    {
        xRot += Input.GetAxis("Mouse X");
        yRot += invertCamera? Input.GetAxis("Mouse Y") : -Input.GetAxis("Mouse Y"); 

        transform.rotation = Quaternion.Euler(yRot, xRot, 0);
    }
}