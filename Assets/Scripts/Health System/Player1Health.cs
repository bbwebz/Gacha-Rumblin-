using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Player2Health p2HealthAccess;

    //start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
    }

    public void dealDamageToP2()
    {
        if (health > 0)
        {
            p2HealthAccess.health -= 1;
            Debug.Log("health minus was run");
        }
    }
}
