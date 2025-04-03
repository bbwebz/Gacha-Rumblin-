using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    public AssignPowerUps assignPowerUpsAccess;

    private ShakeManager shake;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ShakingManager").GetComponent<ShakeManager>();
        shake.CameraShake();

        assignPowerUpsAccess.Generate();
        assignPowerUpsAccess.DisplayOnMachine();

        //StartCoroutine(RunShaking());


    }


    //IEnumerator RunShaking()
    //{
    //    int duration = 5;
    //    Debug.Log("Start shake");

    //    shake.CameraShake();
    //    shake.CameraDown();


    //    yield return new WaitForSeconds(duration);//has powerup for 5 seconds
    //    Debug.Log("Start assigning");
    //    assignPowerUpsAccess.Generate();
    //        assignPowerUpsAccess.DisplayOnMachine();
        
    //}


}
