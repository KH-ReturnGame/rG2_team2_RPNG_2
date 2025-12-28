using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public GameObject[] slots = new GameObject[3]; // 3칸 인벤토리
    public int currentIndex = 0; // 현재 장착 슬롯
    
    public void ReplaceWeapon(int index, GameObject newWeapon)
    {
        if (index < 0 || index >= slots.Length)
            return;

        slots[index] = newWeapon;
    }

    public bool AddWeapon(GameObject weaponPrefab)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = weaponPrefab;
                return true;
            }
        }
        return false; // 인벤토리 꽉 참
    }
    
    public bool IsFull()
    {
        foreach (var w in slots)
            if (w == null)
                return false;

        return true;
    }


}

