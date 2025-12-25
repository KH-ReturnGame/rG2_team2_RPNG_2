using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header ("Settings")]
    public Rigidbody2D Rigid;
    public float Speed = 0f;
    [Header("Debugging")]
    public Vector2 InputVec;
    
    
    // SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        // sprite = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        // if (InputVec.x != 0)
        // {
        //     sprite.flipX = InputVec.x < 0;
        // }
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
