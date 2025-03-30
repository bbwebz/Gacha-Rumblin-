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
    private int MaxPlayers = 2;//there is a max of 2 players at once


    public static PlayerConfigManager Instance { get; private set; }


    ////Testin with vid
    //[SerializeField]
    //private PlayerConfiguration[] charcaters;
    //[SerializeField]
    //public PlayerConfiguration currentCharacter;
    //public static PlayerConfigManager Instance { get;  set; }

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

    //public void SetPlayerSprite(int index, Sprite sprite)
    public void SetPlayerCharacter(int index, GameObject sprite)
    {
        playerConfigs[index].PlayerSprite = sprite;
        StaticData.PlayerPrefab.Add(sprite);
    }

    //If both players clicked ready then load next scene
    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("Level_1");//loead next scene when all players have clicked ready
        }
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
    public int PlayerIndex { get; private set; }
    public bool isReady { get; set; }

    //Player sprite that will me changed
    //public GameObject playerPrefab{get;set};
    public GameObject PlayerSprite { get; set; }


    ////Charcater options lsit

    //public GameObject ChracterPrefab;
    //public string name;
    //public Sprite CharcaterIcon;



}
