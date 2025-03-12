using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiatePlayers : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    private GameObject player1Inst;
    private GameObject player2Inst;
    public GameObject player1HealthUI;
    public GameObject player2HealthUI;

    public GameObject playerInventory;

    int playerCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton2) && playerCount < 2) //b button on xbox, circle on ps
        {
            playerCount++;

            if (playerCount == 1)
            {
                player1Inst = Instantiate(player1Prefab);
            }
            else if (playerCount == 2)
            {
                player2Inst = Instantiate(player2Prefab);

                //once both of the players have been spawned in, attach all of the script accesses
                player1Inst.GetComponent<Player1Health>().p2HealthAccess = player2Inst.GetComponent<Player2Health>();
                player2Inst.GetComponent<Player2Health>().p1HealthAccess = player1Inst.GetComponent<Player1Health>();

                //accessing eachothers health
                player1Inst.GetComponent<PlayerController>().Player1HealthAccess = player1Inst.GetComponent<Player1Health>();
                player1Inst.GetComponent<PlayerController>().Player2HealthAccess = player2Inst.GetComponent<Player2Health>();

                player2Inst.GetComponent<PlayerController>().Player1HealthAccess = player1Inst.GetComponent<Player1Health>();
                player2Inst.GetComponent<PlayerController>().Player2HealthAccess = player2Inst.GetComponent<Player2Health>();

                //players health containers
                player1HealthUI.GetComponent<HealthContainerManagerP1>().player1Health = player1Inst.GetComponent<Player1Health>();
                player2HealthUI.GetComponent<HealthContainerManagerP2>().player2Health = player2Inst.GetComponent<Player2Health>();

               


            }
        }
    }
}
