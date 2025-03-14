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

    //private Player2Health Player2HealthAccess;
    public GameObject player1Prefab;


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
        //pc.DecreaseHealth(healthDecrease);//decrease health
        //can now do more damage
        //Player2HealthAccess.health = 3;

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

    //public void UseGlassCanon()//activate power up
    //{
    //    StartCoroutine(GlassCanonSequence());
    //    Debug.Log("GlassCanon used");
    //}


    //IEnumerator GlassCanonSequence()
    //{
    //    float duration = 5;
    //    Debug.Log("Decrease Health power up");
    //    //pc.DecreaseHealth(healthDecrease);//decrease health
    //    //can now do more damage
    //    PowerUpButton.interactable  = false;//diables button so that the player can no longer use the power up
    //    yield return new WaitForSeconds(duration);//has powerup for 5 seconds
    //    DeactivateGlassCanon();//deactivate power up
    //    Destroy(gameObject);//destroy power up button

    //}

    ////Deactivates any buffs given to the player
    //private void DeactivateGlassCanon()
    //{
    //    Debug.Log("deactivate");
    //    //return damage that player can do back to normal
    //}





}

