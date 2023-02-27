using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccion_male : MonoBehaviour
{

    Animator animador;
    public Animator camara;

    // Use this for initialization
    void Start()
    {

        animador = gameObject.GetComponent<Animator>();

    }

    private void OnMouseDown()
    {
        animador.SetBool("mouse_down", true);
        camara.SetBool("male", true);
    }
}
