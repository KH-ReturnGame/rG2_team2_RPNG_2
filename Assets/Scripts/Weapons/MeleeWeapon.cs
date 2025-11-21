using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public bool isSwinging;

    private float swingTimer = 0f;
    private bool attackButtonHeld = false;

    private WeaponStats currentStats;
    private Transform weaponHolder;

    void Start()
    {
        weaponHolder = GameObject.Find("Player/MeleeWeapons").transform;
        UpdateStats();
    }

    void Update()
    {
        swingTimer -= Time.deltaTime;

        // Refresh stats in case you switch weapons
        UpdateStats();

        attackButtonHeld = Input.GetMouseButton(0);

        if (currentStats == null)
            return;

        // Single-click mode
        if (!currentStats.allowHoldToSwing)
        {
            if (Input.GetMouseButtonDown(0) && swingTimer <= 0f)
                StartSwing();
            return;
        }

        // Hold-to-swing mode
        if (attackButtonHeld && swingTimer <= 0f)
            StartSwing();
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
        isSwinging = true;
        swingTimer = currentStats.cooldown;

        StartCoroutine(SwingRoutine());
    }

    System.Collections.IEnumerator SwingRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        isSwinging = false;
    }
}
