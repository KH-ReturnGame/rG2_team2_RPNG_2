using UnityEngine;

public class WeaponEquipManager : MonoBehaviour
{
    public WeaponInventory inventory;
    public Transform meleeWeapons;

    void Start()
    {
        EquipCurrentWeapon();
    }

    public void EquipCurrentWeapon()
    {
        // 기존 무기 제거
        foreach (Transform child in meleeWeapons)
            Destroy(child.gameObject);

        GameObject weapon = inventory.slots[inventory.currentIndex];
        if (weapon == null)
            return;

        Instantiate(weapon, meleeWeapons);
    }

    public void SwapWeapon(int newIndex)
    {
        if (newIndex < 0 || newIndex >= inventory.slots.Length)
            return;

        inventory.currentIndex = newIndex;
        EquipCurrentWeapon();
    }
}