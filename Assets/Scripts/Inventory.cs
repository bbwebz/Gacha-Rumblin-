using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public GameObject InventoryBox;
    public powerUpSlot[] itemSlot;



    public void AddItem(string itemName, int quantity, Sprite image)
    {
        Debug.Log("itemName: " + itemName + "quantity: " + quantity + "sprite:" + image);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, image);//add item to inventory if not already full
                return;
            }
        }
    
    }







}
