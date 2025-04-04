using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class StaticData 
{
    //Gacha machine
    public static int itemP1Keep;
    public static int itemP2Keep;


    //Level initializer
    public static List<GameObject> PlayerPrefab = new List<GameObject>();

    //Spawn player setup menu to player controller
    //to save which device belongs to which player
    public static int NewPlayerIndex;



}
