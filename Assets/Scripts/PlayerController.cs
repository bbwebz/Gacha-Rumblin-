using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    public Player1Health Player1HealthAccess;
    public Player2Health Player2HealthAccess;


    Vector2 moveDirection;
    Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    private float horizontal;

    public bool didAttack = false;
    bool isFacingLeft = false;
    public bool arePlayersColliding = false;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    void Start()
    {
        controls.Gameplay.Enable();

        rb = GetComponent<Rigidbody2D>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        if (moveDirection.x < 0)
        {
            isFacingLeft = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            isFacingLeft = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector2(moveInput.x, 0f);
        horizontal = context.ReadValue<Vector2>().x;
        //Debug.Log(moveDirection);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        Debug.Log("you pressed jump");
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("you pressed attack");
        if (arePlayersColliding == true && context.performed) 
        {
            didAttack = true;
            Debug.Log("you landed an attack");
            
            if (gameObject.CompareTag("Player1"))
            {
                Player1HealthAccess.dealDamageToP2();
            }
            else if (gameObject.CompareTag("Player2"))
            {
                Player2HealthAccess.dealDamageToP1();
            }
        }
        else
        {
            didAttack = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        //avoids sliding
        if (horizontal < 0.1f && horizontal > -0.1f)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player1")) //checks the tag of the object its colliding with
        {
            //Debug.Log("players are colliding");
            arePlayersColliding = true;
        }
        else
        {
            arePlayersColliding = false;
        }
    }

}