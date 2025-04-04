using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelInitialiser : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;

    [SerializeField]
    private GameObject playerPrefab;

    public PlayerInputManager playerInputManager;



    void Start()
    {
        Debug.Log("start");

        //playerPrefab = prefab that was selected in PlayerSetUpMenuController

        //InputDevice test2 = playerPrefab.GetComponent<PlayerInput>().SwitchCurrentActionMap(Gamepad.all[1]);


        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
           
            playerPrefab = StaticData.PlayerPrefab[i];

            //if playerprefab .playerindex = 0
            //then i = 0

            //Instantiate players at spawn point

            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);

            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);



        }
    }




}
