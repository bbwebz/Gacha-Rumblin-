using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class winnerRoundDisplay : MonoBehaviour
{
    public TextMeshProUGUI winnerDisplayText2; //for EndGame scene (after each round)

    void Update()
    {
        displayRoundWinner();
    }

    private void displayRoundWinner()
    {
        if (staticDataMatches.winningRoundPlayerKeep == 1)
        {
            Debug.Log("winningRoundPlayer in text IF is: " + staticDataMatches.winningRoundPlayerKeep);
            winnerDisplayText2.text = "Player 1 wins the Round";
        }
        else if (staticDataMatches.winningRoundPlayerKeep == 2)
        {
            Debug.Log("winningRoundPlayer in text IF is: " + staticDataMatches.winningRoundPlayerKeep);
            winnerDisplayText2.text = "Player 2 wins the Round";
        }
        else
        {
            Debug.Log("winningRoundPlayer in text IF is: " + staticDataMatches.winningRoundPlayerKeep);
            winnerDisplayText2.text = "Round was a tie";
        }
    }

}
