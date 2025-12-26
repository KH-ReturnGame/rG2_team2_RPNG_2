using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour
{
    public bool isSwinging;

    private float swingCooldownTimer = 0f;

    private WeaponStats currentStats;
    private Transform weaponHolder;

    private Quaternion startRot;
    private Quaternion endRot;

    void Start()
    {
        weaponHolder = transform; // script IS on MeleeWeapons
        UpdateStats();
    }

    void Update()
    {
        // cooldown countdown
        if (swingCooldownTimer > 0f)
            swingCooldownTimer -= Time.deltaTime;

        UpdateStats();

        if (currentStats == null)
            return;

        bool attackHeld = Input.GetMouseButton(0);
        bool attackPressed = Input.GetMouseButtonDown(0);

        // Can't swing while swinging OR cooling down
        if (isSwinging || swingCooldownTimer > 0f)
            return;

        if (!currentStats.allowHoldToSwing)
        {
            if (attackPressed)
                StartSwing();
        }
        else
        {
            if (attackHeld)
                StartSwing();
        }
    }

    void UpdateStats()
    {
        if (weaponHolder.childCount == 0)
        {
            currentStats = null;
            return;
        }

        Transform activeWeapon = weaponHolder.GetChild(0);
        currentStats = activeWeapon.GetComponentInChildren<WeaponStats>();
    }

    void StartSwing()
    {
        if (isSwinging || currentStats == null)
            return;

        isSwinging = true;

        startRot = Quaternion.Euler(0, 0, currentStats.startAngle);
        endRot = Quaternion.Euler(0, 0, currentStats.endAngle);

        StartCoroutine(SwingRoutine());
    }

    IEnumerator SwingRoutine()
    {
        float t = 0f;

        while (t < currentStats.swingTime)
        {
            t += Time.deltaTime;
            float normalized = t / currentStats.swingTime;

            // Rotate the parent object (MeleeWeapons)
            transform.localRotation =
                Quaternion.Slerp(startRot, endRot, normalized);

            yield return null;
        }

        // Reset to start
        transform.localRotation = startRot;

        isSwinging = false;

        // ---- START COOLDOWN AFTER SWING ----
        swingCooldownTimer = currentStats.cooldown;
    }
}
