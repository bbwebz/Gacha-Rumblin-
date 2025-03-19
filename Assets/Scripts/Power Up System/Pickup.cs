using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Inventory of player 1
    [SerializeField]
    public InventoryP1 inventoryP1;
    public InventoryP1 inventoryP2;
    //Power up button
    public GameObject powerUpButton;

    public GameObject ButtonClone;


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
                Debug.Log("button" + powerUpButton);
                //power up can go to inventory
                inventoryP1.isFull[i] = true;
                ButtonClone = Instantiate(powerUpButton, inventoryP1.slots[i].transform, false);
                Debug.Log("instantiated");
                break;
            }

        }


    }




    public void AddPowerUpP2()
    {

        Debug.Log("into slot");
        Debug.Log(inventoryP2.slots.Length);

        for (int i = 0; i < inventoryP2.slots.Length; i++)
        {

            //if there is an empty slot
            if (inventoryP2.isFull[i] == false)
            {
                Debug.Log("into true");
                Debug.Log("button" + powerUpButton);
                //power up can go to inventory
                inventoryP2.isFull[i] = true;
                ButtonClone = Instantiate(powerUpButton, inventoryP2.slots[i].transform, false);
                Debug.Log("instantiated");
                break;
            }

        }


    }



}
