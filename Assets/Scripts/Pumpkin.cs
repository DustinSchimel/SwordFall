using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public GameObject lifeUp;   //The prefab of the 1UP pickup

    private int health = 3;    //The HP of this pumpkin

    //Return whether the tree has 0 HP left
    public void DeductHP()
    {
        health -= 1;
        if (health == 2)
        {
            //Small cracks in the pumpkin
        }
        else if (health == 1)
        {
            //Big cracks in the pumpkin
        }
        else if (health >= 0)
        {
            //Shatter the pumpkin, then destroy it
        }
    }

    private void OnDestroy()
    {
        //Create a 1UP pickup and send it in a random horizontal direction and downwards to that it
        // will arc back up towards the player
    }
}
