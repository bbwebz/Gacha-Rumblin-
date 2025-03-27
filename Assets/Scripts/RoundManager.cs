using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public static int numOfRounds = 0; //number of game rounds
    public TimerController timerControllerAccess;
    public Player1Health player1HealthAccess;
    public Player2Health player2HealthAccess;

    private void Update()
    {

        if (player1HealthAccess != null || player2HealthAccess != null)
        {
            nextRound();
        }
    }

    private void nextRound()
    {
        if (player1HealthAccess.health == 0 || player2HealthAccess.health == 0 || timerControllerAccess.timeLeft == 0)
        {
            numOfRounds++; //increase a round
            Debug.Log("number of rounds is now:" + numOfRounds);

            if (numOfRounds < 3)
            {
                SceneManager.LoadScene("EndGame"); //so they can click "next round" button
            }
            else
            {
                SceneManager.LoadScene("StartGame"); //back to main menu
                numOfRounds = 0;
            }
        }
    }



}
