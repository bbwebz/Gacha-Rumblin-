using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int playerIndex;

    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;

    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;



    
    public void setPlayerIndex(int pi)
    {
        playerIndex = pi;
        titleText.SetText("Player " + (pi + 1).ToString());//Displayer Player 1 or 2 depending on Index
        ignoreInputTime = Time.time + ignoreInputTime;
        if (playerIndex == 1)
        {
            menuPanel.transform.localPosition = new Vector3(-633, -12, 0);//position of character select menu
            menuPanel.transform.localScale = new Vector3(-1, 1, 1);//Flip on x Axis via scale

            readyPanel.transform.localPosition = new Vector3(-633, -12, 0);//position of ready button

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    //Will set character/colour of player
    public void SelectCharcater(GameObject IdlePose)
    {
        if (!inputEnabled) { return; }

        PlayerConfigManager.Instance.SetPlayerCharacter(playerIndex, IdlePose);//set player sprite

        Debug.Log("prefab: " + IdlePose + ", playerIndex: " + playerIndex);

        readyPanel.SetActive(true);//turn on ready panel
        readyButton.interactable = true;//turn on ready button
        menuPanel.SetActive(false);//turn off character select menu
        readyButton.Select();//when both players choose select

    }

    //Gets players to press ready button to continue to next scene
    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }

        PlayerConfigManager.Instance.ReadyPlayer(playerIndex);
        readyButton.gameObject.SetActive(false);

        Debug.Log("Player " + playerIndex + "is ready.");
    }
}