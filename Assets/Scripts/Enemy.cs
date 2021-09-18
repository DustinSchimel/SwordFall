using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    int sizeof_game_screen = 15;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("TempPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        // Remove the object if it's waaaaaaay past the screen
        //if (this.transform.position.y > player.transform.position.y)
        if (this.transform.position.y > player.transform.position.y)
        {
            //GameObject.Destroy(this.gameObject);
        }

            // Remove the enemy if attacked
            // TODO: Add some code to remove an enemy if attacked. Self explanatory. 
        }
}
