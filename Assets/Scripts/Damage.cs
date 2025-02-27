using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    GameObject player;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;

            Debug.Log("Yipppe collision!");
            PlayerController pc = player.GetComponent<PlayerController>();
            pc.DecreaseHealth(1);
        }
    }

    

}
