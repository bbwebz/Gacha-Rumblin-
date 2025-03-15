using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AssignScripts : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
   
    public GameObject player1HealthUI;
    public GameObject player2HealthUI;

    public GameObject Power;

    public GameObject PowerUpObjects;


    private int NumOfP1;
    private int NumOfP2;

    private void Start()
    {

    }

    //adds components into to corect slot once everything is instantiated
    void Update()
    {
        //Specifying which prefab instace is p1 and p2
        player1Prefab = GameObject.FindGameObjectWithTag("Player1");
        player2Prefab = GameObject.FindGameObjectWithTag("Player2");

        //Gets number of players with player1 and 2 tags
        NumOfP1 = GameObject.FindGameObjectsWithTag("Player1").Length;
         NumOfP2 = GameObject.FindGameObjectsWithTag("Player2").Length;


        
        if (NumOfP2 == 1)//if there is one prefab with the tag of player2 then you can start adding player health as parameter
        {
            //players health containers
            //Add player healths to appropriate containers
            player1HealthUI.GetComponent<HealthContainerManagerP1>().player1Health = player1Prefab.GetComponent<Player1Health>();
            player2HealthUI.GetComponent<HealthContainerManagerP2>().player2Health = player2Prefab.GetComponent<Player2Health>();


            player1Prefab.GetComponent<Player1Health>().p2HealthAccess = player2Prefab.GetComponent<Player2Health>();
            player2Prefab.GetComponent<Player2Health>().p1HealthAccess = player1Prefab.GetComponent<Player1Health>();

            //accessing eachothers health
            player1Prefab.GetComponent<PlayerController>().Player1HealthAccess = player1Prefab.GetComponent<Player1Health>();
            player1Prefab.GetComponent<PlayerController>().Player2HealthAccess = player2Prefab.GetComponent<Player2Health>();

            player2Prefab.GetComponent<PlayerController>().Player1HealthAccess = player1Prefab.GetComponent<Player1Health>();
            player2Prefab.GetComponent<PlayerController>().Player2HealthAccess = player2Prefab.GetComponent<Player2Health>();


            //draw hearts only when both players are in the game
            player1HealthUI.GetComponent<HealthContainerManagerP1>().drawHearts();//draw hearts only when both players are in the game
            player2HealthUI.GetComponent<HealthContainerManagerP2>().drawHearts();//draw hearts only when both players are in the game


            //Adding player 1 and 2 health components to app power ups scripts
            //PowerUps.GetComponent<AllPowerUps>().Player1HealthAccess = player1Prefab.GetComponent<Player1Health>();
            //Power.GetComponent<AllPowerUps>().Player2HealthAccess = player2Prefab.GetComponent<Player2Health>();

            //PowerUpObjects.GetComponent<Pickup>().inventoryP1 = player1Prefab.GetComponent<InventoryP1>();

            //Game Over
            player1Prefab.GetComponent<PlayerController>().PlayerDied();




        }



    }



}
