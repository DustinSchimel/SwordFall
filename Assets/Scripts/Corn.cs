using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    public GameObject kernel;   //The prefab of the corn kernel
    public float kernelLaunchForce; //The force with which to launch the corn kernel upwards
    private Collider cornCollider;  //The Collider of this corn
    private Renderer cornRenderer;  //The Renderer of this corn

    public Transform player;    //The transform of the player character

    public float unitConversion;    //The multiplier to apply to 1 editor unit to get 1 of our units

    private bool active;    //Whether this corn is active and can shoot kernels at the player

    private void Awake()
    {
        cornCollider = GetComponent<Collider>();
        cornRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //If the corn is on-screen, active, and the player iswithin 1.5 units of the corn...
        if (cornRenderer.isVisible && active 
            && Mathf.Abs(player.position.x - transform.position.x) < (1.5 * unitConversion))
        {
            //Create a kernel projectile and send it upwards
            ShootKernel();
        }
    }

    private void ShootKernel()
    {
        //Create a kernel projectile and send it upwards
        GameObject tempKernel = Instantiate(kernel);
        Rigidbody kernelRigidbody = tempKernel.GetComponent<Rigidbody>();
        kernelRigidbody.AddForce(new Vector3(0f, kernelLaunchForce, 0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("CornKernel"))
        {
            if(collision.gameObject.GetComponent<CornKernel>().reflected) //If the kernel has been
                                                                          //reflected by the player
            {
                //Deactivate the corn and switch its appearance, destroy the kernel, and add to the
                // score
                active = false;
                //Switch to destroyed model
                Destroy(collision.gameObject);
                //Add to the score
            }
            else //Otherwise, ignore the collision
            {
                Physics.IgnoreCollision(cornCollider, collision.collider);
            }
        }
    }
}
