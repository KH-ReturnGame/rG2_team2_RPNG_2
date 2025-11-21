using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    [Header("Debug Options")]
    public bool debug = false;

    private BoxCollider2D hitboxCollider;
    private SpriteRenderer hitboxVisual;

    private Vector3 baseEditorScale;
    private Vector2 baseEditorColliderSize;

    private MeleeWeapon weaponScript;
    private WeaponStats currentStats;

    void Awake()
    {
        hitboxCollider = GetComponent<BoxCollider2D>();
        hitboxVisual = GetComponent<SpriteRenderer>();

        hitboxCollider.isTrigger = true;

        // Save the scale and collider size exactly as set in the editor
        baseEditorScale = transform.localScale;
        baseEditorColliderSize = hitboxCollider.size;

        if (hitboxVisual != null)
            hitboxVisual.enabled = false;
    }

    void Start()
    {
        weaponScript = GameObject.Find("Player/MeleeWeapons").GetComponent<MeleeWeapon>();
    }

    void Update()
    {
        RefreshWeaponStats();
        UpdateHitboxState();
    }

    void RefreshWeaponStats()
    {
        Transform weaponHolder = GameObject.Find("Player/MeleeWeapons").transform;

        if (weaponHolder.childCount > 0)
        {
            Transform weapon = weaponHolder.GetChild(0);
            currentStats = weapon.GetComponentInChildren<WeaponStats>();
        }

        if (currentStats != null)
            ApplyRangeMultiplier(currentStats.range);
    }

    void ApplyRangeMultiplier(float range)
    {
        // Apply range TO the base editor scale (never the current scale)
        transform.localScale = baseEditorScale * range;

        // Apply range TO the base collider size (never the current collider size)
        hitboxCollider.size = baseEditorColliderSize * range;

        if (hitboxVisual != null)
            hitboxVisual.size = hitboxCollider.size;
    }

    void UpdateHitboxState()
    {
        bool active = weaponScript != null && weaponScript.isSwinging;

        hitboxCollider.enabled = active;
        if (hitboxVisual != null)
            hitboxVisual.enabled = debug && active;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!weaponScript.isSwinging)
            return;

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null && currentStats != null)
        {
            enemy.TakeDamage(currentStats.damage);
        }
    }
}
