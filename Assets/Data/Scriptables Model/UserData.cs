using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/userData", order = 1)]

[System.Serializable]

public class UserData : ScriptableObject
{
    public static UserData Instance;
    
    public string studentName;
    public string email;
    public string lastScene;
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

public void ResetToItsDefaults()
{
    // -------- Datos básicos --------
    studentName = string.Empty;
    email = string.Empty;
    lastScene = string.Empty;
    practiceName = string.Empty;

    isSave = false;
    load = 0;
    nodeDialogueJefePlanta = 0;
    inspectorSeguridad = 0;

    PlayerSelected = string.Empty;
    gender = false;
    playerPosition = Vector3.zero;
    playerRot = Quaternion.identity;

    progress = 0f;
    experience = 0f;
    time = string.Empty;
    tiempoTotal = string.Empty;
    note = string.Empty;

    badAnswer = 0;
    goodAnswer = 0;

    markerCanvas = Vector3.zero;
    indicator = Vector3.zero;
    numInventario = 0;

    // -------- Formulario --------
    nombreForm = string.Empty;
    apellidoForm = string.Empty;
    iDForm = string.Empty;

    // -------- Guardado --------
    method = 0;
    selectedMethod = false;
    proccessUnits = 0;
    indexOperationData = 0;
    failPractice = false;

    // -------- Score --------
    scoreMethodElection = 0;
    scoreSecurityElements = 0;
    scoreHistoricDataTable = 0;
    scoreTO = 0;
    questsCheck = false;

    if (inventory != null)
        inventory.Clear();
    else
        inventory = new List<InventoryItem>();

    // -------- Metodo 1 (Históricos) --------
    System.Array.Clear(historicData, 0, historicData.Length);
    minTimeHistorical = 0f;
    maxTimeHistorical = 0f;
    talkTimeHistorical = 0f;
    tiempoCicloHistorical = 0f;
    unidadesRequeridasHistorical = 0f;
    justifHistorical = string.Empty;

    experienceSelectHistoricalData = 0;
    experienceTalkTimeHistorical = 0;
    experienceTiempoOptimoHistorical = 0;
    experienceUnidadesrequeridasHistorical = 0;
    experienceQuestionHistorical = 0;
    modalTimeHistorical = 0f;

    unitsProccess = 0;
    requiredUnits = 0;
    kSuplements = 0;

    // -------- Metodo 2 (Muestreo) --------
    numMinutos = 0f;
    percentageOperation = 0f;
    rhythm = 0f;
    k = 0f;
    unidadesProducidasMuestreo = 0;

    experienceTalkTimeSample = 0;
    experienceTiempoOptimoSample = 0;
    experienceUnidadesrequeridasSample = 0;
    experienceQuestionSample = 0;

    // -------- Metodo 3 (Cronometraje) --------
    kCronometraje = 0f;
    System.Array.Clear(rhytmFactor, 0, rhytmFactor.Length);
    System.Array.Clear(cronometrajeData, 0, cronometrajeData.Length);
    experienceCronometer = 0;

    // -------- Selección de Turnos --------
    System.Array.Clear(operators, 0, operators.Length);
    unitPerDay = 0;
    unitsRquired = 0;
    turn1 = false;
    turn2 = false;
    turn3 = false;
    observaciones = string.Empty;
    experienceTurnOperators = 0;

    // -------- Excel --------
    templateName = string.Empty;
    fileName = string.Empty;

    if (excelReport != null)
        excelReport.Clear();
    else
        excelReport = new List<VpSerializableData.ExcelPage>();

    // -------- Mail --------
    reportUrl = string.Empty;
    institution = string.Empty;
    academicProgram = string.Empty;
    subject = string.Empty;
    studentCode = string.Empty;
    teacherName = string.Empty;
    teacherEmail = string.Empty;
}

}


