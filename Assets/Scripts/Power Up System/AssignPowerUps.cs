using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class AssignPowerUps : MonoBehaviour
{
    private int itemId;
    public Pickup powerUp1;
    public Pickup powerUp2;
    public Pickup powerUp3;




    void Start()
    {
        //itemId = Random.Range(1, 4);//numbers from 1-3
        itemId = 1;
        Debug.Log("num: "+ itemId);

        switch (itemId)
            {
                case 1:
                    Debug.Log("Extra damage powerup");
                powerUp1.AddToInventory();
                    break;

                case 2:
                    Debug.Log("Second power up");
                powerUp2.AddToInventory();
                    break;

                case 3:
                    Debug.Log("Third power up");
                    break;
            }
        
    }

    // Update is called once per frame
    void Update()
    {
       

        //if id = 1
        //run pickup script of extra damage
        
    }
}
