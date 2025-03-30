using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitialiser : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;

    [SerializeField]
    private GameObject playerPrefab;

    private PlayerConfiguration test;

    void Start()
    {
        //playerPrefab = prefab that was selected in PlayerSetUpMenuController

        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            playerPrefab = StaticData.PlayerPrefab[i];

            //Instantiate players at spawn point
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);  
            
            Debug.Log("player num: " + playerConfigs[i]);


        }
    }




}
