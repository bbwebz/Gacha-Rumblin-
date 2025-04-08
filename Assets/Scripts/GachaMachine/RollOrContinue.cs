using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RollOrContinue : MonoBehaviour
{
   private bool Player1Continue = false;
   private bool Player2Continue = false;

    [SerializeField]
    private Button RollAgainButton;


    public AssignPowerUps assignNewPowerUps;


    public GameObject CanvasOfButtons ;

    private void Update()
    {
        if (Player1Continue == true && Player2Continue == true)
        {
            SceneManager.LoadScene("Level_1");
        }
    }

    public void OnContinueClick()
    {
        if (gameObject.GetComponent<PlayerInput>().playerIndex == 0)
        {
            Player1Continue = true;
        }
        else if (gameObject.GetComponent<PlayerInput>().playerIndex == 1)
        {
            Player2Continue = true;
        }
    }

    public void OnRollAgainClick()
    {
        if (gameObject.GetComponent<PlayerInput>().playerIndex == 0)
        {
            assignNewPowerUps.ReGenerateP1();
            RollAgainButton.interactable = false;
            //CanvasOfButtons.
        }
        else if (gameObject.GetComponent<PlayerInput>().playerIndex == 1)
        {
            assignNewPowerUps.ReGenerateP2();
            RollAgainButton.interactable = false;

        }

    }







}
