using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenderEnable : MonoBehaviour
{

    [SerializeField]
    Gender genero;

    private void Awake()
    {
        if (genero.playerIsMan)
        {
            if (name.Equals("Ingeniera"))
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (name.Equals("Ingeniero"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
