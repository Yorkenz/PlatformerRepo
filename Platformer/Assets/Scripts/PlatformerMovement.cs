using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public float moveSpeed = 5f;
    private bool grounded = false;
    Rigidbody2D rb;
    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private float speed;
    //where do we want to play the sound
    AudioSource audioSource;
    //what sound do we want to play when we jump
    public AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame  
    void Update()
    {

        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        moveDirection.y = 0;
        transform.Translate(moveDirection * speed * Time.deltaTime);
        //when we press left or right move the char left/right
        float moveX = Input.GetAxis("Horizontal");
        //maintain the integrity of our y velocity 
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        
        //if you press the space AND on the ground, jump the char
        if (Input.GetButtonDown("Jump") && grounded)
        {
            
            if (audioSource != null && jumpSound != null)
            {
                //play my jump sound 
                audioSource.PlayOneShot(jumpSound);
            }
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
    public void Jump()
    {
        //if you press the space AND on the ground, jump the char
        if (grounded)
        {

            if (audioSource != null && jumpSound != null)
            {
                //play my jump sound 
                audioSource.PlayOneShot(jumpSound);
            }
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));

        }
    }
    
}
