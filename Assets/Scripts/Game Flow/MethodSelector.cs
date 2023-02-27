using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodSelector : MonoBehaviour
{

    [SerializeField]
    MethodSeleccion method;

    [SerializeField]
    GameObject historical;

    [SerializeField]
    GameObject sample;

    [SerializeField]
    GameObject timing;

    public void setMethod()
    {
        switch (method.method)
        {
            case 1:
                historical.SetActive(true);
                break;

            case 2:
                sample.SetActive(true);
                break;

            case 3:
                timing.SetActive(true);
                break;
        }        
    }
}
