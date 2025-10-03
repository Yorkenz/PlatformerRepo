using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableTypes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string name = "nugget";
        int lives = 2;
        Debug.Log(name);
        Debug.Log(lives);
        //each of the below reduces the value of lives by 1
        lives = lives - 1;
        lives -= 1;
        lives-- ;
        float critChance = 0.1f;
        critChance += 0.2f;
        bool isDead = false;
        int health = 10;
        //if health reaches zero we should be dead 
        if(health < 1)
        {
            isDead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
