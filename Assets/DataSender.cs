using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSender : MonoBehaviour
{

    //string fileName = "estudioTiempos/estudio_tiempos.xlsx";//cambio para seleccionar informes distintos segun el metodo seleccionado

    [SerializeField]
    MethodSeleccion method;

    public void SendAllData(HistoricalDataForExcel mad/*, OtherData bbd*/)
    {
        var fileName = method.selectedExcelMethod;
        string dataString1 = JsonUtility.ToJson(mad);            
        string toSend = "[" + dataString1 +  "]";
        AddData(toSend, fileName);
    }

    public void SendAllData(MuestreoDataForExcel mad/*, OtherData bbd*/)
    {
        var fileName = method.selectedExcelMethod;
        string dataString1 = JsonUtility.ToJson(mad);        
        string toSend = "[" + dataString1 +  "]";
        AddData(toSend, fileName);
    }

    public void SendAllData(CronoDataForExcel mad/*, OtherData bbd*/)
    {
        var fileName = method.selectedExcelMethod;
        string dataString1 = JsonUtility.ToJson(mad);        
        string toSend = "[" + dataString1 + "]";
        AddData(toSend, fileName);
    }

    public void AddData(string obj, string fileName)
    {
        string aux = obj + "&fileName=" + fileName;
        CreateTable(aux);
    }

    public void CreateTable(string datos)
    {
        Application.ExternalCall("crear_tabla", datos);
        print(datos);
    }

}
