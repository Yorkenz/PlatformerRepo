using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerAnimControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = GetComponent<Rigidbody2D>().velocity.y;
        GetComponent<Animator>().SetFloat("X", moveX);
        GetComponent<Animator>().SetFloat("Y", moveY);
        if(moveX < 0)
        {
            //we're moving to the left 
            //flip the sprit 
            GetComponent<SpriteRenderer>().flipX = true;
        }else if(moveY < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false; ;
        }
    }
}
