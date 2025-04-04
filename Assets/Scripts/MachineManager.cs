using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    public AssignPowerUps assignPowerUpsAccess;

    //private ShakeManager shake;

    public Animator cameraAnimation;

    public Animator slotAnimations;


    [SerializeField]
    private GameObject Canvas;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        cameraAnimation = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        //shake.CameraShake();

        //assignPowerUpsAccess.Generate();
        //assignPowerUpsAccess.DisplayOnMachine();

        Canvas.SetActive(false);
        StartCoroutine(RunShaking());


    }


    IEnumerator RunShaking()
    {
        int duration = 7;
        Debug.Log("Start shake");

        audioManager.PlaySFX(audioManager.rouletteWheel);

        CameraShake();

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

    public void CameraShake()
    {
        cameraAnimation.SetTrigger("Shake");
    }



}
