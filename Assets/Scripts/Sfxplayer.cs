using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxplayer : MonoBehaviour
{
    AudioClip clip;
    // Start is called before the first frame update

    void Playclip()
    {
        sfxaudiosource.audiosource.PlayOneShot(clip);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
