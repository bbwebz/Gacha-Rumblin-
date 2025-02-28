using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI timerDisplay;
    float gameTime = 4 * 60 + 1; // 4 minutes converted to seconds (240 seconds)
    float timeLeft; 

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = gameTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
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
        else
        {
            //clears the timer
            timerDisplay.text = "00:00";
        }
    }
}
