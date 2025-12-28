using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public WeaponInventory inventory;
    public WeaponEquipManager equipManager;

    public Image[] slotImages = new Image[3];

    void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (inventory.slots[i] != null)
            {
                Sprite icon = inventory.slots[i]
                    .GetComponentInChildren<SpriteRenderer>()?.sprite;

                slotImages[i].sprite = icon;
                slotImages[i].color = Color.white;
            }
            else
            {
                slotImages[i].sprite = null;
                slotImages[i].color = new Color(1,1,1,0); // 투명
            }
        }
    }

    public void OnSlotClicked(int index)
    {
        equipManager.SwapWeapon(index);
        RefreshUI();
    }
    
}