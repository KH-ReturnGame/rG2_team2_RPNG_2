using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RngRollerConfigurable : MonoBehaviour
{
    [Header("UI References")]
    public Button rollButton;
    public TMP_Text resultText;
    public WeaponReplaceUI replaceUI;
    
    [Header("Game References")]
    public WeaponDatabase weaponDatabase;
    public WeaponInventory weaponInventory;

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
        
        // 1. 등급 뽑기
        float roll = Random.Range(0f, 100f);
        WeaponRarity rarity = GetRarity(roll);

        // 2. 그 등급의 무기 하나 선택
        GameObject newWeapon =
            weaponDatabase.GetRandomWeaponByRarity(rarity);

        if (newWeapon == null)
        {
            Debug.Log("해당 등급 무기 없음");
            return;
        }

        // 3. 인벤토리 가득 찼는지 검사
        if (weaponInventory.IsFull())
        {
            // 4. 가득 찼다면 → 교체 UI 열기
            replaceUI.Open(newWeapon);
        }
        else
        {
            // 5. 자리가 있으면 → 그냥 추가
            weaponInventory.AddWeapon(newWeapon);
        }
    }



    private WeaponRarity GetRarity(float roll)
    {
        float cumulative = 0f;

        cumulative += Common;
        if (roll <= cumulative) return WeaponRarity.Common;

        cumulative += Uncommon;
        if (roll <= cumulative) return WeaponRarity.Uncommon;

        cumulative += Rare;
        if (roll <= cumulative) return WeaponRarity.Rare;

        cumulative += Epic;
        if (roll <= cumulative) return WeaponRarity.Epic;

        cumulative += Legendary;
        if (roll <= cumulative) return WeaponRarity.Legendary;

        cumulative += Mythic;
        if (roll <= cumulative) return WeaponRarity.Mythic;

        return WeaponRarity.Secret;
    }

}
