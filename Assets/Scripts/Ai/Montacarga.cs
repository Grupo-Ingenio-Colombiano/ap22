using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montacarga : MonoBehaviour
{

    public Animator ani;
    AudioSource aud;


    void Start()
    {
        ani.speed = .7f;
        aud = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            ani.speed = 0;
            aud.Play();
            StartCoroutine(LostExperience());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            ani.speed = .7f;
            StopAllCoroutines();
        }
    }

    IEnumerator LostExperience()
    {
        yield return new WaitForSeconds(10f);
        //GameManager.instance.GenerateIncorrectBox("Incorrecto", 0, -30, "No obstaculice el paso del montacargas, puede causar un accidente \n- 30 Experiencia", false);

    }
}
