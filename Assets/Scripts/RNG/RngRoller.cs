using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RngRollerConfigurable : MonoBehaviour
{
    [Header("UI References")]
    public Button rollButton;
    public TMP_Text resultText;

    [Header("Rarity Chances (%)")]
    [Range(0f, 100f)] public float Common = 35.5f;
    [Range(0f, 100f)] public float Uncommon = 30f;
    [Range(0f, 100f)] public float Rare = 20f;
    [Range(0f, 100f)] public float Epic = 14f;
    [Range(0f, 100f)] public float Legendary = 0.4f;
    [Range(0f, 100f)] public float Mythic = 0.09f;
    [Range(0f, 100f)] public float Secret = 0.01f;

    private void Start()
    {
        if (rollButton != null)
        {
            rollButton.onClick.AddListener(Roll);
            Debug.Log("[RngRoller] Listener added.");
        }
        else
        {
            Debug.LogWarning("[RngRoller] rollButton is NULL!");
        }

        if (resultText == null)
            Debug.LogWarning("[RngRoller] resultText is NULL!");
    }

    private void OnDisable()
    {
        if (rollButton != null)
            rollButton.onClick.RemoveListener(Roll);
    }

    public void Roll()
    {
        float roll = Random.Range(0f, 100f); // roll between 0 and 100
        string rarity = GetRarity(roll);

        if (resultText != null)
        {
            string message = $"Rolled {roll:F2}% → {rarity}";
            resultText.text = message;
            Debug.Log($"[RngRoller] {message}");
        }
    }

    private string GetRarity(float roll)
    {
        float cumulative = 0f;

        cumulative += Common;
        if (roll <= cumulative) return "Common";

        cumulative += Uncommon;
        if (roll <= cumulative) return "Uncommon";

        cumulative += Rare;
        if (roll <= cumulative) return "Rare";

        cumulative += Epic;
        if (roll <= cumulative) return "Epic";

        cumulative += Legendary;
        if (roll <= cumulative) return "Legendary";

        cumulative += Mythic;
        if (roll <= cumulative) return "Mythic";

        cumulative += Secret;
        if (roll <= cumulative) return "???";

        return "None (check chance values!)"; // fallback if total < 100
    }
}
