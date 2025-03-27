
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
    public  int itemIdP1;
    public  int itemIdP2;
    public Pickup[] powerUps;

    //public static int itemP1Keep;
    //public static int itemP2Keep;

    public AllPowerUps allPowerUps;
    List<int> itemIdlist = new List<int> { 0, 1, 2, 3, 4 };//list of number of powerups



    void Start()
    {
        //AssignScripts.assigner.assignPowerUps = gameObject;

        string result0 = " ";

        foreach (var item in itemIdlist)
        {
            result0 += item.ToString() + ", ";
        }
        Debug.Log("OG List: "+ result0);

    }

    public void Generate()
    {
        itemIdP1 = Random.Range(0, itemIdlist.Count);//picks random num
        StaticData.itemP1Keep = itemIdP1;


    itemIdlist.Remove(itemIdP1);//remove this option form the list

        //Generate power up for player 2
        itemIdP2 = Random.Range(0, itemIdlist.Count);//picks random num

        StaticData.itemP2Keep = itemIdP2;


        itemIdlist.Remove(itemIdP2);//remove this option form the list
       
 

}


public void DisplayOnMachine()
    {
        switch (itemIdP1)
        {
            case 0:
                Debug.Log("Extra damage powerup");
                powerUps[0].DisplayOnMachineP1();

                break;

            case 1:
                Debug.Log("Second power up");
                powerUps[1].DisplayOnMachineP1();

                break;

            case 2:
                Debug.Log("Third power up");
                powerUps[2].DisplayOnMachineP1();
                break;

            case 3:
                Debug.Log("Forth power up");
                powerUps[3].DisplayOnMachineP1();
                break;

            case 4:
                Debug.Log("Fith power up");
                powerUps[4].DisplayOnMachineP1();
                break;
        }


        switch (itemIdP2)
        {
            case 0:
                Debug.Log("Extra damage powerup");
                powerUps[0].DisplayOnMachineP2();

                break;

            case 1:
                Debug.Log("Second power up");
                powerUps[1].DisplayOnMachineP2();

                break;

            case 2:
                Debug.Log("Third power up");
                powerUps[2].DisplayOnMachineP2();
                break;

            case 3:
                Debug.Log("Forth power up");
                powerUps[3].DisplayOnMachineP2();
                break;

            case 4:
                Debug.Log("Fith power up");
                powerUps[4].DisplayOnMachineP2();
                break;
        }

    }



    public void Assign()
    {
        //adding to assign script

        //Adding power ups to player 1s inventory
        //itemIdP1 = 3;
        Debug.Log("itemIdP1: "+ itemIdP1);

       

        switch (StaticData.itemP1Keep)
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


        Debug.Log("itemIdP2: "+ itemIdP2);


        switch (StaticData.itemP2Keep)
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
