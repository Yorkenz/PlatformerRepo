using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // just naming what need to be refrenced for basic movement
    private Rigidbody2D rb2D;

    public float moveSpeed;
    public float jumpForce;
    private bool isJumping;
    private float moveH;
    private float moveV;

    // Start is called before the first frame update
    void Start()
    {
        // if want to (GetComponent) this is important to memorize
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 4f;
        jumpForce = 6f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveH > 0.1f || moveH < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveH * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveV > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveV * jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
