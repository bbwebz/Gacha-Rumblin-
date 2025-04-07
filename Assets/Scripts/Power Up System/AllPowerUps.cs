using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//using static UnityEditorInternal.ReorderableList;
using static UnityEngine.InputSystem.HID.HID;


public class AllPowerUps : MonoBehaviour
{

    public Player1Health Player1HealthAccess;
    public Player2Health Player2HealthAccess;
    public PlayerController Player1ControllerAccess;
    public PlayerController Player2ControllerAccess;

    //public Pickup[] powerUps;
    public AssignPowerUps assignPowerUps;


    public InventoryP1 Inventory1;
    public InventoryP1 Inventory2;

    //Overlays
    public GameObject PhysicalShieldSprite;
    public GameObject PhysicalShieldClone;




    //------------------------ Glass Canon ---------------------------------
    //On button clicked use powerUp
    // id = 0
    public void Start()
    {
        AssignScripts.assigner.AllPowerUpsAccess = gameObject;

    }


    //Glass canon
    //Id = 0
    //Loose 1 health but can do double the damage
    public void UseGlassCanon(int playerNum)//activate power up
        //recieve player number and pass it to IEnumerator
    {
            StartCoroutine(GlassCanonSequence(playerNum));
            Debug.Log("GlassCanon used");
    }

  
    IEnumerator GlassCanonSequence(int playerNum)
    {
        float duration = 5;
       Debug.Log("Decrease Health power up");
        //if(int playerNum == 1) 
        if (playerNum == 1)//If player 1 has the power up and is using it
        {
            Player1HealthAccess.health -= 1;//take away 1 health from p1
            Player1HealthAccess.Player1DamageAmount += 1;//Player 1 can now do an extra amount of damage

            Debug.Log("Player 1 damage amount: " + Player1HealthAccess.Player1DamageAmount);

            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.647f, 0f); //orange

            //PowerUpOverlaysClone = Instantiate(PowerUpOverlays, Player1ControllerAccess.transform, false);//Instantiate shield on top of player


            Destroy(assignPowerUps.powerUps[0].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateGlassCanon(playerNum);//deactivate power up

        }
        else if (playerNum == 2)//If player 2 has the power up and is using it
        {
            Player2HealthAccess.health -= 1;//take away 1 health form p2
            Player2HealthAccess.Player2DamageAmount += 1;//Player 2 can now do an extra amount of damage

            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.647f, 0f); //orange


            //Player2Colour.material.color = Color.gray;//Change player colour

            //PowerUpOverlaysClone = Instantiate(PowerUpOverlays, Player2ControllerAccess.transform, false);//Instantiate shield on top of player


            Destroy(assignPowerUps.powerUps[0].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateGlassCanon(playerNum);//deactivate power up


        }


    }


