using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerInput indexPlayer;


    private GameObject player;


    //Sets player character
    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        //set this instance of the player to this sprite
        player = playerConfig.PlayerPrefab;//setting  prefab
    }

    

  

}
