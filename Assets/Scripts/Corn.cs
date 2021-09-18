using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    public GameObject kernel;   //The prefab of the corn kernel
    private Collider cornCollider;  //The Collider of this corn

    private bool active;    //Whether this corn is active and can shoot kernels at the player

    private void Awake()
    {
        cornCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(false) //If the corn is on-screen, active, & the player is within 1 unit of the corn...
        {
            //Create a kernel projectile and send it upwards
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("CornKernel"))
        {
            if(collision.gameObject.GetComponent<CornKernel>().reflected) //If the kernel has been
                                                                          //reflected by the player
            {
                //Deactivate the corn, destroy the kernel, and add to the score
            }
            else if(false) //Otherwise, ignore the collision
            {
                Physics.IgnoreCollision(cornCollider, collision.collider);
            }
        }
    }
}