    //Deactivates any buffs given to the player
    private void DeactivateGlassCanon(int playerNum)
    {
        //return damage that player can do back to normal
        if (playerNum == 1)
        {
            Player1HealthAccess.Player1DamageAmount = 0.5f;
            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (playerNum == 2) {
            //set player damage amount back to normal
            Player2HealthAccess.Player2DamageAmount = 0.5f;
            //set plyer colours back to normal
            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        Debug.Log("deactivated Glass Canon");
    }



    //------------------------ Beefed ---------------------------------
    // id = 1
    public void UseBeefed(int playerNum)//activate power up
    {
        StartCoroutine(BeefedSequence(playerNum));
        Debug.Log("Beefed used");
    }
    //+1 health, can do no damage

    IEnumerator BeefedSequence(int playerNum)
    {
        Debug.Log("Beefed PowerUp");

        float duration = 10;
        if (playerNum == 1)//If player 1 has the power up and is using it
        {
            if (Player1HealthAccess.health < 5)// add 1 health to p1 if health is < 5
            {
                Player1HealthAccess.health += 1;
                Debug.Log("increase player 2 health");
            }

            Player1HealthAccess.Player1DamageAmount = 0;//Player 1 can now do less damage

            Debug.Log("Player 1 damage amount: " + Player1HealthAccess.Player1DamageAmount);

            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.red;


            Destroy(assignPowerUps.powerUps[1].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateBeefed(playerNum);//deactivate power up

        }
        else if (playerNum == 2)//If player 2 has the power up and is using it
        {
            if (Player2HealthAccess.health < 5)// add 1 health to p2 if health is < 5
            {
                Debug.Log("increase player 2 health");
                Player2HealthAccess.health += 1;
            }
            Player2HealthAccess.Player2DamageAmount = 0;///Player 2 can now do less damage
            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.red;


            Destroy(assignPowerUps.powerUps[1].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateBeefed(playerNum);//deactivate power up


        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateBeefed(int playerNum)
    {
        //return damage that player can do back to normal
        if (playerNum == 1)
        {
            Player1HealthAccess.Player1DamageAmount = 0.5f;
            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (playerNum == 2)
        {
            //set player damage amount back to normal
            Player2HealthAccess.Player2DamageAmount = 0.5f;
            //set plyer colours back to normal
            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        Debug.Log("deactivate Beefed");

    }




    //------------------------ Shield ---------------------------------
    //Blocks attacks for  5 seconds but player cannot do dammage
    // id = 2
    public void UseShield(int playerNum)//activate power up
    {
        StartCoroutine(ShieldSequence(playerNum));
        Debug.Log("Shield used");
    }


    IEnumerator ShieldSequence(int playerNum)
    {
        Debug.Log("Shield PowerUp");

        float duration = 5;
        
        if (playerNum == 1)//If player 1 has the power up and is using it
        {
            //Will probably change it to be a barrier around player idk
            Player2HealthAccess.Player2DamageAmount = 0;//Disable Player 2's ability to do damage

            Debug.Log("Player 1 damage amount: " + Player1HealthAccess.Player1DamageAmount);
            Player1HealthAccess.health  -= 1;


            PhysicalShieldClone = Instantiate(PhysicalShieldSprite, Player1ControllerAccess.gameObject.transform, false);//Instantiate shield on top of player
            //PowerUpOverlaysClone.GetComponent<SpriteRenderer>().color = Color.cyan;

            Destroy(assignPowerUps.powerUps[2].IconClone);//destroy power up button of the  item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateShield(playerNum);//deactivate power up

        }
        else if (playerNum == 2)//If player 2 has the power up and is using it
        {
            Player1HealthAccess.Player1DamageAmount = 0;///Disable Player 1's ability to do damage

            PhysicalShieldClone = Instantiate(PhysicalShieldSprite, Player2ControllerAccess.gameObject.transform, false);//Instantiate shield on top of player
            Player2HealthAccess.health  -= 1;


            Destroy(assignPowerUps.powerUps[2].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateShield(playerNum);//deactivate power up


        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateShield(int playerNum)
    {
        //return damage that player can do back to normal
        if (playerNum == 1)
        {
            Player1HealthAccess.Player1DamageAmount = 0.5f;
            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (playerNum == 2)
        {
            //set player damage amount back to normal
            Player2HealthAccess.Player2DamageAmount = 0.5f;
            //set plyer colours back to normal
            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        Debug.Log("deactivate Shield");

    }



    //------------------------ Speed ---------------------------------
    // id = 3
    public void UseSpeed(int playerNum)//activate power up
    {
        StartCoroutine(SpeedSequence(playerNum));
        Debug.Log("Speed used");
    }


    IEnumerator SpeedSequence(int playerNum)
    {
        Debug.Log("Speed PowerUp");

        float duration = 10;
        if (playerNum == 1)//If player 1 has the power up and is using it
        {
            Player1ControllerAccess.moveSpeed = 20f;//Player is now faster
            Player2HealthAccess.Player2DamageAmount = 2;//gets more dmage if hit

            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.green; //green


            Destroy(assignPowerUps.powerUps[3].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 10 seconds
            DeactivateSpeed(playerNum);//deactivate power up

        }
        else if (playerNum == 2)//If player 2 has the power up and is using it
        {
            Player2ControllerAccess.moveSpeed = 20f;//Player is now faster
            Player1HealthAccess.Player1DamageAmount = 2;//gets more dmage if hit

            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.green; //green


            Destroy(assignPowerUps.powerUps[3].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateSpeed(playerNum);//deactivate power up

        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateSpeed(int playerNum)
    {
        if (playerNum == 1)
        {
            Player1HealthAccess.Player1DamageAmount = 0.5f;
            Player1ControllerAccess.moveSpeed = 10f;
            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (playerNum == 2)
        {
            //set player damage amount back to normal
            Player2HealthAccess.Player2DamageAmount = 0.5f;
            Player2ControllerAccess.moveSpeed = 10f;
            //set plyer colours back to normal
            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        Debug.Log("deactivate Speed");
    }



    //------------------------ Snail ---------------------------------
    //Player is slower but does 2 damage
    // id = 4
    public void UseSnail(int playerNum)//activate power up
    {
        StartCoroutine(SnailSequence(playerNum));
        Debug.Log("Snail used");

    }


    IEnumerator SnailSequence(int playerNum)
    {
        Debug.Log("Snail PowerUp");

        float duration = 7;
        if (playerNum == 1)//If player 1 has the power up and is using it
        {
            Player1ControllerAccess.moveSpeed = 5f;//Player is now slower
            Player1HealthAccess.Player1DamageAmount = 2;// does more damage

            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;


            Destroy(assignPowerUps.powerUps[4].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 10 seconds
            DeactivateSnail(playerNum);//deactivate power up

        }
        else if (playerNum == 2)//If player 2 has the power up and is using it
        {
            Player2ControllerAccess.moveSpeed = 5f;//Player is now slower
            Player2HealthAccess.Player2DamageAmount = 2;//  does more damage

            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;


            Destroy(assignPowerUps.powerUps[4].IconClone);//destroy power up button of the first item in the array
            yield return new WaitForSeconds(duration);//has powerup for 5 seconds
            DeactivateSnail(playerNum);//deactivate power up

        }

    }

    //Deactivates any buffs given to the player
    private void DeactivateSnail(int playerNum)
    {
        if (playerNum == 1)
        {
            Player1HealthAccess.Player1DamageAmount = 0.5f;
            Player1ControllerAccess.moveSpeed = 10f;
            Player1ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (playerNum == 2)
        {
            //set player damage amount back to normal
            Player2HealthAccess.Player2DamageAmount = 0.5f;
            Player2ControllerAccess.moveSpeed = 10f;
            //set plyer colours back to normal
            Player2ControllerAccess.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("deactivate Snail");
    }


}

