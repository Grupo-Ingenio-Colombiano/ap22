
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/userData", order = 1)]

[System.Serializable]

public class UserData : ScriptableObject
{
    public string name;
    public int edad;

    public string email;

    public string lastName; 

    public string PlayerSelected;  

    public Vector3 position;

    public Quaternion rot;

    [Header("Guardado")]
    public int method;

    [Header("--Metodo 1 (Datos Históricos)")]
    [Header("----Punto 0")]
    public float[] historicData = new float[36];

    [Header("----Punto 1")]
    public float requiredUnits;
    [Header("----Punto 2")]



    [Header("--Metodo 2 (Muestreo)")]
    [Header("----Punto 0")]

    [Header("--Metodo 3 (Cronometraje)")]
    [Header("----Punto 0")]
    public string[] A1; // 
    public string[] B1; 
    public string[] C1; // C3 nombre del usuario

   
}


