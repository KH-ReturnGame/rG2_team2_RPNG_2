using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public bool isMelee = false;
    public bool isRanged = false;
    public bool isMisc = false;
    public float damage = 0.0f;
    public float range = 0.0f;
    public float swingDuration = 0.3f;
    public float cooldown = 0.5f;
    public float endAngle = 60f;
}
