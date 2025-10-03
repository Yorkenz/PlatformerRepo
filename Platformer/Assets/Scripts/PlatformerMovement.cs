using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public float moveSpeed = 5f;
    private bool grounded = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame  
    void Update()
    {
        //when we press left or right move the char left/right
        float moveX = Input.GetAxis("Horizontal");
        //maintain the integrity of our y velocity 
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        
        //if you press the space AND on the ground, jump the char
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    
}
