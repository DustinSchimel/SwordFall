using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDiorama : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    private float speed;

    //float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        //rotationX = this.transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;

        this.transform.Rotate(speed * .001f, 0f, 0f);
    }
}
