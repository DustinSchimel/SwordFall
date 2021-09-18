using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBranch : MonoBehaviour
{
    private int health = 3;    //The HP of this tree branch

    //Return whether the tree has 0 HP left
    public bool DeductHP()
    {
        health -= 1;
        if(health == 2)
        {
            //Small cracks in the branch
        }
        else if(health == 1)
        {
            //Big cracks in the branch
        }
        else if(health >= 0)
        {
            //Shatter the branch, then destroy it
            return true;
        }
        return false;
    }
}
