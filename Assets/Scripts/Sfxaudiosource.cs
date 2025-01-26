using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxaudiosource : MonoBehaviour
{
    public static AudioSource audiosource;
    
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

    }

    public static void playclip(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
