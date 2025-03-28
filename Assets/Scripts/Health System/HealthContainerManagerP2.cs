using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainerManagerP2 : MonoBehaviour
{
    public GameObject heartPrefab;
    public Player2Health player2Health;
    List<Heart> hearts = new List<Heart>();
    bool shouldCreateHalf = false;

    public void drawHearts()
    {
        clearHearts();

        int fullheartsToMake = (int)player2Health.health;

        float halfHeartsToMake = player2Health.health - fullheartsToMake;
        shouldCreateHalf = Mathf.Abs(halfHeartsToMake - 0.5f) < 0.001f;

        int emptyHeartsToMake = (int)player2Health.maxHealth - fullheartsToMake - (shouldCreateHalf ? 1 : 0);

        for (int i = 0; i < fullheartsToMake; i++)
        {
            createFullHeart();
        }

        if (shouldCreateHalf)
        {
            createHalfHeart();
        }

        for (int i = 0; i < emptyHeartsToMake; i++)
        {
            createEmptyHeart();
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

    public void createHalfHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        Heart heartComponent = newHeart.GetComponent<Heart>();
        heartComponent.setHeartImage(heartStatus.Half);
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
