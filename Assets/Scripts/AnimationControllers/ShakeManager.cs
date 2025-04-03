using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    public Animator cameraAnimation;

    public void CameraShake()
    {
        cameraAnimation.SetTrigger("Shake");
    }




}

