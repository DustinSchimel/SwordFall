using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private float time_remaining = 8;
    int dist_to_remove = 150;

    // Update is called once per frame
    void Update()
    {
        // Alternate Enemy Removal
        /*if(time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }*/

        // Remove the object if it's waaaaaaay past the screen
        if (this.transform.position.y > player.transform.position.y + dist_to_remove)
        {
            Debug.Log(player.transform.position.y);
            GameObject.Destroy(this.gameObject);
        }

        // Remove the enemy if attacked
        // TODO: Add some code to remove an enemy if attacked. Self explanatory. 
    }
}
