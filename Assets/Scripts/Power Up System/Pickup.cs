using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite image;

    public Inventory inventoryManager;

    private void Start()
    {

    }


    public void AddToInventory()
    {
        inventoryManager.AddItem(itemName, quantity, image);
        Debug.Log(itemName +"added to inventory");

    }

}
