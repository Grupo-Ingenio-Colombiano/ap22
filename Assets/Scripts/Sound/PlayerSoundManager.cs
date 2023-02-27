using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{

    public AudioClip[] sounds;

    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    private void Update()
    {

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {

            if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.RightShift)))
            {
                audioSource.clip = sounds[1];
            }
            else
            {
                audioSource.clip = sounds[0];
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

    }
   

    
}
