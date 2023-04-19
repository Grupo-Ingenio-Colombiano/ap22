
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/userData", order = 1)]

[System.Serializable]

public class UserData : ScriptableObject
{
    public static UserData Instance;
    
    public string name;
    public string email;
    public string lastScene;
    public string practiceName;

    public bool isSave = false;
    public int load;
    public int nodeDialogueJefePlanta;

    public string PlayerSelected;  
    public Vector3 playerPosition;
    public Quaternion playerRot;

    public float progress;
    public float experience;
    public string timer;

    public int badAnswer;
    public int goodAnswer;

    public Vector3 markerCanvas;
    public Vector3 indicator;

   

    [Header("Guardado")]
    public int method;
    public bool selectedMethod;
    public int proccessUnits;
    public int indexOperationData;

    public List<InventoryItem> inventory;
 

    [Header("--Metodo 1 (Datos Históricos)")]
    [Header("----Punto 0")]
    public float[] historicData = new float[36];
    public float minTimeHistorical;
    public float maxTimeHistorical;
    public float talkTime;
    public float tiempoOptimo;
    public float unidadesRequeridas;
    public string justifHistorical;
   

    [Header("----Punto 1")]
    public int unitsProccess;
    public float requiredUnits;
    [Header("----Punto 2")]
    public int kSuplements;



    [Header("--Metodo 2 (Muestreo)")]
    [Header("----Punto 0")]
   
    public float numMinutos;
    public float percentageOperation;
    public float rhythm;
    public float k;
    public float unitsProccessMuestreo;
    [Header("--Metodo 3 (Cronometraje)")]
    [Header("----Punto 0")]
    public string[] A1; // 
    public string[] B1; 
    public string[] C1; // C3 nombre del usuario

    [Header("--Selección de Turnos ")]
    public int unitPerDay;
    public int unitsRquired;
    public bool turn1;
    public bool turn2;
    public bool turn3;
    public string observaciones;


    [Header("----------Datos de Excel----------")]

    public string templateName;

    public string fileName;

    public List<VpSerializableData.ExcelPage> excelReport;

    [Header("----------MailData----------")]

    public string reportUrl;
    public string institution;
    public string academicProgram;
    public string subject;
    public string studentCode;
    public string teacherName;
    public string teacherEmail;

}


