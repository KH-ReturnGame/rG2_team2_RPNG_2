using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RngRoller : MonoBehaviour
{
    [Header("UI References")]
    public Button rollButton;     // Assign your button in the Inspector
    public TMP_Text resultText;       // Assign a UI Text element in the Inspector
    public float Common;
    public float Uncommon;
    public float Rare;
    public float Epic;
    public float Legendary;
    public float Mythic;
    public float Secret;
    private void Start()
    {
        // Hook up the button click
        if (rollButton != null)
            rollButton.onClick.AddListener(Roll);
    }

    private void Roll()
    {
        int roll = Random.Range(1, 10001); // Upper bound is exclusive, so 10001
        string rarity = GetRarity(roll);

        if (resultText != null)
            resultText.text = $"Rolled {roll}: {rarity}";
    }

    private string GetRarity(int roll)
    {
        // Matches your provided rarity distribution
        if (roll <= 3550) return "Common";              // 35.5%
        else if (roll <= 6550) return "Uncommon";       // +30% = 65.5%
        else if (roll <= 8550) return "Rare";           // +20% = 85.5%
        else if (roll <= 9950) return "Epic";           // +14% = 99.5%
        else if (roll <= 9990) return "Legendary";      // +0.4% = 99.9%
        else if (roll <= 9999) return "Mythic";         // +0.09% = 99.99%
        else return "???";                              // +0.01% = 100%
    }
}
