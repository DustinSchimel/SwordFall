using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateUI : MonoBehaviour
{
    public GameObject player;

    private TextMeshProUGUI textMesh;
    private int score;
    private float playerPos;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position.y;
        score = -1.0f * playerPos;
       // textMesh.text = "Score: " + score.ToString();
    }
}
