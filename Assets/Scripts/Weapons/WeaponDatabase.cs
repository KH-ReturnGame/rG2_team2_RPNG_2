using UnityEngine;
using System.Collections.Generic;

public class WeaponDatabase : MonoBehaviour
{
    public List<GameObject> allWeapons = new List<GameObject>();

    public GameObject GetRandomWeaponByRarity(WeaponRarity rarity)
    {
        List<GameObject> filtered = new List<GameObject>();

        foreach (GameObject weapon in allWeapons)
        {
            WeaponStats stats = weapon.GetComponentInChildren<WeaponStats>();
            if (stats != null && stats.rarity == rarity)
            {
                filtered.Add(weapon);
            }
        }

        if (filtered.Count == 0)
            return null;

        int index = Random.Range(0, filtered.Count);
        return filtered[index];
    }
}