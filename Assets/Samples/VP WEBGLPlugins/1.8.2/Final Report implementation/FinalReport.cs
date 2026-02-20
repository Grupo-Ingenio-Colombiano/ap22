using System.Collections.Generic;
using UnityEngine;
using VP.WEBGL.Plugins;

public class FinalReport : MonoBehaviour
{
    [SerializeField] UserData userData;

    [System.Serializable]
    public class ExcelData
    {
        [System.Serializable]
        public class Field
        {
            public string key = "";//A1
            public string value = "";//Something...
        }
        public List<Field> fields;
    }

    public ExcelData excelData;
    [SerializeField] bool saveInSessionStorage;

    private void Start()
    {
        OpenFinalReporttWhitAll();
    }

    public void OpenFinalReport() { WebGLUtils.OpenFinalReport(); }


    #region Conversor de datos y envio a WEBGL

    public void OpenFinalReporttWhitAll()
    {
        excelData = new ExcelData();
        excelData.fields = new List<ExcelData.Field>();

        ExcelPageToExcelDataFieldList();

        string jsonExcelData = JsonUtility.ToJson(excelData);
        WebGLUtils.OpenFinalReport(jsonExcelData, userData.templateName, userData.email);

        if (saveInSessionStorage)
            WebGLStorage.WriteSessionStorage("data", jsonExcelData);
    }

    //esta funcion se encarga de parsear los datos de excel del viejo sistema al nuevo temporalmente
    //para no tener que actualiza todo lo relacionado a Data en la practica
    void ExcelPageToExcelDataFieldList()
    {

        //ProcessColumn(userData.excelReport[0].A, "A");
        //ProcessColumn(userData.excelReport[0].B, "B");
        ProcessColumn(userData.excelReport[0].C, "C");
        ProcessColumn(userData.excelReport[0].E, "E");
        ProcessColumn(userData.excelReport[0].F, "F");
        ProcessColumn(userData.excelReport[0].G, "G");
        ProcessColumn(userData.excelReport[0].H, "H");
        ProcessColumn(userData.excelReport[0].I, "I");
        ProcessColumn(userData.excelReport[0].J, "J");
        ProcessColumn(userData.excelReport[0].K, "K");
        ProcessColumn(userData.excelReport[0].L, "L");
        ProcessColumn(userData.excelReport[0].M, "M");
        ProcessColumn(userData.excelReport[0].D, "D");

    }
    void ProcessColumn(List<string> columnData, string columnName)
    {
        for (int i = 0; i < columnData.Count; i++)
        {
            string value = columnData[i];

            if (!string.IsNullOrEmpty(value))
            {
                ExcelData.Field field = new ExcelData.Field();
                field.key = columnName + i.ToString();
                field.value = value;
                excelData.fields.Add(field);
            }
        }
    }

    #endregion
}
