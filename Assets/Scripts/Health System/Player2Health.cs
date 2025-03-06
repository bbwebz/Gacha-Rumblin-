using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Player1Health p1HealthAccess;

    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
    }

    public void dealDamageToP1()
    {
        if (health > 0)
        {
            p1HealthAccess.health -= 1;
            Debug.Log("damage was done to P1");
        }
    }
}
