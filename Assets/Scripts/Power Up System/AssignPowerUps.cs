
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
         itemIdlist = new List<int> { 0, 1, 2, 3, 4 };//list of number of powerups


    }

    //Called at the start of each round in gacha machine screen
    public void Generate()
    {

        //List<int> itemIdlist = new List<int> { 0, 1, 2, 3, 4 };//list of number of powerups

        //Generate power up for player 1
        itemIdP1 = itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num

        itemIdlist.Remove(itemIdP1);//remove this option form the list


        //Generate power up for player 2
        itemIdP2 = itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num


        itemIdlist.Remove(itemIdP2);//remove this option form the list

        //itemIdP1 = 1;
        StaticData.itemP1Keep = itemIdP1;
        //itemIdP2 = 0;
        StaticData.itemP2Keep = itemIdP2;

        //Debug.Log(" Generate function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        //Debug.Log(" Generate Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);





    }

    // --------------- Re Run powerUp assign function if player clicks button to do so ----------------------
    public void ReGenerateP1()
    {

        //Generate power up for player 1
        itemIdP1 = itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num

        itemIdlist.Remove(itemIdP1);//remove this option form the list

        //itemIdP1 = 1;
        StaticData.itemP1Keep = itemIdP1;
        Debug.Log("Reassign PowerUp  numer: " + StaticData.itemP1Keep);


        //Debug.Log(" Generate function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        //Debug.Log(" Generate Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);
    }

    public void ReGenerateP2()
    {

        //Generate power up for player 2
        itemIdP2 = itemIdlist[Random.Range(0, itemIdlist.Count)];//picks random num

        itemIdlist.Remove(itemIdP2);//remove this option form the list

        //itemIdP2 = 1;
        StaticData.itemP1Keep = itemIdP1;

        Debug.Log(" Generate function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        Debug.Log(" Generate Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);
    }
    //--------------------------------------------------------------------------------------------------//



    public void DisplayOnMachine()
    {
        //Debug.Log("Start  Machine function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        //Debug.Log("  Start Machine Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);
        switch (itemIdP1)
        {
            case 0:
                Debug.Log("Extra damage powerup");
                powerUps[0].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Glass Canon\n Do 2X the damage! Effect: Lose 1 Heart.";

                break;

            case 1:
                Debug.Log("Second power up");
                powerUps[1].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Beefed\n Get an extra Heart!\nEffect: Cannot attack for 10 secs";

                break;

            case 2:
                Debug.Log("Third power up");
                powerUps[2].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Poker\nOpponent cannot cause damage to you!\n Effect: You loose half a heart.";
                break;

            case 3:
                Debug.Log("Forth power up");
                powerUps[3].DisplayOnMachineP1();//speed
                PowerUPDescriptionP1.text = " 2 Die\nYou get extra Speed for 10secs!\nEffect: If you're hit you loose 2 Hearts.";
               

                break;

            case 4:
                Debug.Log("Fith power up");
                powerUps[4].DisplayOnMachineP1();
                PowerUPDescriptionP1.text = "Snail\nYou do 4X the damage!\nEffect: If Hit you are much slower.";

                break;
        }


        switch (itemIdP2)
        {
            case 0:
                Debug.Log("Extra damage powerup");
                powerUps[0].DisplayOnMachineP2();
                PowerUPDescriptionP2.text = "Glass Canon\n Do 2X the damage for 5 secs!\n Effect: Lose 1 Heart.";

                break;

            case 1:
                Debug.Log("Second power up");
                powerUps[1].DisplayOnMachineP2();
                PowerUPDescriptionP2.text = "Beefed\n Get an extra Heart!\nEffect: Cannot attack for 10 secs.";

                break;

            case 2:
                Debug.Log("Third power up");
                powerUps[2].DisplayOnMachineP2();//shield
                PowerUPDescriptionP2.text = "Poker\n Opponent cannot cause damage to you for 5 secs!\n Effect: You loose half a heart ";

                break;

            case 3:
                Debug.Log("Forth power up");
                powerUps[3].DisplayOnMachineP2();//speed
                PowerUPDescriptionP2.text = "2 Die\nYou get extra Speed for 10secs!\nEffect: If you're hit you loose 2 Hearts. ";

                break;

            case 4:
                Debug.Log("Fith power up");
                powerUps[4].DisplayOnMachineP2();
                PowerUPDescriptionP2.text = "Snail\n You do 4X the damage!\nEffect: If Hit you are much slower.";

                break;
        }
        //Debug.Log(" Machine function StaticData.itemP1Keep" +  StaticData.itemP1Keep);
        //Debug.Log(" Machine Function StaticData.itemP2Keep" +  StaticData.itemP2Keep);

    }


    //assign to player on level screen
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
        Debug.Log(" Assign PowerUp  numer: " + StaticData.itemP1Keep);


        //Debug.Log("itemIdP2: "+ itemIdP2);


        /* switch (StaticData.itemP2Keep)
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
         }*/






    }

    public void AssignP2()
    {
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
