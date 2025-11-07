using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    public bool debug = false; // your debug toggle
    private Collider2D hitboxCollider;
    private SpriteRenderer hitboxVisual;

    private MeleeWeapon weaponScript;
    private WeaponStats currentStats;

    void Start()
    {
        hitboxCollider = GetComponent<Collider2D>();
        hitboxVisual = GetComponent<SpriteRenderer>(); // optional visual layer

        weaponScript = GameObject.Find("Player/MeleeWeapons").GetComponent<MeleeWeapon>();
        UpdateWeaponData();
    }

    void Update()
    {
        // Keep data up-to-date in case the equipped weapon changes
        UpdateWeaponData();

        // Activate hitbox when swinging
        bool shouldBeActive = weaponScript.isSwinging;

        hitboxCollider.enabled = shouldBeActive;
        if (hitboxVisual != null)
            hitboxVisual.enabled = debug && shouldBeActive; // show only if debug mode is on
    }

    void UpdateWeaponData()
    {
        Transform weaponHolder = GameObject.Find("Player/MeleeWeapons").transform;
        if (weaponHolder.childCount > 0)
        {
            Transform activeWeapon = weaponHolder.GetChild(0);
            currentStats = activeWeapon.GetComponentInChildren<WeaponStats>();
        }

        if (currentStats != null)
        {
            transform.localScale = new Vector3(2*(currentStats.range), 3*(currentStats.range), 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (weaponScript.isSwinging && other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(currentStats.damage);
            }
        }
    }
}
