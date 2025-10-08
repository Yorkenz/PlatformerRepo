using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    //store the Players health
    public float health = 10;
    float maxHealth;
    // we need a refrence to our healthBar game object
    public Image healthBar;
    //if we collide with something tagged as Enemy, take damage 
    //if health gets too low, we die (reload the Level)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health getts too low, we die (reload the level)
            if (health<=0)
            {
                //reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
 
    }
        //when using trigger always use a collider 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health getts too low, we die (reload the level)
            if (health <= 0)
            {
                //reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
