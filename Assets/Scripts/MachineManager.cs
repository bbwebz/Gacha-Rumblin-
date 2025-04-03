using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    public AssignPowerUps assignPowerUpsAccess;

    private ShakeManager shake;

    public Animator slotAnimations;


    [SerializeField]
    private GameObject Canvas;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ShakingManager").GetComponent<ShakeManager>();
        //shake.CameraShake();

        //assignPowerUpsAccess.Generate();
        //assignPowerUpsAccess.DisplayOnMachine();

        Canvas.SetActive(false);
        StartCoroutine(RunShaking());


    }


    IEnumerator RunShaking()
    {
        int duration = 4;
        Debug.Log("Start shake");

        shake.CameraShake();

        yield return new WaitForSeconds(duration);//wait a second before funning aniamtion and displayign the slots
        
        Debug.Log("Start assigning");
        Canvas.SetActive(true);
        ItemFadeIn();
        assignPowerUpsAccess.Generate();
        assignPowerUpsAccess.DisplayOnMachine();

    }



    //------------------ Animation functions -------------------------


    public void ItemFadeIn()
    {
        slotAnimations.SetTrigger("Fade");
    }




}
