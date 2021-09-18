using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMushroom : MonoBehaviour
{
    private bool walking;   //Whether the bounce mushroom is currently walking
    private bool right; //Whether this bounce mushroom is walking right

    // Update is called once per frame
    private void Update()
    {
        //Walk along the spikes. If the bounce mushroom hits a wall, turn around.
        //If the springing animation is triggered, stop walking momentarily
        if(walking)
        {

        }
    }

    public void Spring()
    {
        //Activate the springing animation and stop walking momentarily
        walking = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Determine whether the bounce mushroom hit an edge wall or the tall section of a bounce
        // mushroom platform
        bool isWall = collision.collider.CompareTag("LeftWall") || 
            collision.collider.CompareTag("RightWall") || collision.collider.CompareTag("BMWall");

        if(isWall)
        {
            if(collision.transform.position.x < transform.position.x) //If hitting a wall to the
                                                                      // left...
            {
                //Flag right walking
                right = true;
            }
            else if (collision.transform.position.x > transform.position.x) //If hitting a wall to the
                                                                            // left...
            {
                //Flag left walking
                right = false;
            }
        }
    }
}
