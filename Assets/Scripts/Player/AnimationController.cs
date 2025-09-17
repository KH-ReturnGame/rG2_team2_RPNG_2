using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); // grab Animator on same GameObject
    }

    void Update()
    {
        // Example: set bool
        bool isMoving = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow);
        anim.SetBool("isMoving", true);

        bool isDead = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow);
        anim.SetBool("isDead", true);

        // Example: set float
        float moveSpeed = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(moveSpeed));

        // Example: set trigger
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("attackTrigger");
        }
    }
}
