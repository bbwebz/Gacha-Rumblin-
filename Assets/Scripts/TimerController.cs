using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI timerDisplay;
    float gameTime = 4 * 60 + 1; // 4 minutes converted to seconds (240 seconds)
    float timeLeft;
    bool isGamePaused =  false;

    void Start()
    {
        timeLeft = gameTime; 
    }

    void Update()
    {
        if (timeLeft > 0 && isGamePaused == false)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                timeLeft = 0;
            }

            //calculate minutes and seconds from timeLeft
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);

            //displays the time in the format 00:00
            timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (timeLeft <= 0)
        {
            //clears the timer
            timerDisplay.text = "00:00";
        }
    }

    public void pauseTimer()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
    }

    public void resumeTimer()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
    }

}
