using System.Collections;
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

    [SerializeField]
    UserData data;

    LoadManager loadManager;


    bool selection = false;

    public int method = 0;

    public string selectedExcelMethod = "InformeDatosHistoricos.xlsx";
     void Start()
    {
        if (data.isSave == true)
        {
            method = data.method;
            selection = data.selectedMethod;
            acept();
           
        }
    }

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
            data.method = method;
            anim.SetTrigger("indh");
            selection = true;
            data.selectedMethod = selection;
            selectedExcelMethod = "InformeDatosHistoricos.xlsx";
        }        
        
    }

    public void SelectMuestreo()
    {  
        if (!selection)
        {
            method = 2;
            data.method = method;
            anim.SetTrigger("inm");
            selection = true;
            data.selectedMethod = selection; 
            selectedExcelMethod = "InformeMuestreo.xlsx";
        }

    }

    public void SelectCronometraje()
    {
        if (!selection)
        {
            method = 3;
            data.method = method;
            anim.SetTrigger("inc");
            selection = true;
            data.selectedMethod = selection;
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
