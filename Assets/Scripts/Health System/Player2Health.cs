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

    }
    
    public void dealDamageToP1()
    {

            p1HealthAccess.health -= Player2DamageAmount;
            
    }
}
