using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerController PlayerIdlePose;

    //private PlayerController player;

    private PlayerControls controls;

    private void Awake()
    {
        PlayerIdlePose = GetComponent<PlayerController>();
        controls = new PlayerControls();
    }

    //Sets player Sprite
    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;

        //set this instance of the player to this sprite
        //PlayerSprite comes from PlayerConfigManager
        PlayerIdlePose.idlePose = config.PlayerSprite;//seting idle pose
        //player.idlePose = config.PlayerSprite

        //config.Input.onActionTriggered += Input_onActionTriggered;
    }

    //private void Input_onActionTriggered(CallbackContext obj)
    //{
    //    if (obj.action.name == controls.Gameplay.Move.name)//gamplay is the contorl scheme of the player input actions
    //    {
    //        OnMove(obj);
    //    }
    //}

    //public void OnMove(CallbackContext context)
    //{
    //    //if (mover != null)
    //    //    mover.SetInputVector(context.ReadValue<Vector2>());
    //}

}
