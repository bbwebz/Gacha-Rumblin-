using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class HealthContainerManagerP1 : MonoBehaviour
{
    public GameObject heartPrefab;
    public Player1Health player1Health;
    List<Heart> hearts = new List<Heart>();
    bool shouldCreateHalf = false;

    //Called in assign scripts so it will wait till it gets player health
    //private void Update()
    //{
    //    drawHearts();
    //}

    public void drawHearts()
    {
        clearHearts();

        int fullheartsToMake = (int)player1Health.health;
        
        float halfHeartsToMake = player1Health.health - fullheartsToMake;
        shouldCreateHalf = Mathf.Abs(halfHeartsToMake - 0.5f) < 0.001f;

        int emptyHeartsToMake = (int)player1Health.maxHealth - fullheartsToMake - (shouldCreateHalf ? 1 : 0);

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
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<Heart>();
    }
}
