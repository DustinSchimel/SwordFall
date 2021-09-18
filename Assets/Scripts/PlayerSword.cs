using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public Rigidbody playerRigidbody;   //The Rigidbody of the player character

    private void Awake()
    {
        playerRigidbody = transform.root.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Play the player's sword swing animation and activate the sword hitbox (a sphere
            // directly below the player)
            //*This might be better placed in a different script
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Spikes") || other.CompareTag("Corn"))
        {
            //Bounce up
        }
        else if(other.CompareTag("Mushroom"))
        {
            //Bounce up but take damage
        }
        else if(other.CompareTag("BounceMushroom"))
        {
            //Bounce up a lot
        }
        else if(other.CompareTag("TreeBranch"))
        {
            //Bounce up and deduct 1 HP from the tree branch
        }
        else if(other.CompareTag("SpiderWeb"))
        {
            //Destroy the web
        }
        else if(other.CompareTag("Pumpkin"))
        {
            //Knock the pumpkin downwards and in a random horizontal direction, and deduct 1 HP
            // from the pumpkin
        }
        else if(other.CompareTag("CornKernel"))
        {
            //Reflect the kernel back straight downwards and activate its code to kill the spawning
            // corn
        }
        else if(other.CompareTag("LeafPile"))
        {
            //Destroy the leaf pile and cause the attached platforms to swing down towards the
            // walls
        }
    }
}
