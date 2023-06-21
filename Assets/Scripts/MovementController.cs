using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int jumpsAmount;
    int jumpsLeft;
    public int abilityLeft = 0;
    public GameObject abilityIcon;

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private int totalJump;
    bool isGrounded;
    float moveInput;
    Rigidbody2D rb2d;
    float scaleX;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Jump();

    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Flip();
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
        abilityIcon.transform.GetChild(0).gameObject.SetActive(abilityLeft > 0);
    }

    public void Flip()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (moveInput < 0)
        {
            transform.localScale = new Vector3((-1)*scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();
            if (jumpsLeft > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                totalJump++;
                jumpsLeft--;
                if (totalJump > 1) abilityLeft--;
            }

        }

    }

    public void Jumping(int up = 1)
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, up * jumpForce);
    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        ResetJumps();
    }

    public void ResetJumps()
    {
        if (isGrounded)
        {
            if (abilityLeft < 1)
            {
                jumpsAmount = 1;
            }
            else
            {
                jumpsAmount = 2;
            }
            jumpsLeft = jumpsAmount;
            totalJump = 0;
        }
    }
}
