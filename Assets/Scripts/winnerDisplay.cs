using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class winnerDisplay : MonoBehaviour
{
    public TextMeshProUGUI winnerDisplayText;
    [SerializeField] RoundManager roundManagerAccess;

    // Update is called once per frame
    void Update()
    {

        if (roundManagerAccess.winningPlayer == 1)
        {
            winnerDisplayText.text = "Player 1 wins the Game";
        }
        else if (roundManagerAccess.winningPlayer == 2)
        {
            winnerDisplayText.text = "Player 2 wins the Game";
        }
        else
        {
            winnerDisplayText.text = "Game was a tie";
        }

    }
}
