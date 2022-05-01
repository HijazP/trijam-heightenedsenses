using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public Rigidbody2D rb;
    Vector2 movement;
    private bool isJumping = false;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // if (Input.GetMouseButtonDown(0))
        // {
        //         isJumping = true;
               
            
        // }
    }

    void FixedUpdate()
    {
    }
    void Jump(){
        if(Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
