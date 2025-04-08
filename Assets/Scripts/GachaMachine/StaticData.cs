using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class StaticData 
{
    //Gacha machine
    public static int itemP1Keep;
    public static int itemP2Keep;


    //player config manager to Level initializer
    //public static List<GameObject> PlayerPrefab = new List<GameObject>();
    public static GameObject obj1;
    public static GameObject obj2;

    public static GameObject[] PlayerPrefab = { obj1, obj2 };

    //Spawn player setup menu to player controller
    //to save which device belongs to which player
    public static int NewPlayerIndex;



}
