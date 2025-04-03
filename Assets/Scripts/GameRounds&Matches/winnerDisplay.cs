using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class winnerDisplay : MonoBehaviour
{
    public TextMeshProUGUI winnerDisplayText; //for Victory scene

    private void Awake()
    {
        Debug.Log("inside victory scene now");
    }

    private void Start()
    {
        displayGameWinner();
    }

    private void displayGameWinner()
    {
        if (staticDataMatches.winningPlayerKeep == 1)
        {
            Debug.Log("winningPlayer in text IF is: " + staticDataMatches.winningPlayerKeep);
            winnerDisplayText.text = "Player 1 wins the Game";
        }
        else if (staticDataMatches.winningPlayerKeep == 2)
        {
            Debug.Log("winningPlayer in text IF is: " + staticDataMatches.winningPlayerKeep);
            winnerDisplayText.text = "Player 2 wins the Game";
        }
        else
        {
            Debug.Log("winningPlayer in text IF is: " + staticDataMatches.winningPlayerKeep);
            winnerDisplayText.text = "Game was a tie";
        }
    }

}
