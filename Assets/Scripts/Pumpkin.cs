using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject lifeUp;   //The prefab of the 1UP pickup
    public Vector2 lifeUpHorizontalForce;   //The range of horizontal force to apply to the 1UP
                                            // pickup upon release
    public float lifeUpVerticalForce;   //The vertical force to apply to the 1UP pickup upon
                                        // release

    private int health = 3;    //The HP of this pumpkin

    // If hit with attack from the player, health decreases by 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "NewPumpkinKid")
        {

            health--;
            if (health == 2)
            {
                //Small cracks in the pumpkin
            }
            else if (health == 1)
            {
                //Big cracks in the pumpkin
            }
            else if (health == 0)
            {
                //Shatter the pumpkin, then destroy it
                Destroy(gameObject);
            }
            
        }
        Debug.Log("Hit a player");
    }
    
    private void OnDestroy()
    {
        // Play particle explosion effect 
        explosion.Play();

        //Create a 1UP pickup and send it in a random horizontal direction and downwards so that it
        // will arc back up towards the player
        GameObject tempLifeUp = Instantiate(lifeUp);
        Rigidbody lifeUpRigidbody = tempLifeUp.GetComponent<Rigidbody>();
        lifeUpRigidbody.AddForce(new Vector3(Random.Range
            (lifeUpHorizontalForce.x, lifeUpHorizontalForce.y), lifeUpVerticalForce, 0f));
    }
}
