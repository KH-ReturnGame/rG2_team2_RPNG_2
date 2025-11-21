using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float inertia = 10f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 smoothVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // WASD input
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // === FULL PLAYER FLIP ===
        if (moveInput.x > 0.05f)
        {
            transform.localScale = new Vector3(1, 1, 1); // face right
        }
        else if (moveInput.x < -0.05f)
        {
            transform.localScale = new Vector3(-1, 1, 1); // face left
        }
    }

    void FixedUpdate()
    {
        // Smooth movement with inertia
        smoothVelocity = Vector2.Lerp(
            smoothVelocity,
            moveInput * moveSpeed,
            Time.fixedDeltaTime * inertia
        );

        rb.linearVelocity = smoothVelocity;
    }
}
