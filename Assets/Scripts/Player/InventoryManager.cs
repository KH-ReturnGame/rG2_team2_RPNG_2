using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("World Slots")]
    public Transform[] worldSlots; // Slot1–3 (Player/Inventory)
    public Transform meleeWeapons;

    [Header("UI Slots")]
    public InventoryUISlot[] uiSlots; // UI Slot1–3

    public InventoryItem equippedItem;

    void Start()
    {
        // Link UI slots to world slots by index
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Init(this, i);
        }
    }

    public void OnUISlotClicked(int index)
    {
        Transform slot = worldSlots[index];

        // Slot empty → unequip if something is equipped
        if (slot.childCount == 0)
        {
            if (equippedItem != null)
                UnequipItem();
            return;
        }

        InventoryItem item = slot.GetChild(0).GetComponent<InventoryItem>();
        ToggleEquip(item);
    }

    public void ToggleEquip(InventoryItem item)
    {
        if (equippedItem == item)
        {
            UnequipItem();
            return;
        }

        EquipItem(item);
    }

    void EquipItem(InventoryItem item)
    {
        if (equippedItem != null)
            UnequipItem();

        equippedItem = item;
        item.transform.SetParent(meleeWeapons);
        item.transform.localPosition = Vector3.zero;
    }

    void UnequipItem()
    {
        if (equippedItem == null) return;

        foreach (Transform slot in worldSlots)
        {
            if (slot.childCount == 0)
            {
                equippedItem.transform.SetParent(slot);
                equippedItem.transform.localPosition = Vector3.zero;
                break;
            }
        }

        equippedItem = null;
    }
}
