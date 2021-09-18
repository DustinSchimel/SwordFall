using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    float cameraX;
    float cameraY;
    float cameraZ;

    // Start is called before the first frame update
    void Start()
    {
        cameraX = this.transform.position.x;
        cameraZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        cameraY = player.transform.position.y;

        this.transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }
}
