using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public static int numOfRounds = 0; //number of game rounds
    public TimerController timerControllerAccess;
    public Player1Health player1HealthAccess;
    public Player2Health player2HealthAccess;

    public static int P1numOfWins;
    public static int P2numOfWins;

    public static int winningPlayer = 0; //1 or 2
    public static int winningRoundPlayer = 0; //1 or 2

   

    private void Update()
    {
        nextRound();
        Debug.Log("winningRoundPLayer: " + winningRoundPlayer);
    }

    private void nextRound()
    {
        if (player1HealthAccess.health == 0 || player2HealthAccess.health == 0 || timerControllerAccess.timeLeft == 0)
        {
            numOfRounds++; //increase a round
            Debug.Log("number of rounds is now:" + numOfRounds);

            if (numOfRounds < 3) //if still rounds remaining to play
            {
                if (player1HealthAccess.health == 0)
                {
                    P2numOfWins++;
                    winningRoundPlayer = 2;
                    staticDataMatches.winningRoundPlayerKeep = winningRoundPlayer;
                    Debug.Log("winningRoundPlayer is: " + winningRoundPlayer);
                    Debug.Log("player2 numofwins is " + P2numOfWins);
                }
                else if (player2HealthAccess.health == 0)
                {
                    P1numOfWins++;
                    winningRoundPlayer = 1;
                    staticDataMatches.winningRoundPlayerKeep = winningRoundPlayer;
                    Debug.Log("winningRoundPlayer is: " + winningRoundPlayer);
                    Debug.Log("player1 numofwins is " + P1numOfWins);
                }
                else
                {
                    //winningRoundPlayer = 0;
                    Debug.Log("winningRoundPlayer is: " + winningRoundPlayer);
                    Debug.Log("Round was a tie");
                }

                SceneManager.LoadScene("EndGame"); //so they can click "next round" button
            }

            if(numOfRounds == 3) //all rounds are complete
            {
                SceneManager.LoadScene("Victory"); //display which player won all rounds
                checkWinner(P1numOfWins,P2numOfWins);
                //reset everything
                numOfRounds = 0;
                P1numOfWins = 0;
                P2numOfWins = 0;
                //winningRoundPlayer = 0;
            }
        }
    }

    private void checkWinner(int p1W, int p2W)
    {
        if(p1W > p2W)
        {
            Debug.Log("player 1 wins the WHOLE game");
            winningPlayer = 1;
            staticDataMatches.winningPlayerKeep = winningPlayer;
        }
        else if (p2W > p1W)
        {
            Debug.Log("player 2 wins the WHOLE game");
            winningPlayer = 2;
            staticDataMatches.winningPlayerKeep = winningPlayer;
        }
        else
        {
            Debug.Log("WHOLE game was a tie");
            winningPlayer = 0;
            staticDataMatches.winningPlayerKeep = winningPlayer;
        }
    }

}
