using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Rigidbody2D playerRb;   // drag your player’s Rigidbody2D in Inspector
    public Animator anim;          // assign in Inspector OR use GetComponent

    void Update()
    {
        float speed = playerRb.linearVelocity.magnitude; // <-- fixed
        if (speed > 0.01f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        // Debug
        Debug.Log("Speed: " + speed + " | isMoving: " + anim.GetBool("isMoving"));
    }
}
