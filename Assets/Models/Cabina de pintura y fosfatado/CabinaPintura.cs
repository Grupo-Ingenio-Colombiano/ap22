using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinaPintura : MonoBehaviour {

    public ParticleSystem dust1;
    public ParticleSystem dust2;

    // Use this for initialization

    public void PlayParticles()
    {
        dust1.Play();
        dust2.Play();
    }
    public void StopParticles()
    {
        dust1.Stop();
        dust2.Stop();
    }

}

