using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject player;
    public Text score;
    int count = 0;
    float lowest_point;
    // Start is called before the first frame update
    void Start()
    {
        lowest_point = player.transform.position.y;
        score.text = 0.ToString();
    }

    private void FixedUpdate()
    {
        count = int.Parse(score.text);

        // Increase player's score if they are descending
        if(player.transform.position.y < lowest_point)
        {
            lowest_point = player.transform.position.y;
            count += 1;
        }
        
        // Update the player's score
        score.text = count.ToString();
    }
}
