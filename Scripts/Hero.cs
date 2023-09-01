using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce =15f;
    [SerializeField] private LayerMask jumpableGround;
    public Transform groundCheckPoint;
    public Transform box;

    private BoxCollider2D coll;
    private bool isGrounded=false;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float buf_y;
    
    public float groundCheckRadius=0.2f;
    public KeyCode Jump_button;
    public KeyCode Run_button_left;
    public KeyCode Run_button_rigth ;
    public string tag_name;

    public static Hero Instance { get; set; }

    private States State
    {
        get { return (States)anim.GetInteger("state");  }
        set { anim.SetInteger("state", (int)value); }
    }

    public void Awake()
    {
        buf_y = transform.position.y; 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }
    public void Run(bool znak)
    {
        if (isGrounded) State = States.run;

        Vector3 dir=transform.right;
        if (znak)
        {
            dir *= -1;
        }
     
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX=dir.x < 0.0f;
    }
    private void Update()
    {
        CheckGround();
        State = States.idle;
        if (Input.GetKey(Run_button_left)) Run(true);
        if (Input.GetKey(Run_button_rigth)) Run(false);
        if (isGrounded && Input.GetKey(Jump_button))
        {
            Jump();
            State = States.jump;
        }
        if (rb.velocity.y<0 && !isGrounded) State = States.fall;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce*3.0f, ForceMode2D.Impulse);
    }

    private void CheckGround() {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.1f, jumpableGround);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag_name)
        {
            box.LeanMoveY(3.0f, 2.0f).setEaseOutExpo().delay = 0.1f;
            Destroy(gameObject);
        }
    }
}
public enum States
{
    idle,
    run,
    jump,
    fall
}
