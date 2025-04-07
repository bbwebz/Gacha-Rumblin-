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
    public SwapButton swapButtonAccess;
    public Pickup pickupAccess;


    //for animation//
    private Animator anim;
    //private SpriteRenderer spriteRenderer;
    //public Sprite idlePose;
    //public Sprite jumpPose;
    //public Sprite punchPose;

    public int PlayerIndex;
    public GameObject pI;
    private SpriteRenderer indicatorSprite;
    public Sprite p1Sprite;
    public Sprite p2Sprite;


    [SerializeField]
    private bool touchingFloor = false;

    public bool attacking = true;

    InputDevice[] device = { SpawnPlayerSetupMenu.device1, SpawnPlayerSetupMenu.device2 };

    AudioManager audioManager;

    public double floorPos;

    private void Awake()
    {
        controls = new PlayerControls();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        controls.Gameplay.Enable();

        rb = GetComponent<Rigidbody2D>();
        floorPos = -2;



    rb.freezeRotation = true;

        //--------------- Player multiplayer -------------------

        PlayerIndex = GetComponent<PlayerInput>().playerIndex;//get player index

        //Set Player Tags    
        if (PlayerIndex == 0) {
            gameObject.tag = "Player1";//give the first player to enter the player 1 tag

            gameObject.AddComponent<Player1Health>();//Add player 1 health script to player 1

            //transform.position = new Vector3(-6, 0, 0);//player 1 starting position
            //pI = Instantiate(pI, new Vector3(-6, 2, 0), transform.rotation); //player indicitaor initialization
            //pI.transform.parent = gameObject.transform;
            //indicatorSprite.sprite = p1Sprite;


            AssignScripts.assigner.player1Prefab = gameObject;
            //device = SpawnPlayerSetupMenu.device1;

            Debug.Log("SpawnPlayerSetupMenu.device1" + SpawnPlayerSetupMenu.device1);

            //device[0] = SpawnPlayerSetupMenu.device1;
            Debug.Log("device[0]" + device[0]);


            Gamepad.all.ToArray();

            for (int i = 0; i < Gamepad.all.Count; i++)
            {
                if (device[0] == Gamepad.all[i])
                {
                    Debug.Log("They have the same gamepad");
                    gameObject.GetComponent<PlayerInput>().actions.devices = new InputDevice[] { Gamepad.all[i] };

                }
                else
                {
                    Debug.Log("They have different gamepad");

                }
            }

            //gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("Gamepad", Gamepad.all[2]);


            //Debug.Log("player 1 device; " + device + "Prefab: " + gameObject);
            //Get list of all gamepads and compare it with SpawnPlayerSetupMenu.device1
            //if they match that is the gamepad the player will use

            


        }
        else if (PlayerIndex == 1)//player 2
        {

            gameObject.tag = "Player2";//give the second player to enter the player 2 tag

             gameObject.AddComponent<Player2Health>();//Add player 2 health script to player 2


            //transform.position = new Vector3(7, 0, 0);//player 2 starting position
            //pI = Instantiate(pI, new Vector3(7, 2, 0), transform.rotation); //player indicator object intitilization
            //pI.transform.parent = gameObject.transform;
            //indicatorSprite.sprite = p2Sprite;

            //need to adjust animation accordingly


            //Assigns player2prefab ins assignscripts as the player 2 game object
            AssignScripts.assigner.player2Prefab = gameObject;

            //device = gameObject.GetComponent<PlayerInput>().devices[0];
            //device = SpawnPlayerSetupMenu.device2;


            //Debug.Log("player 2 device; " + device + "Prefab: " + gameObject);

            Debug.Log("StaticData.itemP1Keep" + StaticData.itemP1Keep);
            Debug.Log("StaticData.itemP2Keep" + StaticData.itemP2Keep);

            Gamepad.all.ToArray();

            for (int i = 0; i < Gamepad.all.Count; i++)
            {
                if (device[1] == Gamepad.all[i])
                {
                    Debug.Log("They have the same gamepad");
                    gameObject.GetComponent<PlayerInput>().actions.devices = new InputDevice[] { Gamepad.all[i] };

                }
                else
                {
                    Debug.Log("They have different gamepad");

                }
            }

            //gameObject.GetComponent<PlayerInput>().SwitchCurrentControlScheme("Gamepad", Gamepad.all[0]);


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
        if (gameObject.transform.position.y > floorPos)
        {
            //they are not on the floor
            touchingFloor = false;
            anim.SetBool("isJumping", true);

            //anim.enabled = false;
            //spriteRenderer.sprite = jumpPose;
        }
        else
        {
            //they are on the floor
            touchingFloor = true;
            anim.SetBool("isJumping", false);

        }


    }

    // ------------------------------------ Player Button actions ----------------------------------------
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector2(moveInput.x, 0f);
        horizontal = context.ReadValue<Vector2>().x;
        if (gameObject.transform.position.y < floorPos)
        {
            anim.SetFloat("Moving", Mathf.Abs(horizontal));
            //anim.SetFloat("Moving", 1);

        }

        //Debug.Log(moveDirection);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Player can only jump if they were touching the ground
        if (touchingFloor == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("touching floor: " + touchingFloor);
            anim.SetBool("isJumping", false);

           
        }
        else if (touchingFloor == false) 
        {
            Debug.Log("touching floor: " + touchingFloor);
            anim.SetBool("isJumping", true);

        }

    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //punch pose
        //anim.enabled = false;
        //spriteRenderer.sprite = punchPose;
        attacking = true;

        anim.SetTrigger("OnAttack");
        anim.SetBool("isJumping", false);

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
                audioManager.PlaySFX(audioManager.damage);

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

                //reset to prepare for the next attack press
                didAttack = false;
                attacking = false;
                //anim.SetBool("OnAttack", attacking);
                //Debug.Log("attacking false" + attacking);


            }
            else
            {
                Debug.Log("you're on attack cooldown WAIT");
            }
        }
        Debug.Log("attacking true??" + attacking);

    }


    //Activating the power up
    public void OnUsePowerup(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger pressed used");

        if (PlayerIndex == 0  && allPowers != null)//if player 1 triggers power up 
        {
            audioManager.PlaySFX(audioManager.powerUp);
            //if player 1 triggerd it player 1 trigger = true

            Debug.Log("Player 1 trigger");
            switch (StaticData.itemP1Keep)
            {
                case 0:
                    allPowers.UseGlassCanon(1);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 1:
                    allPowers.UseBeefed(1);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 2:
                    allPowers.UseShield(1);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 3:
                    allPowers.UseSpeed(1);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;

                case 4:
                    allPowers.UseSnail(1);
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
            Debug.Log("Player 2 trigger");

            switch (StaticData.itemP2Keep)
            {
                case 0:
                    allPowers.UseGlassCanon(2); //pass in an int representing the player number 1 or 2
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

                case 1:
                    allPowers.UseBeefed(2);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

                case 2:
                    allPowers.UseShield(2);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case 3:
                    allPowers.UseSpeed(2);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

                case 4:
                    allPowers.UseSnail(2);
                    //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

            }

            StaticData.itemP2Keep = -1;//set item id to -1 so that power up fucntion will no longer be called

            for (int i = 0; i < inventoryP2.slots.Length; i++)
            {
                inventoryP2.isFull[i] = false;//inventory is now empty
            }

        }

    }

    public void OnGamble(InputAction.CallbackContext context)
    {
        Debug.Log("right shoulder pressed for gamble use");
        //start running the following functions to constantly check
        swapButtonAccess.setupSwapButton();
        swapButtonAccess.assignNewPowerUp();

        if (PlayerIndex == 0 && allPowers != null && context.performed && swapButtonAccess.isUsedP1 == false && swapButtonAccess.swapButtonP1.IsActive() == true) 
        {
            Debug.Log("Player 1 gamble");
            swapButtonAccess.isUsedP1 = true; //to hide the button
        }
        
        if (PlayerIndex == 1 && allPowers != null && context.performed && swapButtonAccess.isUsedP2 == false && swapButtonAccess.swapButtonP2.IsActive() == true)
        {
            Debug.Log("Player 2 gamble");
            swapButtonAccess.isUsedP2 = true; //to hide the button
        }
    }

    IEnumerator delaySec()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("after waiting a few seconds");
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
        if ((rb.velocity == Vector2.zero) && (gameObject.transform.position.y < -floorPos))
        {
            //anim.SetFloat("Moving", 0)

            //anim.enabled = false;
            //spriteRenderer.sprite = idlePose;
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



        ////falling//
        //if (collision.gameObject.CompareTag("Floor"))   
        //{
        //    //they are on the floor
        //    touchingFloor = true;
        //    Debug.Log("colliding floor: " + touchingFloor);
        //    anim.SetBool("isJumping", false);
        //}


    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    touchingFloor = false;
    //    anim.SetBool("isJumping", true);

    //    Debug.Log("touching floor false: " + touchingFloor);
    //}

}