using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Swing Settings (Auto-filled from WeaponStats)")]
    public float swingDuration;
    public float cooldown;
    public float endAngle;

    [Header("References")]
    public Transform weapon; // current weapon transform
    [HideInInspector] public bool isSwinging = false;

    private float swingTimer = 0f;
    private Quaternion startRot;
    private Quaternion endRot;
    private float cooldownTimer = 0f;

    private WeaponStats weaponStats; // reference to the weapon's stat script
    private Transform lastWeapon;    // used to detect weapon swaps

    void Update()
    {
        // Detect if weapon child has changed
        if (transform.childCount > 0)
        {
            Transform currentWeapon = transform.GetChild(0);

            // Check if we have a new weapon equipped
            if (currentWeapon != lastWeapon)
            {
                UpdateWeaponReference(currentWeapon);
                lastWeapon = currentWeapon;
            }
        }
        else if (lastWeapon != null)
        {
            // Weapon removed, reset reference
            weaponStats = null;
            lastWeapon = null;
        }

        // Cooldown logic
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        // Start swing
        if (Input.GetMouseButtonDown(0) && !isSwinging && cooldownTimer <= 0f)
            StartSwing();

        // Handle swing rotation
        if (isSwinging)
        {
            swingTimer += Time.deltaTime;
            float t = swingTimer / swingDuration;

            transform.localRotation = Quaternion.Slerp(startRot, endRot, t);

            if (t >= 1f)
            {
                isSwinging = false;
                cooldownTimer = cooldown;
                transform.localRotation = startRot;
            }
        }
    }

    void StartSwing()
    {
        if (weaponStats == null) return; // No weapon equipped

        isSwinging = true;
        swingTimer = 0f;

        startRot = transform.localRotation;
        endRot = startRot * Quaternion.Euler(0, 0, -endAngle);
    }

    void UpdateWeaponReference(Transform newWeapon)
    {
        weapon = newWeapon;
        weaponStats = newWeapon.GetComponentInChildren<WeaponStats>(true);

        if (weaponStats != null)
        {
            swingDuration = weaponStats.swingDuration;
            cooldown = weaponStats.cooldown;
            endAngle = weaponStats.endAngle;

            Debug.Log($"✅ Loaded stats from {newWeapon.name}: duration={swingDuration}, cooldown={cooldown}, endAngle={endAngle}");
        }
        else
        {
            Debug.LogWarning($"⚠️ No WeaponStats found under {newWeapon.name}");
        }
    }
}
