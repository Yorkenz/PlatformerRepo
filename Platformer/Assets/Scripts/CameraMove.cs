using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1.0f; 
    public float accelrate = 0.1f;
    public float maxspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Mathf.Clamp(moveSpeed + accelrate * Time.deltaTime, 0 , maxspeed);
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;   
    }
}
