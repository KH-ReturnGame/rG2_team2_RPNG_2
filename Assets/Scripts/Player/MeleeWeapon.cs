using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Swing Settings")]
    //public float swingSpeed = 360f; // degrees per second, never referenced in the script btw
    public float swingDuration = 0.3f;
    public float cooldown = 0.5f;
    public float endAngle = 0.0f;

    private bool isSwinging = false;
    private float swingTimer = 0f;
    private Quaternion startRot;
    private Quaternion endRot;
    private float cooldownTimer = 0f;

    void Update()
    {
        // Cooldown timer
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        // Start swing input
        if (Input.GetMouseButtonDown(0) && !isSwinging && cooldownTimer <= 0f)
        {
            StartSwing();
        }

        // Handle swing motion
        if (isSwinging)
        {
            swingTimer += Time.deltaTime;
            float t = swingTimer / swingDuration;

            transform.localRotation = Quaternion.Slerp(startRot, endRot, t);

            if (t >= 1f)
            {
                isSwinging = false;
                cooldownTimer = cooldown;
                //transform.localRotation = Quaternion.Slerp(endRot, startRot, 0.1f);
                transform.localRotation = startRot; // reset
            }
        }
    }

    void StartSwing()
    {
        isSwinging = true;
        swingTimer = 0f;

        // Define rotation arc (simple sideways swing)
        startRot = transform.localRotation;
        endRot = startRot * Quaternion.Euler(0, 0, -endAngle);
    }
}
