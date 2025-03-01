using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    private Inventory inventory;
    public GameObject powerUpIcon;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player1").GetComponent<Inventory>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player1"))
    //    {

    public void AddToInventory()
    {
        for (int i = 0; i<inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                //Powerup can be added to inventory
                inventory.isFull[i] = true;

                //Makes the icon apear in the inventory box
                Instantiate(powerUpIcon, inventory.slots[i].transform, false);//false so that i doesnt go to world coordinates and stay in UI
                Debug.Log("Inventory item name:");
                //Destroy(GameObject);
                break;
            }
        }




    }

}
