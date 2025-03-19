
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;
//using static UnityEditor.Progress;

public class AssignPowerUps : MonoBehaviour
{
    public int itemIdP1;
    public int itemIdP2;
    public Pickup[] powerUps;

    public AllPowerUps allPowerUps;



    void Start()
    {

        AssignScripts.assigner.assignPowerUps = gameObject;

    }

    public void Assign()
    {
        //adding to assign script

        List<int> itemIdlist = new List<int> { 0,1 };//list of number of powerups

        //Adding power ups to player 1s inventory
        //itemIdP1 = Random.Range(0, itemIdlist.Count);//picks random num
        itemIdP1 = 0;
        Debug.Log("itemIdP1: "+ itemIdP1);

        string result = " ";
        //foreach (var item in itemIdlist)
        //{
        //    Debug.Log("List: "+ item);

        //}

        switch (itemIdP1)
            {
                case 0:
                    Debug.Log("Extra damage powerup");
                powerUps[0].AddPowerUpP1();
                //itemIdlist.Remove(itemIdP1);//remove this option form the list

                break;

                case 1:
                    Debug.Log("Second power up");
                powerUps[1].AddPowerUpP1();
                itemIdlist.Remove(itemIdP1);//remove this option form the list

                break;

                case 2:
                    Debug.Log("Third power up");
                powerUps[2].AddPowerUpP1();

                break;
            }

        //foreach (var item in itemIdlist)
        //{
        //    result += item.ToString() + ", ";
        //}
        //Debug.Log("New List1: "+ result);


        //Adding power ups to player 2s inventory
        itemIdP2 = Random.Range(0, itemIdlist.Count);//picks random num
        //itemIdP2 = 0;
        Debug.Log("itemIdP2: "+ itemIdP2);

        itemIdlist.Remove(itemIdP2);//remove this option form the list

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
        }

        //string result2 = " ";

        //foreach (var item in itemIdlist)
        //{
        //    result2 += item.ToString() + ", ";
        //}
        //Debug.Log("New List2: "+ result2);




    }


}
