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
    public float moveSpeed = 10f;
    public float jumpForce;
    private float horizontal;
    private float timeAttackBttnPress;
    private float attackDelay = 3; //seconds for attack cooldown
    private float roundNum;

    public bool didAttack = false;
    bool isFacingLeft = false;
    public bool arePlayersColliding = false;
    public bool isDoingKnockback = false;

    //For using power ups
    public AssignPowerUps assignPowerAccess;
    public AllPowerUps allPowers;
    public InventoryP1 inventoryP1;
    public InventoryP1 inventoryP2;


    //for animation//
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public Sprite idlePose;
    public Sprite jumpPose;
    public Sprite punchPose;

    public int PlayerIndex;

    public bool Player1Trig = false;
    public bool Player2Trig = false;

    [SerializeField]
    private bool touchingFloor = false;


    InputDevice device;


    private void Awake()
    {
        controls = new PlayerControls();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        controls.Gameplay.Enable();

        rb = GetComponent<Rigidbody2D>();

       
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.freezeRotation = true;

        //--------------- Player multiplayer -------------------

        PlayerIndex = GetComponent<PlayerInput>().playerIndex;//get player index

        //Set Player Tags    
        if (PlayerIndex == 0) {
            gameObject.tag = "Player1";//give the first player to enter the player 1 tag

             gameObject.AddComponent<Player1Health>();//Add player 1 health script to player 1

            AssignScripts.assigner.player1Prefab = gameObject;
            device = SpawnPlayerSetupMenu.device1;

            Debug.Log("player 1 device; " + device);

        }
        else if (PlayerIndex == 1)//player 2
        {

            gameObject.tag = "Player2";//give the second player to enter the player 2 tag

             gameObject.AddComponent<Player2Health>();//Add player 2 health script to player 2


            //Assigns player2prefab ins assignscripts as the player 2 game object
            AssignScripts.assigner.player2Prefab = gameObject;

            //device = gameObject.GetComponent<PlayerInput>().devices[0];
            device = SpawnPlayerSetupMenu.device2;

            Debug.Log("player 2 device; " + device);

            Debug.Log("StaticData.itemP1Keep" + StaticData.itemP1Keep);
            Debug.Log("StaticData.itemP2Keep" + StaticData.itemP2Keep);
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
            //they are not on the floor
            touchingFloor = false;

            anim.enabled = false;
            spriteRenderer.sprite = jumpPose;
        }
        else
        {
            //they are on the floor
            touchingFloor = true;

        }


    }

    // ------------------------------------ Player Button actions ----------------------------------------
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
        //Player can only jump if they were touching the ground
        if (touchingFloor == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.enabled = false;
            spriteRenderer.sprite = jumpPose;
            //Debug.Log("you pressed jump");
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //punch pose
        anim.enabled = false;
        spriteRenderer.sprite = punchPose;

        Debug.Log("you pressed attack"); //player's touching + button pressed

        //debugging statements to check the time and attack time
        /*
        Debug.Log("Time Now: " + Time.time);
        Debug.Log("Time Attack Button Pressed: " + timeAttackBttnPress);
        Debug.Log("Time Difference: " + (Time.time - timeAttackBttnPress));
        */

        if (arePlayersColliding == true && context.performed) //if players colliding and on first instance of button press
        {
            //if difference from first button press is more than 5 seconds
            if (Time.time - timeAttackBttnPress >= attackDelay && !didAttack)
            {
                //only update timeAttackBttnPress if the cooldown condition is met
                timeAttackBttnPress = Time.time; //capture the time stamp of when the button was pressed
                didAttack = true;
                Debug.Log("you landed an attack");

                if (gameObject.CompareTag("Player1"))
                {
                    Player1HealthAccess.dealDamageToP2();
                    Player2HealthAccess.dealKnockbackToSelf(isFacingLeft);
                }
                else if (gameObject.CompareTag("Player2"))
                {
                    Player2HealthAccess.dealDamageToP1();
                    Player1HealthAccess.dealKnockbackToSelf(isFacingLeft);
                }
                //Make IEnumerator to hold pose for a second

                //reset to prepare for the next attack press
                didAttack = false;
            }
            else
            {
                Debug.Log("you're on attack cooldown WAIT");
            }
        }
    }


    //Activating the power up
    public void OnUsePowerup(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger pressed used");

        if (PlayerIndex == 0  && allPowers != null)//if player 1 triggers power up 
        {
            //if player 1 triggerd it player 1 trigger = true
            Player1Trig = true;

            Debug.Log("Player 1 trigger");
            switch (StaticData.itemP1Keep)
            {
                case 0:
                    allPowers.UseGlassCanon();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 1:
                    allPowers.UseBeefed();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 2:
                    allPowers.UseShield();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 3:
                    allPowers.UseSpeed();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 4:
                    allPowers.UseSnail();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;
            }
            StaticData.itemP1Keep = -1;//set item id to -1 so that power up fucntion will no longer be called

            for (int i = 0; i < inventoryP1.slots.Length; i++)
            {
                inventoryP1.isFull[i] = false;//inventory is now empty
            }



        }

        else if (PlayerIndex == 1 && allPowers != null)//if player 2 triggers power up 
        {
            Player2Trig = true;
            switch (StaticData.itemP2Keep)
            {
                case 0:
                    allPowers.UseGlassCanon();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

                case 1:
                    allPowers.UseBeefed();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

                case 2:
                    allPowers.UseShield();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case 3:
                    allPowers.UseSpeed();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

                case 4:
                    allPowers.UseSnail();
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

            }
            Debug.Log("Player 2 trigger");

            StaticData.itemP2Keep = -1;//set item id to -1 so that power up fucntion will no longer be called

            for (int i = 0; i < inventoryP2.slots.Length; i++)
            {
                inventoryP2.isFull[i] = false;//inventory is now empty
            }

        }

    }

    //----------------------------------------------------------------------------//




    //--- Moving horizontally -----
    private void FixedUpdate()
    {
        if (!isDoingKnockback) { 
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        }

        //avoids sliding
        if (horizontal < 0.1f && horizontal > -0.1f && !isDoingKnockback)
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

    //--- Collision -----

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