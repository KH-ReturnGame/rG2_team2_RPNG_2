using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D parentRb;

    private Vector2 lastDirection = Vector2.down;
    private const float moveThreshold = 0.01f;

    void Awake()
    {
        animator = GetComponent<Animator>();

        // Find Rigidbody2D on parent (or higher up, just in case)
        parentRb = GetComponentInParent<Rigidbody2D>();

        if (parentRb == null)
        {
            Debug.LogError("님아 rigidbody2d 빼먹음");
        }
    }

    void Update()
    {
        if (parentRb == null) return;

        Vector2 velocity = parentRb.linearVelocity;
        bool isMoving = velocity.magnitude > moveThreshold;

        if (isMoving)
        {
            Vector2 dir = velocity.normalized;

            // Lock to cardinal directions (top-down RPG style)
            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                dir = new Vector2(Mathf.Sign(dir.x), 0);
            else
                dir = new Vector2(0, Mathf.Sign(dir.y));

            lastDirection = dir;

            animator.SetFloat("MoveX", dir.x);
            animator.SetFloat("MoveY", dir.y);
        }
        else
        {
            // Preserve last facing direction while idle
            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
        }

        animator.SetBool("IsMoving", isMoving);
    }
}
