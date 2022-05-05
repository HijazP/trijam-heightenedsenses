using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float time = 3;
    private float moveInput;
    private bool hungry = true;
    private bool collect = false;
    private Collider2D collision;
    public GameObject status;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        
        if (collect)
        {
            status.SetActive(false);
            hungry = false;
        }

        if (hungry)
        {
            rb.AddForce(new Vector2 (moveInput * speed, rb.velocity.y));
        }
        else
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (time > 0)
            {
                time -= Time.fixedDeltaTime;
            }
            else
            {
                status.SetActive(true);
                hungry = true;
            }
        }

        if(Input.GetButtonDown("Jump")){            
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("collectable"))
        {
            collect = true;
            Destroy(collision.gameObject);
        }
    }
}
