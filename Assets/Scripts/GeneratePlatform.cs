using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GeneratePlatform : MonoBehaviour
{
    public GameObject player;   //Used to get info on where to spawn platforms based on player Y
    public GameObject spikePlatform;
    public float secondsuntilDestroy;

    private int platformTypesLength;    //The number of possible platform types
    private float playerY;
    private float playerZ;
    private float greatestPlayerY;

    private GameObject lastPlatform;
    private Dictionary<GameObject, int> platformList;
    private List<KeyValuePair<GameObject, int>> platformsToAge;
    private GameObject platformToRemove;

    private enum PlatformTypes
    {
        LeftNormal,
        MiddleNormal,
        RightNormal,
        LeftBM,         //Bounce Mushroom platform with low and high sections
        RightBM,        //Bounce Mushroom platform with low and high sections
        LeftLP,         //Leaf Pile platforms, with the left platform 1/3 of the screen and the
                        // right platform 2/3 of the screen
        MiddleLP,       //Leaf Pile platforms, with each platform 1/2 of the screen
        RightLP,        //Leaf Pile platforms, with the left platform 2/3 of the screen and the
                        // right platform 1/3 of the screen
    }

    private void Start()
    {
        //platformTypesLength = System.Enum.GetNames(typeof(PlatformTypes)).Length;
        platformTypesLength = 3;    //Temp

        greatestPlayerY = 0f;
        playerY = player.transform.position.y;
        platformList = new Dictionary<GameObject, int>();
        platformsToAge = new List<KeyValuePair<GameObject, int>>();
    }

    private void Update()
    {
        playerY = player.transform.position.y;

        if (playerY < greatestPlayerY)  // Player is currently the lowest they have been, generation is now enabled
        {
            greatestPlayerY = playerY;

            if (lastPlatform != null && (lastPlatform.transform.position.y > playerY + 20))
            {
                CreatePlatform();
            }
            else if (lastPlatform == null)
            {
                CreatePlatform();
            }
        }

        if (false) //Generate platforms at random times so that the next platform is generated 3-12
                  // normal platform heights below the prior platform, with 3-6 being favored. If
                  // the height is greater than 6, generate a pumpkin
        {
            CreatePlatform();
        }
    }

    private void CreatePlatform()
    {
        int rand = Random.Range(0, platformTypesLength);

        //Create the platform according to the index randomly generated


        if(rand == 0 || rand == 1 || rand == 2) //Normal platforms
        {
            //If a normal platform is created, randomly generate 0-2 Mushrooms and/or Corns and
            // place them in random segmented places along the platform

            if(rand == 0) //A left platform
            {
                //Randomly create a 1/3 length spider web or tree branch in the gap next to the
                // platform

                lastPlatform = Instantiate(spikePlatform, new Vector3(1260f, playerY - 150f, -1100f), Quaternion.identity);

                Object.Destroy(lastPlatform, secondsuntilDestroy);
            }
            else if (rand == 1) //A right platform
            {
                //Randomly create a 1/3 length spider web or tree branch in the gap next to the
                // platform

                lastPlatform = Instantiate(spikePlatform, new Vector3(1300f, playerY - 150f, -1100f), Quaternion.identity);

                Object.Destroy(lastPlatform, secondsuntilDestroy);
            }
            else //A middle platform
            {
                //Randomly create a 1/4 length spider web or tree branch in each gap next to the
                // platform

                lastPlatform = Instantiate(spikePlatform, new Vector3(1340f, playerY - 150f, -1100f), Quaternion.identity);

                Object.Destroy(lastPlatform, secondsuntilDestroy);
            }
        }
        else if(rand == 3 || rand == 4) //Bounce Mushroom platforms
        {
            //Create a Bounce Mushroom and place it randomly in the lower section of the platform
            //Randomly create a 1/4 length spider web  or tree branch in the gap next to the top
            // and bottom of the upper section of the platform
        }
        else if(rand == 5 || rand == 5 || rand == 6) //Leaf Pile platforms
        {
            //Randomly generate 0-2 Mushrooms and/or Corns and place them in random segmented
            // places along the platform.
            //Create a Leaf Pile in-between the two platforms
        }
    }
}
