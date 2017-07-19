using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    private CharacterController controller;

    public float jumpForce;
    public bool isJumping;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        if (!GameManager.player)
        {
            GameManager.player = this;
            if (Application.UseDebug)
                Debug.Log("PlayerController: Initialized and set.");
        }
        else
        {
            if (Application.UseDebug)
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

        Vector3 moveDirection = Vector3.zero;

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed;

        if (controller.isGrounded) {
            isJumping = false;
            if (Input.GetButton("Jump"))
                isJumping = true;
        }

        if (isJumping)
        {
        }

        moveDirection.y -= GameManager.activeManager.gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryManager.EnableInventory();
        }
    }
}
