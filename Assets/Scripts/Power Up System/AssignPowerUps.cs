
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.EventSystems.EventTrigger;
//using static UnityEditor.Progress;
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

    public TextMeshProUGUI PowerUPDescriptionP1;
    public TextMeshProUGUI PowerUPDescriptionP2;



    void Start()
    {
        //AssignScripts.assigner.assignPowerUps = gameObject;

    }

    public void Generate()
    {
       


        //Generate power up for player 1
        //itemIdP1 = itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num

        //itemIdlist.Remove(itemIdP1);//remove this option form the list


        //Generate power up for player 2
        //itemIdP2 = itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num


       
        itemIdlist.Remove(itemIdP2);//remove this option form the list

        itemIdP1 = 1;
        StaticData.itemP1Keep = itemIdP1;
        itemIdP2 = 2;
        StaticData.itemP2Keep = itemIdP2;

        Debug.Log(" Generate function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        Debug.Log(" Generate Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);



    }


    public void DisplayOnMachine()
    {
        //Debug.Log("Start  Machine function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        //Debug.Log("  Start Machine Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);
        switch (itemIdP1)
        {
            case 0:
                Debug.Log("Extra damage powerup");
                powerUps[0].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Glass Canon: Do 2X the damage! Effect: Lose 1 Heart.";

                break;

            case 1:
                Debug.Log("Second power up");
                powerUps[1].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Beefed: Get an extra Heart! \n Effect: Cannot attack for 10 secs";

                break;

            case 2:
                Debug.Log("Third power up");
                powerUps[2].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Poker: Opponent cannot cause damage to you! \n Effect: You loose half a heart.";
                break;

            case 3:
                Debug.Log("Forth power up");
                powerUps[3].DisplayOnMachineP1();//speed
                PowerUPDescriptionP1.text = " 2 Die: You get extra Speed for 10secs! \n Effect: If you're hit you loose 2 Hearts.";
               

                break;

            case 4:
                Debug.Log("Fith power up");
                powerUps[4].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Snail: You do 4X the damage! Effect: If Hit you are much slower.";

                break;
        }


        switch (itemIdP2)
        {
            case 0:
                Debug.Log("Extra damage powerup");
                powerUps[0].DisplayOnMachineP2();
                PowerUPDescriptionP2.text = "Glass Canon: Do 2X the damage for 5 secs! \n Effect: Lose 1 Heart.";

                break;

            case 1:
                Debug.Log("Second power up");
                powerUps[1].DisplayOnMachineP2();
                PowerUPDescriptionP2.text = "Beefed: Get an extra Heart! \n Effect: Cannot attack for 10 secs.";

                break;

            case 2:
                Debug.Log("Third power up");
                powerUps[2].DisplayOnMachineP2();//shield
                PowerUPDescriptionP2.text = "Poker: Opponent cannot cause damage to you for 5 secs!  \n Effect: You loose half a heart ";

                break;

            case 3:
                Debug.Log("Forth power up");
                powerUps[3].DisplayOnMachineP2();//speed
                PowerUPDescriptionP2.text = "2 Die: You get extra Speed for 10secs! \n Effect: If you're hit you loose 2 Hearts. ";

                break;

            case 4:
                Debug.Log("Fith power up");
                powerUps[4].DisplayOnMachineP2();
                PowerUPDescriptionP2.text = "Snail: You do 4X the damage! Effect: If Hit you are much slower.";

                break;
        }
        //Debug.Log(" Machine function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        //Debug.Log(" Machine Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);

    }



    public void Assign()
    {
        //adding to assign script

        //Adding power ups to player 1s inventory
        //itemIdP1 = 3;
        //Debug.Log("itemIdP1: "+ itemIdP1);

        //Debug.Log(" Assign function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        //Debug.Log(" Asssign Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);


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


        //Debug.Log("itemIdP2: "+ itemIdP2);


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
