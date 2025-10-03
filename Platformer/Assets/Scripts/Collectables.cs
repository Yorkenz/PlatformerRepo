using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectables : MonoBehaviour
{
    //store the number of collected iteams in a varaiable
    public int coins = 0;
    public TMP_Text text;
    //whenever we collide with a object, see if it is a collectable
    //if it is a collectable, add to the count
    //destroy the collected item so we can't spam collect
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "coin")
        {
            coins++;
            Destroy(collision.gameObject);
            text.text = " " + coins; //+ " / 5";
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
