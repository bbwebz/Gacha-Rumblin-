using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
        
    }



    public void LoadNextScene()
    {
        SceneManager.LoadScene("GachaMachine");
    }





}
