using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParticles : MonoBehaviour {

    public ParticleSystem particles;

    public void particlesPlay()
    {
        particles.Play();
    }

    public void particlesStop()
    {
        particles.Stop();
    }

}
