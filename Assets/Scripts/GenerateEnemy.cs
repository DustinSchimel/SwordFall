using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject pumpkin;
    public GameObject player;
    int gen_spd;
    List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gen_spd = 300;
        enemies.Add(pumpkin);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Generate random integer to determine spawn rate of enemies and a random position for them to spawn
        System.Random rnd_gen = new System.Random();
        int rnd_int = rnd_gen.Next(0, gen_spd);
        int rnd_pos = rnd_gen.Next(-35, 30);
        int rnd_enemy = 0;
        if (rnd_int == 7)
        {
            
            gen_spd--;
            GameObject temp_enemy = GameObject.Instantiate(enemies[rnd_enemy], new Vector3(rnd_pos, player.transform.position.y - 100, 0), Quaternion.identity);
            temp_enemy.GetComponent<Enemy>().player = this.player;
            rnd_int = 0;
        }

    }
}
