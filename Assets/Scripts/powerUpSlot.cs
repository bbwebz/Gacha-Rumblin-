using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUpSlot : MonoBehaviour
{
    //Item info
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    //Item Slot
    [SerializeField]
    private UnityEngine.UI.Image itemImage;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
       this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        itemImage.sprite = itemSprite;


    }






}
