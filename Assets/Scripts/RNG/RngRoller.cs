using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RngRoller : MonoBehaviour
{
    [Header("UI References")]
    public Button rollButton;     // Assign your button in the Inspector
    public TMP_Text resultText;       // Assign a UI Text element in the Inspector

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
        // Example rarity tiers (you can adjust probabilities however you want)
        switch (roll)
        {
            case int n when (n <= 6000):
                return "Common";
            case int n when (n <= 4000):
                return "Uncommon";
            case int n when (n <= 3900):
                return "Rare";
            case int n when (n <= 9990):
                return "Epic";
            case int n when (n <= 10000):
                return "Legendary";
            default:
                return "Unknown"; // fallback
        }
    }
}
