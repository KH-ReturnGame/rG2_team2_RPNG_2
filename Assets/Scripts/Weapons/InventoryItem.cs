using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    InventoryManager inventory;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
    }

    void OnMouseDown()
    {
        inventory.ToggleEquip(this);
    }
}
