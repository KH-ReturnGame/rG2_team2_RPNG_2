using UnityEngine;
using UnityEngine.UI;

public class WeaponReplaceUI : MonoBehaviour
{
    public WeaponInventory inventory;
    public Image[] slotImages;

    private GameObject pendingWeapon; // 새로 얻은 무기

    // UI 열기
    public void Open(GameObject newWeapon)
    {
        pendingWeapon = newWeapon;
        gameObject.SetActive(true);
        RefreshUI();
        Time.timeScale = 0f; // 게임 멈춤 (선택사항)
    }

    void RefreshUI()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            Sprite icon =
                inventory.slots[i]
                    .GetComponentInChildren<SpriteRenderer>()?.sprite;

            slotImages[i].sprite = icon;
            slotImages[i].color = Color.white;
        }
    }

    // 슬롯 클릭
    public void OnSlotSelected(int index)
    {
        inventory.ReplaceWeapon(index, pendingWeapon);

        pendingWeapon = null;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}