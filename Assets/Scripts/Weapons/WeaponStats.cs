using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [Header("Basic Settings")]
    public bool isMelee = false;
    public bool isRanged = false;
    public bool isMisc = false;
    [Header("Stats Editor")]
    public float damage = 0.0f;
    public float range = 0.0f;
    public float cooldown = 0.5f;
    [Header("Swing Options")]
    public float swingTime = 0.25f;
    public float startAngle = 60f;    // where the swing begins
    public float endAngle = -60f;     // where the swing ends
    [Header("Hold to Swing")]
    public bool allowHoldToSwing = false;
}
