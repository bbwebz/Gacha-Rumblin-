using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Background_Switch;

public class LoadSceneWBG : MonoBehaviour
{
    public void LoadScene(int spriteIndex)
    {
        SceneSettings.BGindex = spriteIndex;
        SceneManager.LoadScene("TargetScene");
    }
}
