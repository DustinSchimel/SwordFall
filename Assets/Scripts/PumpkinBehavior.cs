using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinBehavior : MonoBehaviour
{
    int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If hit with attack, health decreases by 1;
        health--;

        // If health is 0, destroy it and create explosion effect
        if (health == 0)
        {
            Destroy(this.gameObject);
            // Make particle effect at this object's location

            // Give the player more health
        }
    }
}
