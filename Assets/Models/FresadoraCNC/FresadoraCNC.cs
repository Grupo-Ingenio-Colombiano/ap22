using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FresadoraCNC : MonoBehaviour
{

    public GameObject broca;

    public ParticleSystem dust;

    public ParticleSystem spark;

    public AudioSource sound;


    private void FixedUpdate()
    {
        RotateBroca();
    }

    void RotateBroca()
    {
        broca.transform.Rotate(new Vector3(0, 0, 30));
    }

    public void PlayDust()
    {
        dust.Play();
    }

    public void StopDust()
    {
        dust.Stop();
    }

    public void SoundLow()
    {
        sound.pitch = 0.3f;
    }

    public void SoundHigh()
    {
        sound.pitch = 0.8f;
    }

    public void PlaySparks()
    {
        spark.Play();
    }
}
