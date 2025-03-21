using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Player1Health p1HealthAccess;
    public int Player2DamageAmount;//amount of damage a player can do
    private Rigidbody2D rb;
    public Vector2 knockBackForce;
    int knockForce = 30;

    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
        Player2DamageAmount = 1;
        rb = GetComponent<Rigidbody2D>();

    }

    public void dealDamageToP1()
    {
        //Debug.Log("Player 2 health" + health);
        p1HealthAccess.health -= Player2DamageAmount;
            
    }

    public void dealKnockbackToSelf(bool direction)
    {
        PlayerController pC = gameObject.GetComponent<PlayerController>();
        if (direction == false) //right
        {
            knockBackForce = new Vector2(knockForce, 0);
        }
        else
        {
            knockBackForce = new Vector2(-knockForce, 0);
        }

        Debug.Log("knockback func run");
        pC.isDoingKnockback = true;

        rb.AddForce(knockBackForce, ForceMode2D.Impulse);
        StartCoroutine(knockBackDelay(pC));
    }

    IEnumerator knockBackDelay(PlayerController pC)
    {
        yield return new WaitForSeconds(1);
        pC.isDoingKnockback = false;
    }
}
