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

    private Inventory inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryBox").GetComponent<Inventory>();
    }


    public void AddToInventory()
    {
        inventoryManager.AddItem(itemName, quantity, image);

    }

}
