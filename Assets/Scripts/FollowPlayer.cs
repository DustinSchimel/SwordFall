using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    float cameraX;
    float cameraY;
    float cameraZ;

    private void OnEnable()
    {
        if (gameObject.CompareTag("SwordDownHitbox"))
        {
            cameraX = player.transform.position.x;
            cameraY = player.transform.position.y - 1f;
            cameraZ = player.transform.position.z;

            this.transform.position = new Vector3(cameraX, cameraY, cameraZ);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraX = this.transform.position.x;
        cameraZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("MainCamera") || gameObject.CompareTag("Background"))
        {
            cameraY = player.transform.position.y - 15;
        }
        else if(gameObject.CompareTag("SwordDownHitbox"))
        {
            cameraX = player.transform.position.x;
            cameraY = player.transform.position.y - 1f;
            cameraZ = player.transform.position.z;
        }
        else
        {
            cameraY = player.transform.position.y;
        }

        this.transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }
}
