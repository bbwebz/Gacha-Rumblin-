using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AssignScripts : MonoBehaviour
{
    public static AssignScripts assigner;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
   
    public GameObject player1HealthUI;
    public GameObject player2HealthUI;

    public GameObject player1Inventory;
    public GameObject player2Inventory;

    public GameObject assignPowerUps;

    public GameObject AllPowerUpsAccess;

    public GameObject RoundManagerAccess;


    bool onetime = false;

    private void Awake()
    {
        if (assigner == null)
        {
            assigner = this;
        }
    }


    //adds components into to corect slot once everything is instantiated
    void Update()
    {
        
        if (player2Prefab != null)//if there is one prefab with the tag of player2 then you can start adding player health as parameter
        {
            //Calls function only once
            if (!onetime)
            {
                //Assign power ups to each player
                //assignPowerUps.GetComponent<AssignPowerUps>().Generate();
                assignPowerUps.GetComponent<AssignPowerUps>().Assign();
                Debug.Log("AllpowerUps assigning");
                onetime = true;
            }

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


            //Giving player controller acces to  all powerups script
            player1Prefab.GetComponent<PlayerController>().allPowers = AllPowerUpsAccess.GetComponent<AllPowerUps>();
            player2Prefab.GetComponent<PlayerController>().allPowers = AllPowerUpsAccess.GetComponent<AllPowerUps>();

            //Giving player controller acces to  assign powerups script
            player1Prefab.GetComponent<PlayerController>().assignPowerAccess = assignPowerUps.GetComponent<AssignPowerUps>();
            player2Prefab.GetComponent<PlayerController>().assignPowerAccess = assignPowerUps.GetComponent<AssignPowerUps>();


            //All power ups health access
            AllPowerUpsAccess.GetComponent<AllPowerUps>().Player1HealthAccess = player1Prefab.GetComponent<Player1Health>();
            AllPowerUpsAccess.GetComponent<AllPowerUps>().Player2HealthAccess = player2Prefab.GetComponent<Player2Health>();

            //All power ups PLayer controller access
            AllPowerUpsAccess.GetComponent<AllPowerUps>().Player1ControllerAccess = player1Prefab.GetComponent<PlayerController>();
            AllPowerUpsAccess.GetComponent<AllPowerUps>().Player2ControllerAccess = player2Prefab.GetComponent<PlayerController>();

            //Giving PlayerController script access to players inventory
            player1Prefab.GetComponent<PlayerController>().inventoryP1 =  player1Inventory.GetComponent<InventoryP1>();
            player2Prefab.GetComponent<PlayerController>().inventoryP2 =  player2Inventory.GetComponent<InventoryP1>();


            //Game Over
            //player1Prefab.GetComponent<PlayerController>().PlayerDied();
            //player2Prefab.GetComponent<PlayerController>().PlayerDied();

            //Next Round and Round Manager
            RoundManagerAccess.GetComponent<RoundManager>().player1HealthAccess = player1Prefab.GetComponent<Player1Health>();
            RoundManagerAccess.GetComponent<RoundManager>().player2HealthAccess = player2Prefab.GetComponent<Player2Health>();

        }



    }



}
