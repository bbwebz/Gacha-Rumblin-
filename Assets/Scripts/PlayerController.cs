using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Rendering;

//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

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

    //for animation//
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public Sprite idlePose;
    public Sprite jumpPose;
    public Sprite punchPose;

    public int PlayerIndex;

    public int DamageDone;

    GameObject Player1;
    GameObject Player2;

    public GameObject P1InventoryCanvas;
    public GameObject P2InventoryCanvas;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    void Start()
    {
        controls.Gameplay.Enable();

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.freezeRotation = true;

        DamageDone = 1;//can do 1 damage on default
        //--------------- Player multiplayer -------------------

        PlayerIndex = GetComponent<PlayerInput>().playerIndex;//get player index

        //Set Player Tags    
        if (PlayerIndex == 0) {
            gameObject.tag = "Player1";//give the first player to enter the player 1 tag

             gameObject.AddComponent<Player1Health>();//Add player 1 health script to player 1

            transform.position = new Vector3(-6, 0, 0);//player 1 starting position

            P2InventoryCanvas.gameObject.SetActive(false);


        }
        else if (PlayerIndex == 1)//player 2
        {

            gameObject.tag = "Player2";//give the second player to enter the player 2 tag

             gameObject.AddComponent<Player2Health>();//Add player 2 health script to player 2

            P1InventoryCanvas.gameObject.SetActive(false);


            transform.position = new Vector3(7, 0, 0);//player 2 starting position

            //need to adjust animation accordingly
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = rotation;//flips player 2 on start



        }

        
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

        
        //falling//
        if (gameObject.transform.position.y > -3.7)
        {
            anim.enabled = false;
            spriteRenderer.sprite = jumpPose;
        }

        //PlayerDied();//if a player dies game over screen



    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector2(moveInput.x, 0f);
        horizontal = context.ReadValue<Vector2>().x;
        if (gameObject.transform.position.y < -3.7)
        {
            anim.enabled = true;
        }
            //Debug.Log(moveDirection);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.enabled = false;
        spriteRenderer.sprite = jumpPose;
        Debug.Log("you pressed jump");
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //punch pose//
        anim.enabled = false;
        spriteRenderer.sprite = punchPose;
       // Debug.Log("you punched");
        //await Task.Delay(100);
        //StartCoroutine(delaySeconds());
        //spriteRenderer.sprite = idlePose;

        Debug.Log("you pressed attack");

        //If an attack was landed
        if (arePlayersColliding == true && context.performed) 
        {
            didAttack = true;
            Debug.Log("you landed an attack");
            
            if (gameObject.CompareTag("Player1"))
            {
                Debug.Log("og p1 health" + Player1HealthAccess.health);

                Player2HealthAccess.health -= DamageDone;//Take 1 heart from player 2

                //Player1HealthAccess.dealDamageToP2();

            }

            else if (gameObject.CompareTag("Player2"))
            {
                Debug.Log("og p2 health" + Player2HealthAccess.health);

                Player1HealthAccess.health -= DamageDone;//Take 1 heart from player 1

                //Player2HealthAccess.dealDamageToP1();


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
        //idle// i need this to check if the player is moving
        if ((rb.velocity == Vector2.zero) && (gameObject.transform.position.y < -3.7))
        {
            anim.enabled = false;
            spriteRenderer.sprite = idlePose;
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

    IEnumerator delaySeconds()
    {
        yield return new WaitForSeconds(2);
    }



    //Game over
    //Called in Assign scripts
    public void PlayerDied()
    {
        //if a player dies game over
        if (Player1HealthAccess.health == 0 || Player2HealthAccess.health == 0)
        {
            Debug.Log("Player died, Game over");
            SceneManager.LoadScene("EndGame");
        }

    }






}