using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SwapButton : MonoBehaviour
{
    public Player1Health player1HealthAccess;
    public Player2Health player2HealthAccess;

    public Pickup[] pickupAccess;
    public AssignPowerUps assignPowerUpsAccess;
    public AllPowerUps allPowerUpsAccess;

    public Button swapButtonP1;
    public Button swapButtonP2;
    public bool isUsedP1 = false;
    public bool isUsedP2 = false;

    bool once = false;


    public void setIsUsedp1()
    {
        isUsedP1 = true;
    }

    public void setIsUsedp2()
    {
        isUsedP2 = true;
    }

    public void setupSwapButton()
    {
        Debug.Log("in swap button start");

        if (player1HealthAccess != null && player2HealthAccess != null)
        {
            swapButtonP1.gameObject.SetActive(false);
            swapButtonP2.gameObject.SetActive(false);

            //constantly check isUsed booleans and hide or show the buttons for each player accordingly
            hideOrShowButton();
            assignNewPowerUp();

        }
        else
        {
            Debug.Log("player healths were null");
        }
    }


    private void hideOrShowButton()
    {
        Debug.Log("in hideorshow function");
        
        //hide and show button for P1
        if(player1HealthAccess.health <= 2 && !isUsedP1)
        {
            swapButtonP1.gameObject.SetActive(true);
        }
        else
        {
            swapButtonP1.gameObject.SetActive(false);
        }

        //hide and show button for P2
        if (player2HealthAccess.health <= 2 && !isUsedP2)
        {
            swapButtonP2.gameObject.SetActive(true);
        }
        else
        {
            swapButtonP2.gameObject.SetActive(false);
        }
    }

    public void assignNewPowerUp()
    {
        Debug.Log("in assignnewpowerup function");
        Debug.Log("isUsedP1 is:" + isUsedP1 + " isUsedP2 is: " + isUsedP2);

        for (int i = 0; i < pickupAccess.Length; i++)
        {
            //Debug.Log("i is: " + i);

            if (isUsedP1 == true && pickupAccess[i].inventoryP1.isFull[0] == true)
            {
                Debug.Log("player 1 clicked gamble and inventory is full");

                if(!once)
                {
                    assignPowerUpsAccess.ReGenerateP1(); //generate new randome power up
                    Debug.Log("new random powerup generated for p1");
                    pickupAccess[i].inventoryP1.isFull[0] = false;
                    pickupAccess[i].AddPowerUpP1(); //add it to their inventory
                    Debug.Log("new power up added to inventory for p1");
                    assignPowerUpsAccess.Assign(); //display it in their inventory box

                    once = true;
                }
                
            }

            if (isUsedP2 == true && pickupAccess[i].inventoryP2.isFull[0] == true)
            {
                Debug.Log("player 2 clicked gamble and inventory is full");
            }
        }


       



    }



}
