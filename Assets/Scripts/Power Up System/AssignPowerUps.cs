
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class AssignPowerUps : MonoBehaviour
{
    private int itemId;
    public Pickup powerUp1;
    public Pickup powerUp2;
    public Pickup powerUp3;

    public AllPowerUps allPowerUps;

    public void Assign()
    {
        //adding to assign script
        AssignScripts.assigner.assignPowerUps = gameObject;
        //int[] itemIdlist = {0,1,2,3 };

        List<int> itemIdlist = new List<int> { 1, 2, 3, 4, 5 };

         itemId = Random.Range(0, itemIdlist.Count);//numbers from 1-3
         //itemId = 1;
        Debug.Log("num: "+ itemId);
       
            switch (itemId)
            {
                case 1:
                    Debug.Log("Extra damage powerup");
                    powerUp1.AddPowerUp();
                    powerUp1.powerUpButton.GetComponent<Button>().Select();//auto selcts this button
                    break;

                case 2:
                    Debug.Log("Second power up");
                    powerUp2.AddPowerUp();
                powerUp1.powerUpButton.GetComponent<Button>().Select();//auto selcts this button

                break;

                case 3:
                    Debug.Log("Third power up");
                    break;
            }

    }

   
}
