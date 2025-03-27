using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.HID.HID;


public class AllPowerUps : MonoBehaviour
{

    public Player1Health Player1HealthAccess;
    public Player2Health Player2HealthAccess;
    public PlayerController Player1ControllerAccess;
    public PlayerController Player2ControllerAccess;

    //public Pickup[] powerUps;
    public AssignPowerUps assignPowerUps;


    public bool Inventory1 = false;
    public bool Inventory2 = false;

    public GameObject PhysicalShieldSprite;
    public GameObject PhysicalShieldClone;


    //------------------------ Glass Canon ---------------------------------
    //On button clicked use powerUp
    // id = 0
    public void Start()
    {
            AssignScripts.assigner.AllPowerUpsAccess = gameObject;

    }
    public void UseGlassCanon()//activate power up
    {
            StartCoroutine(GlassCanonSequence());
            Debug.Log("GlassCanon used");
    }

  
    IEnumerator GlassCanonSequence()
    {
        float duration = 5;
       Debug.Log("Decrease Health power up");

        if (Player1ControllerAccess.Player1Trig == true)//If player 1 has the power up and is using it
        {
            Player1HealthAccess.health -= 1;//take away 1 health from p1
            Player1HealthAccess.Player1DamageAmount += 1;//Player 1 can now do an extra amount of damage

            Debug.Log("Player 1 damage amount: " + Player1HealthAccess.Player1DamageAmount);

            Destroy(assignPowerUps.powerUps[0].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateGlassCanon();//deactivate power up

        }
        else if (Player2ControllerAccess.Player2Trig == true)//If player 2 has the power up and is using it
        {
            Player2HealthAccess.health -= 1;//take away 1 health form p2
            Player2HealthAccess.Player2DamageAmount += 1;//Player 2 can now do an extra amount of damage


            Destroy(assignPowerUps.powerUps[0].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateGlassCanon();//deactivate power up


        }


    }


    //Deactivates any buffs given to the player
    private void DeactivateGlassCanon()
    {
        //return damage that player can do back to normal

        Player1ControllerAccess.Player1Trig = false;
        Player2ControllerAccess.Player2Trig = false;

        //set player damage amount back to normal
        Player1HealthAccess.Player1DamageAmount = 1;
        Player2HealthAccess.Player2DamageAmount = 1;


        Debug.Log("deactivated Glass Canon");


    }



    //------------------------ Beefed ---------------------------------
    // id = 1
    public void UseBeefed()//activate power up
    {
        StartCoroutine(BeefedSequence());
        Debug.Log("Beefed used");
    }


    IEnumerator BeefedSequence()
    {
        Debug.Log("Beefed PowerUp");

        float duration = 10;
        if (Player1ControllerAccess.Player1Trig == true)//If player 1 has the power up and is using it
        {
            if (Player1HealthAccess.health < 5)// add 1 health to p1 if health is < 5
            {
                Player1HealthAccess.health += 1;
                Debug.Log("increase player 2 health");

            }

            Player1HealthAccess.Player1DamageAmount -= 1;//Player 1 can now do less damage

            Debug.Log("Player 1 damage amount: " + Player1HealthAccess.Player1DamageAmount);

            Destroy(assignPowerUps.powerUps[1].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateBeefed();//deactivate power up

        }
        else if (Player2ControllerAccess.Player2Trig == true)//If player 2 has the power up and is using it
        {
            if (Player2HealthAccess.health < 5)// add 1 health to p2 if health is < 5
            {
                Debug.Log("increase player 2 health");
                Player2HealthAccess.health += 1;
            }
            Player2HealthAccess.Player2DamageAmount -= 1;///Player 2 can now do less damage


            Destroy(assignPowerUps.powerUps[1].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateBeefed();//deactivate power up


        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateBeefed()
    {
        //return damage that player can do back to normal

        Player1ControllerAccess.Player1Trig = false;
        Player2ControllerAccess.Player2Trig = false;

        //set player damage amount back to normal
        Player1HealthAccess.Player1DamageAmount = 1;
        Player2HealthAccess.Player2DamageAmount = 1;

        Debug.Log("deactivate Beefed");

    }




    //------------------------ Shield ---------------------------------
    //Blocks attacks for  5 seconds but player cannot do dammage
    // id = 2
    public void UseShield()//activate power up
    {
        StartCoroutine(ShieldSequence());
        Debug.Log("Shield used");
    }


    IEnumerator ShieldSequence()
    {
        Debug.Log("Shield PowerUp");

        float duration = 5;
        
        if (Player1ControllerAccess.Player1Trig == true)//If player 1 has the power up and is using it
        {
            //Will probably change it to be a barrier around player idk
            Player2HealthAccess.Player2DamageAmount = 0;//Disable Player 2's ability to do damage

            Debug.Log("Player 1 damage amount: " + Player1HealthAccess.Player1DamageAmount);
            PhysicalShieldClone = Instantiate(PhysicalShieldSprite, Player1ControllerAccess.transform, false);
            Destroy(assignPowerUps.powerUps[2].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateShield();//deactivate power up

        }
        else if (Player2ControllerAccess.Player2Trig == true)//If player 2 has the power up and is using it
        {
            Player1HealthAccess.Player1DamageAmount = 0;///Disable Player 1's ability to do damage


            Destroy(assignPowerUps.powerUps[2].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateShield();//deactivate power up


        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateShield()
    {
        //return damage that player can do back to normal

        Player1ControllerAccess.Player1Trig = false;
        Player2ControllerAccess.Player2Trig = false;

        //set player damage amount back to normal
        Player1HealthAccess.Player1DamageAmount = 1;
        Player2HealthAccess.Player2DamageAmount = 1;
        Destroy(PhysicalShieldClone);//Destroy shield
        Debug.Log("deactivate Shield");

    }



    //------------------------ Speed ---------------------------------
    // id = 3
    public void UseSpeed()//activate power up
    {
        StartCoroutine(SpeedSequence());
        Debug.Log("Speed used");
    }


    IEnumerator SpeedSequence()
    {
        Debug.Log("Speed PowerUp");

        float duration = 10;
        if (Player1ControllerAccess.Player1Trig == true)//If player 1 has the power up and is using it
        {
            Player1ControllerAccess.moveSpeed = 20f;//Player is now faster
            Player2HealthAccess.Player2DamageAmount = 2;//gets more dmage if hit

            Destroy(assignPowerUps.powerUps[3].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 10 seconds
            DeactivateSpeed();//deactivate power up

        }
        else if (Player2ControllerAccess.Player2Trig == true)//If player 2 has the power up and is using it
        {
            Player2ControllerAccess.moveSpeed = 20f;//Player is now faster
            Player1HealthAccess.Player1DamageAmount = 2;//gets more dmage if hit


            Destroy(assignPowerUps.powerUps[3].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateSpeed();//deactivate power up


        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateSpeed()
    {
        //return damage that player can do back to normal

        Player1ControllerAccess.Player1Trig = false;
        Player2ControllerAccess.Player2Trig = false;

        //set player speed amount back to normal
        Player1ControllerAccess.moveSpeed = 10f;
        Player2ControllerAccess.moveSpeed = 10f;

        //set player damage amount back to normal
        Player1HealthAccess.Player1DamageAmount = 1;
        Player2HealthAccess.Player2DamageAmount = 1;

        Debug.Log("deactivate Speed");

    }



    //------------------------ Snail ---------------------------------
    // id = 4
    public void UseSnail()//activate power up
    {
        StartCoroutine(SnailSequence());
        Debug.Log("Snail used");
    }


    IEnumerator SnailSequence()
    {
        Debug.Log("Snail PowerUp");

        float duration = 7;
        if (Player1ControllerAccess.Player1Trig == true)//If player 1 has the power up and is using it
        {
            Player1ControllerAccess.moveSpeed = 5f;//Player is now slower
            Player1HealthAccess.Player1DamageAmount = 2;// does more damage

            Destroy(assignPowerUps.powerUps[4].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 10 seconds
            DeactivateSnail();//deactivate power up

        }
        else if (Player2ControllerAccess.Player2Trig == true)//If player 2 has the power up and is using it
        {
            Player2ControllerAccess.moveSpeed = 5f;//Player is now slower
            Player2HealthAccess.Player2DamageAmount = 2;//  does more damage


            Destroy(assignPowerUps.powerUps[4].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateSnail();//deactivate power up


        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateSnail()
    {
        //return damage that player can do back to normal

        Player1ControllerAccess.Player1Trig = false;
        Player2ControllerAccess.Player2Trig = false;

        //set player speed amount back to normal
        Player1ControllerAccess.moveSpeed = 10f;
        Player2ControllerAccess.moveSpeed = 10f;

        //set player damage amount back to normal
        Player1HealthAccess.Player1DamageAmount = 1;
        Player2HealthAccess.Player2DamageAmount = 1;

        Debug.Log("deactivate Snail");

    }


























}

