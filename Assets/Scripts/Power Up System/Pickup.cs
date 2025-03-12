using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   //Inventory of player 1
    public InventoryP1 inventoryP1;
    //Power up button
    public GameObject powerUpButton;


    void Start()
    {
        //inventoryP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<InventoryP1>();
    }


   public void AddPowerUp()
    {
        Debug.Log("into slot");

        for (int i = 0; i < inventoryP1.slots.Length; i++)
        {

            //if there is an empty slot
            if (inventoryP1.isFull[i] == false)
            {
                Debug.Log("into true");
                //power up can go to inventory
                inventoryP1.isFull[i] = true;
                Instantiate(powerUpButton, inventoryP1.slots[i].transform, false);
                break;
            }

        }


    }



}
