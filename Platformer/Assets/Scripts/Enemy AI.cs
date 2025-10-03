using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //refrence to player object 
    GameObject player;
    //the speed at which the enemy will move 
    public float chasespeed = 5.0f;
    //how close the player needs to be to enemy beore starting to chase
    public float chaseTriggerDistance = 4f;
    // Start is called before the first frame update
    //do we want the enemy to return when the player gets away
    public bool returnHome = true;
    //my home position = starting position 
    Vector3 home;
    bool isHome = true;
    //should we patrol or not?
    public bool patrol = true;
    //what direction do we want to patrol in?
    public Vector2 PatrolDirection = Vector2.zero;
    public float patrolDistance = 4f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //home is my starting position when the games being played 
        home = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //figure out where the player is and how far away it is from the enemy 
        //destination (player position) - starting position (enemy position)
        //gives the vector from the enemy to the player 
        Vector2 chaseDir = player.transform.position - transform.position;
        //if the player is "close" chase the player 
        //if the player gets within chaseTrigger Distance units away, chase player 
        if (chaseDir.magnitude < chaseTriggerDistance)
        {
            //chase player
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chasespeed;
            isHome = false;
        }
        //if the return variable is true try to get home 
        else if (returnHome && !isHome)
        {
            //return home 
            Vector3 homeDir = home - transform.position;
            if (homeDir.magnitude > 0.2f)
            {
                homeDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDir * chasespeed;

            }
            //if im close to home
            else
            {
                //stop moving, we're close enough 
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

        }
        else if (patrol)
        {
            //have the enemy patrol away from thier starting position, flip their direction 
            Vector2 displacment = transform.position - home;
            if (displacment.magnitude > patrolDistance)
            {
                PatrolDirection = -displacment;
            }
            //push the enemy in the direction of the patrol 
            PatrolDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = PatrolDirection * chasespeed;

        }
        //otherwise, stop moving 
        else
        {
            //stop moving, we're close enough
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            isHome = true;
        }
         //do we want to patrol?

    }
}
