using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI timerDisplay;
    float gameTime = 1 * 60 + 1; //1 minutes converted to seconds (240 seconds)
    public float timeLeft;
    bool isGamePaused =  false;
    PlayerControls controls;
    public GameObject PauseMenu;

    public PlayerController playerControllerAccess;


    private void Awake()
    {
        controls = new PlayerControls();
    }

    void Start()
    {
        timeLeft = gameTime;
        controls.Gameplay.Enable();
        controls.Gameplay.PauseGame.performed += OnPause;
        isGamePaused = false;

    }

    void Update()
    {
        if (playerControllerAccess.PlayerIndex == 1 && playerControllerAccess.PlayerIndex == 2) //both players have been spawned in
        {
            Debug.Log("timer has now started");
            timeLeft = gameTime; //start the timer once both players instantiate
        }
        else
        {
            Debug.Log("timer has NOT started yet");
        }

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


        if(timeLeft == 0)
        {
            SceneManager.LoadScene("EndGame");
        }

    }

    public void resumeTimer()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
    public void pauseTimer()
    {
        Debug.Log("you pressed pause");
        isGamePaused = true;
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        pauseTimer();
    }
}
