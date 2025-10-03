using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 2;
    public int dropChance = 100;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet") 
        {
            //destroy the bullet 
            Destroy(collision.gameObject);
            //reduce my hp
            health--;
            //destroy myself if i get too low in health 
            if (health <= 0)
            {
                Destroy(gameObject);
                //create a random variable to determine if we should drop an item or not 
                //maximum of random.eange is exclusive, so we have to add +1
                int r = Random.Range(1, 101); //give a random variable beween 1 and 100
                if (dropChance >= r)
                {
                    Instantiate(prefab, transform.position, Quaternion.identity);
                  

                   
                }

            }

        }
    }
}


