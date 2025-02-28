using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public PlayerController playerControllerAccess;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        dealDamage();
    }

    public void dealDamage()
    {
        if(playerControllerAccess.didPlayersCollide == true && playerControllerAccess.didAttack == true)
        {
            if (health > 0)
            {
                health -= 1;
            }
        }
    }
}
