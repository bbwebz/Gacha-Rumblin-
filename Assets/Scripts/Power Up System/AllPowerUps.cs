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


   
    //------------------------ Glass Canon ---------------------------------
    //On button clicked use powerUp

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

            Destroy(assignPowerUps.powerUps[0].ButtonClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateGlassCanon();//deactivate power up

        }
        else if (Player2ControllerAccess.Player2Trig == true)//If player 2 has the power up and is using it
        {
            Player2HealthAccess.health -= 1;//take away 1 health form p2
            Player2HealthAccess.Player2DamageAmount += 1;//Player 2 can now do an extra amount of damage


            Destroy(assignPowerUps.powerUps[0].ButtonClone);//destroy power up button of the first item in the array
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


        Debug.Log("deactivated");


    }



    //------------------------ Beefed ---------------------------------

    public void UseBeefed()//activate power up
    {
        StartCoroutine(BeefedSequence());
        Debug.Log("Beefed used");
    }


    IEnumerator BeefedSequence()
    {
        float duration = 5;
        Debug.Log("Decrease Health power up");

     
        Destroy(assignPowerUps.powerUps[0].ButtonClone);//destroy power up button of the first item in the array
        yield return new WaitForSeconds(duration);//has powerup for 5 seconds

        DeactivateBeefed();//deactivate power up
    }

    //Deactivates any buffs given to the player
    private void DeactivateBeefed()
    {
       
        Debug.Log("deactivate");

        //return damage that player can do back to normal
    }



}

