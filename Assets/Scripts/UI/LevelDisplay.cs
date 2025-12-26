using UnityEngine;
using TMPro;  // Make sure you’re using TextMeshPro

public class LevelDisplay : MonoBehaviour
{
    public PlayerXP playerXp;  // Reference to your player’s XP script
    private TextMeshProUGUI levelText;

    void Awake()
    {
        levelText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (playerXp != null)
        {
            levelText.text = "Level: " + playerXp.currentLevel;
        }
    }
}
