using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class powerUpSlot : MonoBehaviour, IPointerClickHandler
{
    //Item info
    public string powerUpName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    //Item Slot
    [SerializeField]
    private UnityEngine.UI.Image itemImage;


    Inventory inventory;

    public void AddItem(string powerUpName, int quantity, Sprite itemSprite)
    {
       this.powerUpName = powerUpName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        itemImage.sprite = itemSprite;

        //inventory.UsePowerUp(powerUpName);
        //Debug.Log("item used!");



    }

    public void OnLeftClick()
    {
        inventory.UsePowerUp(powerUpName);
        Debug.Log("item used!");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) { 
        
            OnLeftClick();
        
        }
    }
}
