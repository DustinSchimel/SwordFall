using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip swordHitSound1, swordHitSound2, swordHitSound3;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        swordHitSound1 = Resources.Load<AudioClip>("sword1");
        swordHitSound2 = Resources.Load<AudioClip>("sword2");
        swordHitSound3 = Resources.Load<AudioClip>("sword3");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "sword1":
                audioSrc.PlayOneShot(swordHitSound1);
                break;
            case "sword2":
                audioSrc.PlayOneShot(swordHitSound2);
                break;
            case "sword3":
                audioSrc.PlayOneShot(swordHitSound3);
                break;
        }
    }
}
