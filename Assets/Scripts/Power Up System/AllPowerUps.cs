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
    public void UseGlassCanon(float current, int opponent)//activate power up
    {
            StartCoroutine(GlassCanonSequence(current, opponent));
            Debug.Log("GlassCanon used");
    }

  
    IEnumerator GlassCanonSequence(float Current, int Opponent)
    {
        float duration = 5;
       Debug.Log("Decrease Health power up");

        //if playercontroller.player1trigger = true
        //minus form player health
        //

        Current -=1;
        Debug.Log("minus 1 health");

        Opponent +=2;
        Debug.Log("Plus 2 damage");

        //if(Inventory1 == true )
        //{
        //    Debug.Log("In player 1s inventory");
        //}
        //else if (Inventory2 == true)
        //{
        //    Debug.Log("In player 2s inventory");
        //}



        Destroy(assignPowerUps.powerUps[0].ButtonClone);//destroy power up button of the first item in the array
        yield return new WaitForSeconds(duration);//has powerup for 5 seconds

        DeactivateGlassCanon();//deactivate power up
    }

    //Deactivates any buffs given to the player
    private void DeactivateGlassCanon()
    {
        Debug.Log("deactivate");
        //return damage that player can do back to normal
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

        //can now do more damage
        //Player1HealthAccess.health = 1;
        //if(Inventory1 == true )
        //{
        //    Debug.Log("In player 1s inventory");
        //}
        //else if (Inventory2 == true)
        //{
        //    Debug.Log("In player 2s inventory");
        //}

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

