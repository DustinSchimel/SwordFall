using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDiorama : MonoBehaviour
{
    public float speed = .01f;

    float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        rotationX = this.transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(speed, 0f, 0f);
    }
}
