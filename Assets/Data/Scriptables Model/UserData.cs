
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
    public int lastScene;
    public string practiceName;

    public bool isSave = false;
    public int load;
    public int nodeDialogueJefePlanta;
    public int inspectorSeguridad;

    public string PlayerSelected;
    public bool gender;
    public Vector3 playerPosition;
    public Quaternion playerRot;

    public float progress;
    public float experience;
    public string time;
    public string tiempoTotal;
    public string note;

    public int badAnswer;
    public int goodAnswer;

    public Vector3 markerCanvas;
    public Vector3 indicator;
    public int numInventario;
    [Header("Formulario de Ingreso")]
    public string nombreForm;
    public string apellidoForm;
    public string iDForm;
    
   
    [Header("Guardado")]
    public int method;
    public bool selectedMethod;
    public int proccessUnits;
    public int indexOperationData;
    public bool failPractice;

    [Header("Score")]
    public int scoreMethodElection;
    public  int scoreSecurityElements;
    public int scoreHistoricDataTable;
    public int scoreTO;
    public List<InventoryItem> inventory;
    public bool questsCheck = false;

    [Header("--Metodo 1 (Datos Hist�ricos)")]
    [Header("----Punto 0")]
    public float[] historicData = new float[36];
    public float minTimeHistorical;
    public float maxTimeHistorical;
    public float talkTimeHistorical;
    public float tiempoCicloHistorical;
    public float unidadesRequeridasHistorical;
    public string justifHistorical;

    public int experienceSelectHistoricalData;
    public int experienceTalkTimeHistorical;
    public int experienceTiempoOptimoHistorical;
    public int experienceUnidadesrequeridasHistorical;
    public int experienceQuestionHistorical;
    public float modalTimeHistorical;
   

    [Header("----Punto 1")]
    public int unitsProccess;
    public int requiredUnits;
    [Header("----Punto 2")]
    public int kSuplements;



    [Header("--Metodo 2 (Muestreo)")]
    [Header("----Punto 0")]
   
    public float numMinutos;
    public float percentageOperation;
    public float rhythm;
    public float k;
    public int unidadesProducidasMuestreo;

    public int experienceTalkTimeSample;
    public int experienceTiempoOptimoSample;
    public int experienceUnidadesrequeridasSample;
    public int experienceQuestionSample;

    [Header("--Metodo 3 (Cronometraje)")]

    public float kCronometraje;
    public int[] rhytmFactor = new int[36];
    public float[] cronometrajeData = new float[36];
    public int experienceCronometer;
    [Header("--Selecci�n de Turnos ")]
    public string[] operators = new string[3];
    public int unitPerDay;
    public int unitsRquired;
    public bool turn1;
    public bool turn2;
    public bool turn3;
    public string observaciones;
    public int experienceTurnOperators;


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


