using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsValidation : MonoBehaviour
{

    [SerializeField]
    GameObject[] itemsMan;

    [SerializeField]
    GameObject[] itemsGirl;

    [SerializeField]
    Gender gender;

    [SerializeField]
    GameObject dontItemGood;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (gender.playerIsMan)
                ManValidate();
            else
                GirlValidate();
        }
    }

    private void ManValidate()
    {
        foreach (GameObject g in itemsMan)
        {
            if (!g.activeInHierarchy)
            {
                GameManager.scoreSecurityElements = 0;
                dontItemGood.SetActive(true);
                SoundManager.Instance().PlayNaturalAmbience();
                return;
            }
        }
    }

    private void GirlValidate()
    {
        foreach (GameObject g in itemsGirl)
        {
            if (!g.activeInHierarchy)
            {
                GameManager.scoreSecurityElements = 0;
                dontItemGood.SetActive(true);
                SoundManager.Instance().PlayNaturalAmbience();
                return;
            }
        }
    }
}
