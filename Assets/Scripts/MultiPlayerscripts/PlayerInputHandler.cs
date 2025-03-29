using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerController mover;

    [SerializeField]
    private SpriteRenderer playerMesh;

    private PlayerControls controls;

    private void Awake()
    {
        mover = GetComponent<PlayerController>();
        controls = new PlayerControls();
    }

    //Sets player material
    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        playerMesh.material = config.playerMaterial;
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
