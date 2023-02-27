using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardFieldsSeter : MonoBehaviour
{
    [SerializeField]
    Text[] date;

    [SerializeField]
    Text UnidadesPlaneadas1, UnidadesPlaneadas2,  unidadesRealizadasToday, unidadesRealizadasTodayNextWeek, diferencia1, diferencia2;

    private void OnEnable()
    {        
        SetDates();
        setUnits();
    }
    
        

    void SetDates()
    {
        var time = System.DateTime.Now.AddDays(-6);        

        for (int i = 0; i < date.Length; i++)
        {
            date[i].text = time.AddDays(i).ToString("yyyy-MM-dd"); 
        }
    }

    void setUnits()
    {
        UnidadesPlaneadas1.text = FormResultsManager.Instance.unidadesRequeridas.ToString();
        UnidadesPlaneadas2.text = FormResultsManager.Instance.unidadesRequeridas.ToString();
        unidadesRealizadasToday.text = FormResultsManager.Instance.unidadesProducidasNoCumplen.ToString("F0");
        unidadesRealizadasTodayNextWeek.text = FormResultsManager.Instance.unidadesProducidasCalculadas.ToString("F0");
        diferencia1.text = (FormResultsManager.Instance.unidadesProducidasNoCumplen - FormResultsManager.Instance.unidadesRequeridas).ToString("F0");
        diferencia2.text = (FormResultsManager.Instance.unidadesProducidasCalculadas - FormResultsManager.Instance.unidadesRequeridas).ToString("F0");
    }
}
