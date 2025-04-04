using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Sprite[] backgroundSprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int selectedLevel = PlayerPrefs.GetInt("SelectedLevel", 0); // Default to 0
        if (selectedLevel >= 0 && selectedLevel < backgroundSprites.Length)
        {
            spriteRenderer.sprite = backgroundSprites[selectedLevel];
        }
    }
}
