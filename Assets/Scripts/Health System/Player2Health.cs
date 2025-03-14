using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Player1Health p1HealthAccess;
    public int Player2DamageAmount;//amount of damage a player can do

    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
        Player2DamageAmount = 1;
        Debug.Log("Player 2 Health in script" + health);

    }
    private void Update()
    {
        Debug.Log("Player 2 health" + health);

    }


    public void dealDamageToP1()
    {
        //if (health > 0)
        //{
            p1HealthAccess.health -= Player2DamageAmount;
            Debug.Log("damage was done to P1");
            //Debug.Log("Deal damage to Player 1 Health in script" + health);

        //}
    }
}
