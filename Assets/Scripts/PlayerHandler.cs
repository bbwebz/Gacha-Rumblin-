using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public PlayerController playerContolAccess;
    public int playerNum = 1;

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        switch (playerNum)
        {
            case 1://player 1

                inputVector.x = Input.GetAxis("Horizontal_P1");
                inputVector.y = Input.GetAxis("Vertical_P1");
                Debug.Log("Player 1 move");
                break;

            case 2: //player 2
                //create h and v controller fror each player
                inputVector.x = Input.GetAxis("Horizontal_P2");
                inputVector.y = Input.GetAxis("Vertical_P2");
                Debug.Log("Player 2 move");
                break;

        }


        Debug.Log("Player 3 move");

    }
    

}
