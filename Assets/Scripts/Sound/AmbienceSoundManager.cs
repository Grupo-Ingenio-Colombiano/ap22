using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSoundManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag.Equals("Player"))
        {
            SoundManager.Instance().PlayIndustrialAmbience();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            SoundManager.Instance().PlayNaturalAmbience();
        }
    }
}
