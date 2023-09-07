using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsValidation : MonoBehaviour
{

    [SerializeField]
    GameObject[] itemsMan;


    [SerializeField]
    GameObject[] itemsDarkMan;

    [SerializeField]
    GameObject[] itemsGirl;


    [SerializeField]
    GameObject[] itemsDarkGirl;

    [SerializeField]
    Gender gender;

    [SerializeField]
    GameObject dontItemGood;

    [SerializeField] UserData userData;

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
        if (userData.PlayerSelected == "0")
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

        if (userData.PlayerSelected == "2")
        {
            foreach (GameObject g in itemsDarkMan)
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

    private void GirlValidate()
    {
        if(userData.PlayerSelected == "1")
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
        if (userData.PlayerSelected == "3")
        {
            foreach (GameObject g in itemsDarkGirl)
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
}
