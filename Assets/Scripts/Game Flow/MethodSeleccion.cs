﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MethodSeleccion : MonoBehaviour
{
    [SerializeField]
    Canvas UiMethodSelection;

    [SerializeField]
    Animator anim;

    [SerializeField]
    GameManager manager;

    bool selection = false;

    public int method = 0;

    public string selectedExcelMethod = "InformeDatosHistoricos.xlsx";

    private void OnEnable()
    {
        UiMethodSelection.enabled = true;
        anim.SetTrigger("in");
    }

    private void OnDisable()
    {        
        selection = false;
        manager.enablePrizeC();
    }

    public void SelectDatosHistoricos()
    {
        if (!selection)
        {
            method = 1;
            anim.SetTrigger("indh");
            selection = true;
            selectedExcelMethod = "InformeDatosHistoricos.xlsx";
        }        
        
    }

    public void SelectMuestreo()
    {  
        if (!selection)
        {
            method = 2;
            anim.SetTrigger("inm");
            selection = true;
            selectedExcelMethod = "InformeMuestreo.xlsx";
        }

    }

    public void SelectCronometraje()
    {
        if (!selection)
        {
            method = 3;
            anim.SetTrigger("inc");
            selection = true;
            selectedExcelMethod = "InformeCronometraje.xlsx";
        }

    }

    public void cancel()
    {
        if (selection)
        {
            method = 0;
            anim.SetTrigger("cancel");
            selection = false;
        }
        
    }    

    public int GetMethod()
    {
        return method;
    }

    public void acept()
    {
        

        if (selection)
        {
            UiMethodSelection.enabled = false;
            gameObject.SetActive(false);
        }
    }


}
