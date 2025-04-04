using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Switch : MonoBehaviour

{
    public static class SceneSettings
    {
        public static int BGindex = 0;
    }

    public Sprite[] BGSprites;
    public SpriteRenderer BGRenderer;
    void Start()
    {
        int index = SceneSettings.BGindex;
        if (index >= 0 && index < BGSprites.Length)
        {
            BGRenderer.sprite = BGSprites[index];
        }
    }

    void Update()
    {
        
    }
}