using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject prefab;
    public float shootSpeed = 20;
    public float bulletLifetime = 2;
    public float shootDelay = 0.5f;
    float timer = 0;
    GameObject player;
    //distance the player needs to be at to shoot at them
    public float shootTriggerDistance = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //If the player is in range And if we've waited our shootDelay
        Vector2 shootDir = player.transform.position - transform.position;
       if(shootDir.magnitude < shootTriggerDistance && timer > shootDelay)
        {
            
            //reset our timer 
            timer = 0;
            //get the mouse's position in the game
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //normilize the shoot direction
            shootDir.Normalize();
            //push bullet towards the player 
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * shootSpeed;
            Destroy(bullet, bulletLifetime);
        }
       
         
    }
}
