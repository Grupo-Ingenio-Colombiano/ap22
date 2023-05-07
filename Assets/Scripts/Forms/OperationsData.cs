﻿using System.Collections.Generic;
using UnityEngine;


public class OperationsData
{



}


public class OperationData
{
    public string operationName;
    public int requiredUnits;

    //Datos Historicos
    public float minTime;
    public float maxTime;
    public float modalTime;
    public int numMachines;

    //Datos Muestreo
    public float numMinutosMuestreo;
    public float porcentajeDedicadoOperacion;
    public float factorRitmo;
    public float K;
    public int unidadesRealizadas; //N

    public float[] historicalSamples;
    public int[] rhytmfFactors = new int[36];

    public int Index { get; }

    public OperationData(int indexToGenerate, int method)
    {
        Index = indexToGenerate;
        Debug.Log("INDEX" + Index);
        switch (indexToGenerate)
        {
            case 1:
                operationName = "Corte del tubo de manubrio";
                minTime = 5.4f;
                maxTime = 6.6f;
                numMachines = 3;
                requiredUnits = Random.Range(100, 351);
                unidadesRealizadas = Random.Range(14, 19);

                break;
            case 2:
                operationName = "Doblado del manubrio";
                minTime = 4.6f;
                maxTime = 5.4f;
                numMachines = 2;
                requiredUnits = Random.Range(100, 201);
                unidadesRealizadas = Random.Range(16, 23);
                break;
            case 3:
                operationName = "Rectificación de cuadro";
                minTime = 5.4f;
                maxTime = 6.6f;
                numMachines = 1;
                requiredUnits = Random.Range(100, 151);
                unidadesRealizadas = Random.Range(14, 19);
                break;

            default:
                break;
        }

        SetHistoricalSamples(minTime, maxTime);
        SetRhytmfactors();

        if (method == 1)
        {
            SetSamplingData();
        }

        if (method == 2)
        {
            SetTimingData();
        }

    }

    public OperationData(int indexToGenerate, int method, UserData userData)
    {
        Index = indexToGenerate;
        requiredUnits = userData.proccessUnits;
        minTime = userData.minTimeHistorical;
        maxTime = userData.maxTimeHistorical;
        unidadesRealizadas = userData.unidadesProducidasMuestreo;
        switch (indexToGenerate)
        {
            case 1:
                operationName = "Corte del tubo de manubrio";             
                numMachines = 3;             
               

                break;
            case 2:
                operationName = "Doblado del manubrio";
             
                numMachines = 3;
              
                break;
            case 3:
                operationName = "Rectificación de cuadro";
             
                numMachines = 3;
               
                break;

            default:
                break;
        }
        SetHistoricalSamples(minTime, maxTime);
        historicalSamples = userData.historicData;
     
        rhytmfFactors = userData.rhytmFactor;

        numMinutosMuestreo = userData.numMinutos;
        porcentajeDedicadoOperacion = userData.percentageOperation;
        factorRitmo =userData.rhythm;
        K = userData.k;
        

        if (method == 2)
        {
            K = userData.kCronometraje;
        }

    }



    void SetHistoricalSamples(float minValue, float maxValue)
    {
        historicalSamples = new float[36];

        var modalData = Rounder.RounToPlaces(Random.Range(minValue, maxValue), 2);

        int modal1 = Random.Range(0, 12);
        int modal2 = Random.Range(13, 24);
        int modal3 = Random.Range(25, 36);

        historicalSamples[modal1] = modalData;
        historicalSamples[modal2] = modalData;
        historicalSamples[modal3] = modalData;
        modalTime = modalData;

        for (int i = 0; i < historicalSamples.Length; i++)
        {
            if (i != modal1 && i != modal2 && i != modal3)
            {
                historicalSamples[i] = Rounder.RounToPlaces(Random.Range(minValue, maxValue), 2);
                //Debug.Log(historicalSamples[i]);
            }

        }
    }

    void SetSamplingData()
    {
        numMinutosMuestreo = 30 * Random.Range(1, 5) + 30;
        porcentajeDedicadoOperacion = 5 * Random.Range(0, 3) + 80;
        factorRitmo = 5 * Random.Range(0, 4) + 80;
        K = Random.Range(10, 16);
    }

    void SetTimingData()
    {
        //numMinutosMuestreo = 30 * Random.Range(0, 4) + 30;
        //porcentajeDedicadoOperacion = 5 * Random.Range(0, 3) + 80;
        //factorRitmo = 5 * Random.Range(0, 4) + 80;
        K = Random.Range(12, 16);
    }

    public void SetRhytmfactors()
    {
        List<int> tempfactors = new List<int>();


        for (int i = 0; i < 10; i++)
        {
            tempfactors.Add(100);
        }

        for (int i = 0; i < 7; i++)
        {
            tempfactors.Add(95);
            tempfactors.Add(105);
        }

        for (int i = 0; i < 5; i++)
        {
            tempfactors.Add(90);
            tempfactors.Add(110);
        }

        tempfactors.Add(85);
        tempfactors.Add(115);


        int randomIndex = 0;

        int tempIndex = 0;


        while (tempfactors.Count > 0)
        {
            randomIndex = Random.Range(0, tempfactors.Count); //Choose a random object in the list
            rhytmfFactors[tempIndex] = tempfactors[randomIndex];
            tempfactors.RemoveAt(randomIndex); //remove to avoid duplicates
            tempIndex++;
        }


    }

}
