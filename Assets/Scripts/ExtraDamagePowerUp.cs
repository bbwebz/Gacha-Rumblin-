using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class ExtraDamagePowerUp : MonoBehaviour
{

    [SerializeField]
    private float extraDamage = 5;
    [SerializeField]
    private int healthDecrease = 2;
    [SerializeField]
    private float duration = 10;

    [SerializeField]
    private GameObject artToDisable = null;

    private Collider2D powerUpCollider;


    private void Awake()
    {

        powerUpCollider = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        if (pc != null)
        {

            StartCoroutine(PowerupSequence(pc));
        }
    }

  
    IEnumerator PowerupSequence(PlayerController pc)
    {
        //soft disable
        powerUpCollider.enabled = false;
        artToDisable.SetActive(false);//sprite is no longer visible

        Debug.Log("Decrease Health power up"); 
        pc.DecreaseHealth(healthDecrease);//decrease health
        //can now do more damage

        yield return new WaitForSeconds(duration);//has powerup for 10 seconds
        Deactivate(pc);//deactivate power up

        Destroy(gameObject);//destroy power up


    }

    private void Deactivate(PlayerController pc)
    {
        Debug.Log("deactivate");
        //return damage that player can do back to normal
    }


}

