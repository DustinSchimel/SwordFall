using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    // Placeholder for the bounds of the camera. 
    int left_bound = 0;
    int right_bound = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Generate random integer to determine spawn rate of enemies
        System.Random rnd_gen = new System.Random();
        int rnd_int = rnd_gen.Next(0, 100);

        if (rnd_int == 3) GameObject.Instantiate(enemy, new Vector3(player.transform.position.x, player.transform.position.y - 100, -1177), Quaternion.identity);
    }
}
