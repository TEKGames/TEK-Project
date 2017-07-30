using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private CharacterController controller;

    public float movementSpeed;
    public float jumpForce;
    public bool isJumping;

    private float verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        if (!GameManager.player)
        {
            GameManager.player = this;
            if (App.UseDebug)
                Debug.Log("PlayerController: Initialized and set.");
        }
        else
        {
            if (App.UseDebug)
                Debug.Log("Warning: Player is already set (Destroying duplicate).");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Movement();
        PlayerInput();
    }

    private void Movement()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, Camera.main.transform.eulerAngles.y, 0));

        if (controller.isGrounded)
        {
            verticalVelocity = -GameManager.activeManager.gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= GameManager.activeManager.gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, verticalVelocity, Input.GetAxis("Vertical") * movementSpeed);
        moveVector = transform.TransformDirection(moveVector);
        controller.Move(moveVector * Time.deltaTime);
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryManager.EnableInventory();
        }
    }
}
