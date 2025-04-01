using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject CharacterSelectMenuPrefab;

    private GameObject rootMenu;
    private GameObject Position1;
    public PlayerInput input;

    private Transform[] MeuSpawn;


    private void Awake()
    {
        rootMenu = GameObject.FindGameObjectWithTag("MainLayout");
        if (rootMenu != null)
        {
            //create character select menu for each player
            var menu = Instantiate(CharacterSelectMenuPrefab, rootMenu.transform);

            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();

            menu.GetComponent<PlayerSetupMenuController>().setPlayerIndex(input.playerIndex);
        }

    }




}
