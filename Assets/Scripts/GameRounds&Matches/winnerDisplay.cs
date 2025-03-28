using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class winnerDisplay : MonoBehaviour
{
    public TextMeshProUGUI winnerDisplayText; //for Victory scene


    private void Start()
    {
        displayGameWinner();
    }

    private void displayGameWinner()
    {
        if (staticDataMatches.winningPlayerKeep == 1)
        {
            winnerDisplayText.text = "Player 1 wins the Game";
        }
        else if (staticDataMatches.winningPlayerKeep == 2)
        {
            winnerDisplayText.text = "Player 2 wins the Game";
        }
        else
        {
            winnerDisplayText.text = "Game was a tie";
        }
    }

}
