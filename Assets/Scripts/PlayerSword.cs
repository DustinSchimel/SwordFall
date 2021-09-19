using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSword : MonoBehaviour
{
    public Rigidbody playerRigidbody;   //The Rigidbody of the player character
    public MovePlayer movePlayer;
    public float bounceKnockback;

    public Text score;
    public int spikeBounceBonus;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Spikes") || other.CompareTag("Corn"))
        {
            //Bounce up
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(transform.up * bounceKnockback);
            score.text = (int.Parse(score.text) + spikeBounceBonus).ToString();

            int rand = Random.Range(0, 3);

            if (rand == 0)
            {
                SoundManagerScript.PlaySound("sword1");
            }
            else if (rand == 2)
            {
                SoundManagerScript.PlaySound("sword2");
            }
            else
            {
                SoundManagerScript.PlaySound("sword3");
            }
        }
        else if(other.CompareTag("Mushroom"))
        {
            //Bounce up but take damage, and trigger the mushroom's particle spores
            Debug.Log("Struck mushroom");
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(transform.up * bounceKnockback);
            other.GetComponent<Animator>().SetTrigger("spores");
            movePlayer.TakeDamage();
            SoundManagerScript.PlaySound("mushroom1");
        }
        else if(other.CompareTag("BounceMushroom"))
        {
            //Bounce up a lot and trigger the bounce mushroom's spring animation
        }
        else if(other.CompareTag("TreeBranch"))
        {
            //Deduct 1 HP from the tree branch, and if the tree branch still has HP, bounce up
            if(!other.GetComponent<TreeBranch>().DeductHP())
            {
                //Bounce up
            }
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
            //Reflect the kernel back straight downwards and activate its code to deactivate the
            // spawning corn
            other.GetComponent<CornKernel>().reflected = true;
        }
        else if(other.CompareTag("LeafPile"))
        {
            //Destroy the leaf pile and cause the attached platforms to swing down towards the
            // walls
        }
    }
}
