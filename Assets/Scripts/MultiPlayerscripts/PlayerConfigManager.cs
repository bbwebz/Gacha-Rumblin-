using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    public List<PlayerConfiguration> playerConfigs;
    [SerializeField]
    public int MaxPlayers = 2;//there is a max of 2 players at once

    public static PlayerConfigManager Instance { get; private set; }


    private void Awake()
    {

        if (Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }

    }


    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("player joined " + pi.playerIndex);
        pi.transform.SetParent(transform);

        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    //Setting player prefab
    //public void SetPlayerCharacter(int index, GameObject prefab, InputDevice device)
    public void SetPlayerCharacter(int index, GameObject prefab)
    {
        playerConfigs[index].PlayerPrefab = prefab;
        //playerConfigs[index].inputDevice = device ;
        //StaticData.PlayerPrefab.Add(prefab);
        StaticData.PlayerPrefab[index] = prefab;
    }

    //If both players clicked ready then load next scene
    //On ready buttons
    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("LevelSelect");//loead next scene when all players have clicked ready
        }
        Debug.Log("Player: " +  playerConfigs[index] + "is ready.");
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
        Debug.Log("PlayerConfiguration index: " + Input);
    }

    public PlayerInput Input { get; private set; }
    //public InputDevice inputDevice { get; set; }
    public int PlayerIndex { get; private set; }
    public bool isReady { get; set; }

    //Player Prefab that will me changed
    public GameObject PlayerPrefab { get; set; }



}