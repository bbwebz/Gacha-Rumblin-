using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.HID.HID;


public class AllPowerUps : MonoBehaviour
{
    public UnityEngine.UI.Button PowerUpButton;

    public Player1Health Player1HealthAccess;
    public Player2Health Player2HealthAccess;

    public GameObject ObjectPower;

    public bool Inventory1 = false;
    public bool Inventory2 = false;

    //------------------------ Glass Canon ---------------------------------
    //On button clicked use powerUp
    public void UseGlassCanon()//activate power up
    {
            StartCoroutine(GlassCanonSequence());
            Debug.Log("GlassCanon used");
    }

  
    IEnumerator GlassCanonSequence()
    {
        float duration = 5;
       Debug.Log("Decrease Health power up");


        //can now do more damage
        //Player1HealthAccess.health = 1;
        if(Inventory1 == true )
        {
            Debug.Log("In player 1s inventory");
        }
        else if (Inventory2 == true)
        {
            Debug.Log("In player 2s inventory");
        }

        PowerUpButton.interactable  = false;//disables button so that the player can no longer use the power up
        yield return new WaitForSeconds(duration);//has powerup for 5 seconds

        DeactivateGlassCanon();//deactivate power up
        Destroy(gameObject);//destroy power up button

    }

    //Deactivates any buffs given to the player
    private void DeactivateGlassCanon()
    {
        Debug.Log("deactivate");
        //return damage that player can do back to normal
    }



    //------------------------ Beefed ---------------------------------





}

