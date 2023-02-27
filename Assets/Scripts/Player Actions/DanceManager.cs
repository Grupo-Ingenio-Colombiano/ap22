using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceManager : MonoBehaviour, ItemActions
{

    Animator anim;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    public void Dance()
    {
        anim.SetTrigger("dance");
        sound.Play();
    }

    public void CustomAction()
    {
        Dance();
    }
}
