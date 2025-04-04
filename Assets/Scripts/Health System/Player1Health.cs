using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Player2Health p2HealthAccess;
    public float Player1DamageAmount;//amount of damage a player can do
    private Rigidbody2D rb;
    public Vector2 knockBackForce;
    int knockForce = 30;


    void Start()
    {
        maxHealth = 5;
        health = maxHealth;

        Player1DamageAmount = 0.5f;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Start health");

    }

    public void dealDamageToP2()
    {
        //Debug.Log("Player 1 health" + health);
        p2HealthAccess.health -= Player1DamageAmount;
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
