using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    static SoundManager manager;

    static public SoundManager Instance()
    {
        manager = FindObjectOfType(typeof(SoundManager)) as SoundManager;
        return manager;
    }    

    [SerializeField]
    AudioSource oneShootAudio, ambiences;

    [SerializeField]
    AudioClip error, good, clic, fail, industrialAmbience, naturalAmbience;

    public void PlayError()
    {
        oneShootAudio.PlayOneShot(error);
    }

    public void PlayGood()
    {
        oneShootAudio.PlayOneShot(good);
    }

    public void PlayClic()
    {
        oneShootAudio.PlayOneShot(clic);
    }

    public void PlayFail()
    {
        oneShootAudio.PlayOneShot(fail);
    }

    public void PlayIndustrialAmbience()
    {        
        ambiences.clip = industrialAmbience;
        ambiences.Play();
    }

    public void PlayNaturalAmbience()
    {        
        ambiences.clip = naturalAmbience;
        ambiences.Play();
    }

}
