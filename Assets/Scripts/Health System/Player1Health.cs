using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Player2Health p2HealthAccess;
    public int Player1DamageAmount;//amount of damage a player can do


    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
        Player1DamageAmount = 1;

    }

    public void dealDamageToP2()
    {

            Debug.Log("Player 1 health" + health);

            p2HealthAccess.health -= Player1DamageAmount;
 
    }
}
