using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject CharacterSelectMenuPrefab;

    private GameObject rootMenu;
    private GameObject playerIN;
    private GameObject Position1;
    public PlayerInput input;

    private Transform[] MeuSpawn;

    public static InputDevice device1;
    public static InputDevice device2;


    private void Awake()
    {
        rootMenu = GameObject.FindGameObjectWithTag("MainLayout");
        if (rootMenu != null)
        {
            //create character select menu for each player
            var menu = Instantiate(CharacterSelectMenuPrefab, rootMenu.transform);

            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();

            menu.GetComponent<PlayerSetupMenuController>().setPlayerIndex(input.playerIndex);

            //int test = 0;
            int PlayerIndex = gameObject.GetComponent<PlayerInput>().playerIndex;//get player index


            if (PlayerIndex  == 0)
            {
                device1 = gameObject.GetComponent<PlayerInput>().devices[0];
                Debug.Log("player 1 device; " + device1);

            }
            else if (PlayerIndex == 1)
            {
                //Debug.Log("player 2");
                device2 = gameObject.GetComponent<PlayerInput>().devices[0];
                Debug.Log("player 2 device; " + device2);


            }


        }

    }




}