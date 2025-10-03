using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaadNextLevel : MonoBehaviour
{
    //store the name of the levelwe want to load 
    public string levelToLoad;
    //when the player collides with me -I am the Flag!
    //load the given level
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
