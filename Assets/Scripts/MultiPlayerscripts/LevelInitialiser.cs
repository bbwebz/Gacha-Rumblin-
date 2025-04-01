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


    void Start()
    {
        Debug.Log("start");

        //playerPrefab = prefab that was selected in PlayerSetUpMenuController

        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            Debug.Log("for loop");

           
            playerPrefab = StaticData.PlayerPrefab[i];

            //Instantiate players at spawn point
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            //int index = playerPrefab.GetComponent<PlayerInput>().user.;
            //Debug.Log("player index: " + index);

            //playerPrefab.GetComponent<PlayerInput>().devices[0].;
            //gamepad.all get index
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);  
            


        }
    }




}
