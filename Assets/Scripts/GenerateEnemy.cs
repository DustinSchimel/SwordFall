using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
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
        System.Random rnd_gen = new System.Random();
        int rnd_int = rnd_gen.Next();

    }
}
