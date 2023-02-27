﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class HistoricalRegisterCalculations : MonoBehaviour
{

    float turnos = 1;
    float horas = 8;
    float descansos = 75;
    float numOperarios = 1;

    float tTotalDispDiario;

    float tiempoOptimo;
    float tiempoTakt;
    float tiempoModal;
    float tiempoPesimista;

    float tiempoCiclo;

    float unidadesProducidas;

    float tOptimoIngresado;
    float tCicloIngresado;
    float uProducidasIngresado;

    [SerializeField] Text requiredUnits;

    [Header("Inputs")]
    [SerializeField] InputField TOInput;
    [SerializeField] InputField TCInput;
    [SerializeField] InputField UPInput;
    [SerializeField] InputField justifInput;
    [SerializeField] Toggle yesNo;

    [SerializeField] ValidateFields validator;
    [SerializeField] GameObject emptyMessage;

    [SerializeField] ExperienceRewardManager rewardManager;


    private void OnEnable()
    {
        requiredUnits.text = QuestHistorical.Instance.CurrentOperationData.requiredUnits.ToString();
    }

    public void Calculate() //calculos 
    {
        bool[] areCorrectAnswers = { true, true, true };


        tiempoModal = QuestHistorical.Instance.CurrentOperationData.modalTime;
        tiempoPesimista = QuestHistorical.Instance.CurrentOperationData.historicalSamples.Max();
        tTotalDispDiario = ((horas * 60) - descansos) * numOperarios * turnos;

        tiempoOptimo = tTotalDispDiario / QuestHistorical.Instance.CurrentOperationData.requiredUnits;
        tiempoTakt = tiempoOptimo;
        tiempoCiclo = (tiempoOptimo + 4 * tiempoModal + tiempoPesimista) / 6f;
        unidadesProducidas = tTotalDispDiario / tiempoCiclo;



        areCorrectAnswers[0] = DataChecker.IsDataCorrect(tOptimoIngresado, tiempoOptimo, 0.1f, "Tiempo optimo");
        areCorrectAnswers[1] = DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo Ciclo");
        areCorrectAnswers[2] = DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 1f, "unidades Producidas");


        FormResultsManager.Instance.unidadesProdPosiblesIngresadas = uProducidasIngresado;
        FormResultsManager.Instance.unidadesRequeridas = QuestHistorical.Instance.CurrentOperationData.requiredUnits;
        FormResultsManager.Instance.tiempoCiclo = tCicloIngresado;
        FormResultsManager.Instance.taktTime = tOptimoIngresado;//tiempoTakt;

        FormResultsManager.Instance.unidadesProducidasNoCumplen = unidadesProducidas;

        FormResultsManager.Instance.Evaluate(areCorrectAnswers, gameObject);

        FormResultsManager.Instance.taktTimeCalculadas = tiempoTakt;
        FormResultsManager.Instance.tiempoCicloCalculadas = tiempoCiclo;
        FormResultsManager.Instance.unidadesProducidasCalculadas = unidadesProducidas;

    }

    private void SetUserInputValues()
    {
        tOptimoIngresado = float.Parse(TOInput.text, CultureInfo.InvariantCulture);
        tCicloIngresado = float.Parse(TCInput.text, CultureInfo.InvariantCulture);
        uProducidasIngresado = float.Parse(UPInput.text, CultureInfo.InvariantCulture);
    }

    public void Submit()
    {
        if (!validator.CheckIsEmpty())
        {
            SetUserInputValues();
            SaveDataInFile();
            Calculate();

            gameObject.SetActive(false);
            HelpManager.Instance().SetHelp("Hable con el supervisor de planta");
            emptyMessage.SetActive(false);
        }
        else
        {
            emptyMessage.SetActive(true);
        }
    }

    void SaveDataInFile()
    {
        //print("init current" + rewardManager.GetCurrentAttempts());

        int currentIndex = -(rewardManager.GetCurrentAttempts() - 3);
        print("data saved " + currentIndex);
        try
        {
            MethodsAnswerData.TiempoTakt[currentIndex] = TOInput.text;
            MethodsAnswerData.TiempoCiclo[currentIndex] = TCInput.text;
            MethodsAnswerData.UnidadesProducidas[currentIndex] = UPInput.text;
            MethodsAnswerData.YesNo[currentIndex] = yesNo.isOn ? "Si" : "No";
            MethodsAnswerData.Justification[currentIndex] = justifInput.text;
        }
        catch (System.Exception e)
        {
            print("current index " + currentIndex);
        }


    }

}
