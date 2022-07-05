using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInput;
    public float jumpForce;
    private bool isGrounded;
    private bool facingRight;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        StatusCharacter stats = GetComponent<StatusCharacter>();

        if (stats.hungry)
        {
            anim.SetBool("fill", false);
            rb.AddForce(new Vector2 (moveInput * speed, rb.velocity.y));
        }
        else
        {
            anim.SetBool("fill", true);
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            HungryBar.instance.UseStamina();
        }

        if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
