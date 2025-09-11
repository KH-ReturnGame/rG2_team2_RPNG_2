using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 InputVec;
    public float Speed = 0f;

    Rigidbody2D Rigid;
    SpriteRenderer sprite;
    //Animator Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        //Anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        //Anim.SetFloat("Speed", InputVec.magnitude);
        if (InputVec.x != 0)
        {
            sprite.flipX = InputVec.x < 0;
        }
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //Vector2 NextVec = InputVec * Time.fixedDeltaTime * Speed;
        Vector2 NextVec = InputVec.normalized * Time.fixedDeltaTime * Speed;
        Rigid.MovePosition(Rigid.position + NextVec);
    }

    // Update is called once per frame
    void Update()
    {
        //InputVec.x = Input.GetAxis("Horizontal");
        //InputVec.y = Input.GetAxis("Vertical");
        InputVec.x = Input.GetAxisRaw("Horizontal");
        InputVec.y = Input.GetAxisRaw("Vertical");
    }
}
