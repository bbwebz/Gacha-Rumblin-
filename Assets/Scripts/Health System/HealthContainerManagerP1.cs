using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainerManagerP1 : MonoBehaviour
{
    public GameObject heartPrefab;
    public Player1Health player1Health;
    List<Heart> hearts = new List<Heart>();

    private void Start()
    {
        drawHearts();
    }

    public void drawHearts()
    {
        clearHearts();
        float heartsToMake = player1Health.health;

        for (int i = 0; i < heartsToMake; i++)
        {
            createHeart();
        }


    }

    public void createHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        Heart heartComponent = newHeart.GetComponent<Heart>();
        heartComponent.setHeartImage(heartStatus.Full);
        hearts.Add(heartComponent);
    }


    public void clearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<Heart>();
    }



}
