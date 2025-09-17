using UnityEngine;
using TMPro;  // Make sure you’re using TextMeshPro

public class XPDisplay : MonoBehaviour
{
    public PlayerXP playerXp;  // Reference to your player’s XP script
    private TextMeshProUGUI xpText;

    void Awake()
    {
        xpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (playerXp != null)
        {
            xpText.text = "( XP: " + playerXp.currentXp + " / " + playerXp.xpCap[playerXp.currentLevel] + " )";

        }
    }
}
