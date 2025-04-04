using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelect : MonoBehaviour
{
    public void SelectLevel(int levelIndex)
    {
        //Once clicked, set the index to the new bg sprite's
        PlayerPrefs.SetInt("SelectedLevel", levelIndex);
        PlayerPrefs.Save();
      
    }
}
