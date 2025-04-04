using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SwapButton : MonoBehaviour
{
    public Player1Health player1HealthAccess;
    public Player2Health player2HealthAccess;
    public Button swapButtonP1;
    public Button swapButtonP2;
    public bool isUsedP1 = false;
    public bool isUsedP2 = false;


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

}
