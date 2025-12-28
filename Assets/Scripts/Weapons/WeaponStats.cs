using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [Header("Rarity")]
    public WeaponRarity rarity;

    [Header("Basic Settings")]
    public bool isMelee;
    public bool isRanged;
    public bool isMisc;

    [Header("Stats")]
    public float damage;
    public float range;
    public float cooldown;

    [Header("Swing")]
    public float swingTime;
    public float startAngle;
    public float endAngle;

    public bool allowHoldToSwing;
}
