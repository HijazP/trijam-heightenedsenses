using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool hungry = true;

    public GameObject status;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.Q))
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
            if (Input.GetKey(KeyCode.E))
            {
                status.SetActive(true);
                hungry = true;
            }
        }

        if(Input.GetButtonDown("Jump")){            
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            
        }
    }
}
