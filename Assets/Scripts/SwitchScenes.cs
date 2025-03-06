using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchScenes : MonoBehaviour
{
    public void switchScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }

   public void switchScenesOverlay(string sceneName2)
    {
        SceneManager.LoadScene(sceneName2, LoadSceneMode.Additive);
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

}
