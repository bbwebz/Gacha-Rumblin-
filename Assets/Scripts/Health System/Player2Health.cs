using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Player1Health p1HealthAccess;

    // Start is called before the first frame update
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
            Debug.Log("health minus was run");
        }
    }
}
