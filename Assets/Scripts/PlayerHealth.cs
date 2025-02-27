using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2") /*&& attack button is clicked*/ ) //checks the tag of the object its colliding with
        {
            Debug.Log("player collided!!!");
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
