using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void dealDamage()
    {
        if (health > 0)
        {
            health -= 1;
            Debug.Log("health minus was run");
        }
    }
}
