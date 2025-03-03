using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainerManagerP2 : MonoBehaviour
{
    public GameObject heartPrefab;
    public Player2Health player2Health;
    List<Heart> hearts = new List<Heart>();

    private void Update()
    {
        drawHearts();
    }

    public void drawHearts()
    {
        clearHearts(); // Clear previous hearts
        float heartsToMake = player2Health.health;
        for (int i = 0; i < heartsToMake; i++)
        {
            createFullHeart(); // Create full hearts for current health
        }

        //draw empty hearts for the remaining health
        float heartsToTake = player2Health.maxHealth - player2Health.health;
        for (int i = 0; i < heartsToTake; i++)
        {
            if(player2Health.health > 0) //reminder to fix the hearts to stop going into negatives
            {
                createEmptyHeart();
            }
        }
    }
    public void createFullHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        Heart heartComponent = newHeart.GetComponent<Heart>();
        heartComponent.setHeartImage(heartStatus.Full);
        hearts.Add(heartComponent);
    }
    public void createEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        Heart heartComponent = newHeart.GetComponent<Heart>();
        heartComponent.setHeartImage(heartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void clearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<Heart>();
    }
}
