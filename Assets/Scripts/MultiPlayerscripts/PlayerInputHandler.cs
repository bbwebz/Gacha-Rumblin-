using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private GameObject PlayerIdlePose;

    //private PlayerController player;

    private PlayerControls controls;

    private void Awake()
    {
        //PlayerIdlePose.GetComponent<PlayerController>();
        //controls = new PlayerControls();
    }

    //Sets player character
    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;

        //set this instance of the player to this sprite
      
        PlayerIdlePose = playerConfig.PlayerSprite;//seting idle pose

    }

  

}
