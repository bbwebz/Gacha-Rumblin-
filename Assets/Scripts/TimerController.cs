using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI timerDisplay;
    float elapsedTime;
    float gameTime = 4; //4 minutes gameplay

    // Update is called once per frame
    void Update()
    {
        if(elapsedTime < gameTime) {             
            elapsedTime += Time.deltaTime; //calculates all of the time passed since game started
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            //formats the minutes and seconds to display as 00:00
            timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
            //elapsedTime = 0;
            //timerDisplay.text = "00:00";
        }

    }
}
