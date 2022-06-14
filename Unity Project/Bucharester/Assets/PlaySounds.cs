using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public int currentSound;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAndCycle()
    {
        GetComponent<AudioSource>().clip = sounds[currentSound];
        GetComponent<AudioSource>().Play();

        if (currentSound == sounds.Length - 1)
            currentSound = 0;
        else
            currentSound++;
    }
}
