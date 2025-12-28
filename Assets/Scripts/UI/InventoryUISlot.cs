using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    InventoryManager inventory;
    int slotIndex;
    Button button;

    public void Init(InventoryManager manager, int index)
    {
        inventory = manager;
        slotIndex = index;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        inventory.OnUISlotClicked(slotIndex);
    }
}
