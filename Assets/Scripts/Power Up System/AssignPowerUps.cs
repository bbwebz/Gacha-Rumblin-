
using System.Collections.Generic;
using System.Linq;
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

        //Debuging
        //List<int> itemIdlist = new List<int> { 0, 1 };//list of number of powerups

        //string result0 = " ";

        //foreach (var item in itemIdlist)
        //{
        //    result0 += item.ToString() + ", ";
        //}
        //Debug.Log("OG List: "+ result0);


        //itemIdP1 = Random.Range(0, itemIdlist.Count);//picks random num
        //Debug.Log("itemIdP1: "+ itemIdP1);

        //itemIdlist.Remove(itemIdP1);


        //string result = " ";

        //foreach (var item in itemIdlist)
        //{
        //    result += item.ToString() + ", ";
        //}
        //Debug.Log("New List1: "+ result);

        //itemIdP2 = Random.Range(0, itemIdlist.Count);//picks random num
        //Debug.Log("itemIdP2: "+ itemIdP2);

        //string result2 = " ";

        //foreach (var item in itemIdlist)
        //{
        //    result2 += item.ToString() + ", ";
        //}
        //Debug.Log("New List2: "+ result2);

    }

    public void Assign()
    {
        //adding to assign script

        List<int> itemIdlist = new List<int> { 0,1, 2, 3, 4 };//list of number of powerups

        //Adding power ups to player 1s inventory
        itemIdP1 = Random.Range(0, itemIdlist.Count);//picks random num
        //itemIdP1 = 3;
        Debug.Log("itemIdP1: "+ itemIdP1);

        //string result = " ";
        //foreach (var item in itemIdlist)
        //{
        //    Debug.Log("List: "+ item);

        //}

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


        //foreach (var item in itemIdlist)
        //{
        //    result += item.ToString() + ", ";
        //}
        //Debug.Log("New List1: "+ result);


        //Adding power ups to player 2s inventory
        itemIdP2 = Random.Range(0, itemIdlist.Count);//picks random num
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

        //string result2 = " ";

        //foreach (var item in itemIdlist)
        //{
        //    result2 += item.ToString() + ", ";
        //}
        //Debug.Log("New List2: "+ result2);




    }


}
