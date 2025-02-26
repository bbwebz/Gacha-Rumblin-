using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    Vector2 moveDirection;
    Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Move.performed += OnMove;
        controls.Gameplay.Jump.performed += OnJump;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector2(moveInput.x, 0f);
        Debug.Log(moveDirection);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("you pressed jump");
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(moveDirection * moveSpeed);
        rb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
        //rb.AddForce(Vector2.left * moveSpeed * Time.deltaTime);

    }
}
