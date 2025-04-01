using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private GameObject player;

    private PlayerController mover;

    private PlayerControls controls;

    private void Awake()
    {
        //mover = GetComponent<PlayerController>();
        //controls = new PlayerControls();
    }

    //Sets player character
    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;

        //set this instance of the player to this sprite
      
        player = playerConfig.PlayerSprite;//setting  prefab
    }

    

  

}
