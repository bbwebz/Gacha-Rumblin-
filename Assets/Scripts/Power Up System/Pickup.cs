using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Inventory of player 1 and 2
    public InventoryP1 inventoryP1;
    public InventoryP1 inventoryP2;

    //Display places for gacha machine
    public DisplayItemSlot Player1Machine;
    public DisplayItemSlot Player2Machine;

    //Power up button
    public GameObject powerUpIcon;

    public GameObject IconClone;


    void Start()
    {
        //inventoryP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<InventoryP1>();
    }


   public void AddPowerUpP1()
    {

        Debug.Log("into slot");
        for (int i = 0; i < inventoryP1.slots.Length; i++)
        {

            //if there is an empty slot
            if (inventoryP1.isFull[i] == false)
            {
                Debug.Log("into true");
                Debug.Log("button" + powerUpIcon);
                //power up can go to inventory
                inventoryP1.isFull[i] = true;
                IconClone = Instantiate(powerUpIcon, inventoryP1.slots[i].transform, false);
                Debug.Log("instantiated");
                break;
            }

        }


    }


    public void AddPowerUpP2()
    {

        Debug.Log("into slot");

        for (int i = 0; i < inventoryP2.slots.Length; i++)
        {

            //if there is an empty slot
            if (inventoryP2.isFull[i] == false)
            {
                Debug.Log("into true");
                Debug.Log("button" + powerUpIcon);
                //power up can go to inventory
                inventoryP2.isFull[i] = true;
                IconClone = Instantiate(powerUpIcon, inventoryP2.slots[i].transform, false);
                Debug.Log("instantiated");
                break;
            }

        }


    }


    public void DisplayOnMachineP1()
    {
        Debug.Log("into slot Machine");

        for (int i = 0; i < Player1Machine.slots.Length; i++)
        {

            //if there is an empty slot
            if (Player1Machine.isFull[i] == false)
            {
                Debug.Log("into machine true");
                Debug.Log("Machine power button" + powerUpIcon);
                //power up can go to inventory
                Player1Machine.isFull[i] = true;
                IconClone = Instantiate(powerUpIcon, Player1Machine.slots[i].transform, false);
                Debug.Log("Machine instantiated");
                break;
            }

        }
    }

    public void DisplayOnMachineP2()
    {
        Debug.Log("into slot Machine");

        for (int i = 0; i < Player2Machine.slots.Length; i++)
        {

            //if there is an empty slot
            if (Player2Machine.isFull[i] == false)
            {
                Debug.Log("into machine true");
                Debug.Log("Machine power button" + powerUpIcon);
                //power up can go to inventory
                Player2Machine.isFull[i] = true;
                IconClone = Instantiate(powerUpIcon, Player2Machine.slots[i].transform, false);
                Debug.Log("Machine instantiated");
                break;
            }

        }
    }


















}
