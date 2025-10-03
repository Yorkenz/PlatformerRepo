using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAnim : MonoBehaviour
{
    
    private Animator animator;
    private Vector2 lastPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement direction
        /*Vector2 currentPosition = transform.position;
        Vector2 movement = currentPosition - lastPosition;

        // Only update if the enemy is moving to prevent jitter
        if (movement.magnitude > 0.01f) // 0.01f is a small tolerance
        {
            // Send the movement values to the Animator blend tree
            animator.SetFloat("x", movement.x);
            animator.SetFloat("y", movement.y);
        }
        else
        {
            // If the enemy is not moving, set blend tree values to 0
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 0);
        }

        // Store the current position for the next frame
        lastPosition = currentPosition;*/
        float x = GetComponent<Rigidbody2D>().velocity.x;
        float y = GetComponent<Rigidbody2D>().velocity.y;
        //Debug.Log(x);
        animator.SetFloat("x", x);
        animator.SetFloat("y", y);
    }
}
