using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchScenes : MonoBehaviour
{
    public Animator transition;

    public void switchScenes(string sceneName)
    {
        transition.SetTrigger("Start");
        //SceneManager.LoadScene(sceneName);
        StartCoroutine(delaySec(sceneName));
        Debug.Log("before calling coroutine");
    }

    IEnumerator delaySec(string sceneName)
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("after calling coroutine");
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
