using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite fullHeart, emptyHeart;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void setHeartImage(heartStatus status)
    {
        switch(status)
        {
            case heartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case heartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }
}

public enum heartStatus
{
    Empty = 0,
    Full = 1
}