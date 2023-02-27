using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTorno : MonoBehaviour {

    public ParticleSystem sparks;

    public AudioSource sound;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayParticles()
    {
        sparks.Play();
        sound.pitch = 0.6f;
    }

    public void StopParticles()
    {
        sparks.Stop();
        sound.pitch = 0.2f;
    }

}
