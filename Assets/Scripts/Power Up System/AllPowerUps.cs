using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


public class AllPowerUps : MonoBehaviour
{

    //[SerializeField]//makes it editable in unity but still private
    //private float extraDamage = 5;
    //[SerializeField]
    //private int healthDecrease = 2;
    [SerializeField]
    private float duration = 10;

    [SerializeField]
    //private GameObject artToDisable = null;

    //AssignPowerUps assignPowerUps;



    public void OnClick()
    {
        UsePowerUp();
    }


    public void UsePowerUp()//activate power up
    {
       
        //if (assignPowerUps.itemId == 1){
        //if player was assigned the first powerup, run
            StartCoroutine(PowerupSequence());
            Debug.Log("power up used");
        //}
    }

  
    IEnumerator PowerupSequence()
    {
        
        Debug.Log("Decrease Health power up"); 
        //pc.DecreaseHealth(healthDecrease);//decrease health
        //can now do more damage

        yield return new WaitForSeconds(duration);//has powerup for 10 seconds
        Deactivate();//deactivate power up

        //Destroy(gameObject);//destroy power up


    }

    //private void Deactivate(PlayerController pc)
    private void Deactivate()
    {
        Debug.Log("deactivate");
        //return damage that player can do back to normal
    }


}

