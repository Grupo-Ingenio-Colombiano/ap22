using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIndicator : MonoBehaviour
{

    [SerializeField] GameObject graphicIndicator;
    [SerializeField] Animator anim;


    private void Start()
    {
        gameObject.layer = 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            graphicIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            graphicIndicator.SetActive(false);
        }
    }

    public void SetIndicatorAnim(bool state)
    {
        if (!state)
        {
            graphicIndicator.SetActive(false);
        }
    }

    public void TriggerIdle()
    {
        anim = GetComponentInChildren<Animator>();
        if (anim != null)
        {
            anim.SetTrigger("idle");
        }

    }

    public void TriggerNotIdle()
    {
        anim = GetComponentInChildren<Animator>();

        if (anim != null)
        {
            anim.SetTrigger("end_idle");
        }

    }
}
