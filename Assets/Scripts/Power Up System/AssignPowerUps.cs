using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
//using static UnityEditor.Progress;

public class AssignPowerUps : MonoBehaviour
{
    private int itemId;
    public Pickup powerUp1;
    public Pickup powerUp2;
    public Pickup powerUp3;


    private int NumOfP2;


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        NumOfP2 = GameObject.FindGameObjectsWithTag("Player2").Length;
        //itemId = Random.Range(1, 4);//numbers from 1-3
        itemId = 1;
        Debug.Log("num: "+ itemId);
        if (NumOfP2 == 1)//if there is one prefab with the tag of player2 then you can start adding player health as parameter
        {
            switch (itemId)
            {
                case 1:
                    Debug.Log("Extra damage powerup");
                    powerUp1.AddPowerUp();
                    break;

                case 2:
                    Debug.Log("Second power up");
                    powerUp2.AddPowerUp();
                    break;

                case 3:
                    Debug.Log("Third power up");
                    break;
            }
        }
    }
}
