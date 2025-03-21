
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEditor.Progress;
//using static UnityEditor.Progress;

public class AssignPowerUps : MonoBehaviour
{
    public int itemIdP1;
    public int itemIdP2;
    public Pickup[] powerUps;


    void Start()
    {
        AssignScripts.assigner.assignPowerUps = gameObject;

    }

    public void Assign()
    {
        //adding to assign script

        List<int> itemIdlist = new List<int> { 0,1, 2, 3, 4 };//list of number of powerups

        //Adding power ups to player 1s inventory
        itemIdP1 =itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num
        //itemIdP1 = 3;
        Debug.Log("itemIdP1: "+ itemIdP1);


        switch (itemIdP1)
            {
                case 0:
                    Debug.Log("Extra damage powerup");
                powerUps[0].AddPowerUpP1();

                break;

                case 1:
                    Debug.Log("Second power up");
                powerUps[1].AddPowerUpP1();

                break;

                case 2:
                    Debug.Log("Third power up");
                powerUps[2].AddPowerUpP1();
                break;

                case 3:
                Debug.Log("Forth power up");
                powerUps[3].AddPowerUpP1();
                break;

                case 4:
                Debug.Log("Fith power up");
                powerUps[4].AddPowerUpP1();
                break;
        }
        itemIdlist.Remove(itemIdP1);//remove this option form the list


        //Adding power ups to player 2s inventory
        itemIdP2 = itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num
        //itemIdP2 = 1;
        Debug.Log("itemIdP2: "+ itemIdP2);


        switch (itemIdP2)
        {
            case 0:
                Debug.Log("Extra damage powerup");
                powerUps[0].AddPowerUpP2();
                break;

            case 1:
                Debug.Log("Second power up");
                powerUps[1].AddPowerUpP2();
                break;

            case 2:
                Debug.Log("Third power up");
                powerUps[2].AddPowerUpP2();
                break;

            case 3:
                Debug.Log("Forth power up");
                powerUps[3].AddPowerUpP2();
                break;

            case 4:
                Debug.Log("Fith power up");
                powerUps[4].AddPowerUpP2();
                break;
        }

      




    }


}
