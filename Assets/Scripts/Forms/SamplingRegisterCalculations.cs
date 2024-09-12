using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class SamplingRegisterCalculations : MonoBehaviour
{

    float turnos = 1;
    float horas = 8;
    float descansos = 75;
    float numOperarios = 1;

    float tTotalDispDiario;

    public float tiempoOptimo;
    public float tiempoTakt;
    public float tiempoModal;
    public float tiempoPesimista;

    public float tiempoCiclo;

    public float unidadesProducidas;

    float tOptimoIngresado;
    float tCicloIngresado;
    float uProducidasIngresado;

    [SerializeField] public Text requiredUnits;

    [Header("Inputs")]
    [SerializeField] InputField TOInput;
    [SerializeField] InputField TCInput;
    [SerializeField] InputField UPInput;
    [SerializeField] InputField justifInput;
    [SerializeField] Toggle yesNo;
    [SerializeField] GameObject form;
    [SerializeField] ValidateFields validator;
    [SerializeField] GameObject emptyMessage;

    [SerializeField] ExperienceRewardManager rewardManager;
    [SerializeField] UserData userData;

    private const int experienceGeneral = 87;
    private const int experienciaPregunta = 89;
    private void Start()
    {
        userData.experienceTalkTimeSample = experienceGeneral;
        userData.experienceTiempoOptimoSample = experienceGeneral;
        userData.experienceUnidadesrequeridasSample = experienceGeneral;
        userData.experienceQuestionSample = experienciaPregunta;
    }
    public void Calculate() //calculos 
    {
        tTotalDispDiario = ((horas * 60) - descansos) * numOperarios * turnos;

        tiempoOptimo = tTotalDispDiario / QuestSampling.Instance.CurrentOperationData.requiredUnits;
        tiempoTakt = tiempoOptimo;

        tiempoCiclo = ((QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo * (QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion / 100) *
            (QuestSampling.Instance.CurrentOperationData.factorRitmo / 100) * (1f + (QuestSampling.Instance.CurrentOperationData.K / 100f)))) / QuestSampling.Instance.CurrentOperationData.unidadesRealizadas;
        unidadesProducidas = tTotalDispDiario / tiempoCiclo;


        print("num minutos " + QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo);
        print("porcentaje  " + QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion);
        print("ritmo " + QuestSampling.Instance.CurrentOperationData.factorRitmo);
        print("K " + QuestSampling.Instance.CurrentOperationData.K);
        userData.excelReport[0].M[27] = tiempoOptimo.ToString("F2");
        userData.excelReport[0].M[28] = tiempoCiclo.ToString("F2");
        userData.excelReport[0].M[29] = unidadesProducidas.ToString("F2");


        userData.excelReport[0].M[31] = "No";

        print(yesNo.isOn ? "Si" : "No" + " Cumple");

        print("tiempo optimo " + tiempoOptimo);
        print("tiempo ciclo  " + tiempoCiclo);
        print("unidades producidas " + unidadesProducidas);
       
    }
    private void ValidateIfDataIsCorrect()
    {
        tOptimoIngresado = float.Parse(TOInput.text);
        tCicloIngresado = float.Parse(TCInput.text);
        uProducidasIngresado = float.Parse(UPInput.text);
        bool[] areCorrectAnswers = { true, true, true };
        areCorrectAnswers[0] = DataChecker.IsDataCorrect(tOptimoIngresado, tiempoOptimo, 0.1f, "Tiempo optimo");
        areCorrectAnswers[1] = DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo Ciclo");
        areCorrectAnswers[2] = DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 1f, "unidades Producidas");
        if (DataChecker.IsDataCorrect(tOptimoIngresado, tiempoOptimo, 0.1f, "Tiempo optimo") == true)
        {
            if (TOInput.interactable)
            {
                TOInput.interactable = false;
                TOInput.textComponent.color = new Color(0.01f, 0.85f, 0);
                PlayerDataManager.Instance.AddExperience(userData.experienceTalkTimeSample);
                PlayerDataManager.Instance.AddProgress(25);
            }          
        }
        else
        {
            userData.experienceTalkTimeSample -= Mathf.RoundToInt(experienceGeneral * 0.33f);
            if (userData.experienceTalkTimeSample < 0)
            {
                userData.experienceTalkTimeSample = 0;
            }
        }
        if (DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo Ciclo") == true)
        {
            if(TCInput.interactable)
            {
                TCInput.interactable = false;
                TCInput.textComponent.color = new Color(0.01f, 0.85f, 0);
                PlayerDataManager.Instance.AddExperience(userData.experienceTiempoOptimoSample);
            }
          
        }
        else
        {
            userData.experienceTiempoOptimoSample -= Mathf.RoundToInt(experienceGeneral * 0.33f);
            if (userData.experienceTiempoOptimoSample < 0)
            {
                userData.experienceTiempoOptimoSample = 0;
            }
        }
        if (DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 1f, "unidades Producidas") == true)
        {
            if (UPInput.interactable)
            {
                UPInput.interactable = false;
                UPInput.textComponent.color = new Color(0.01f, 0.85f, 0);
                PlayerDataManager.Instance.AddExperience(userData.experienceUnidadesrequeridasSample);
            }           
        }
        else
        {
            userData.experienceUnidadesrequeridasSample -= Mathf.RoundToInt(experienceGeneral * 0.33f);
            if (userData.experienceUnidadesrequeridasSample < 0)
            {
                userData.experienceUnidadesrequeridasSample = 0;
            }
        }
        if (!yesNo.isOn)
        {
            if (yesNo.interactable)
            {
                yesNo.interactable = false;
                userData.experienceQuestionSample = 89;
                PlayerDataManager.Instance.AddExperience(userData.experienceQuestionSample);
            }         
        }
        else
        {
            userData.experienceQuestionSample -= Mathf.RoundToInt(experienciaPregunta * 0.33f);
            if (userData.experienceQuestionSample < 0)
            {
                userData.experienceQuestionSample = 0;
            }
        }
        userData.justifHistorical = justifInput.text;

        FormResultsManager.Instance.unidadesProdPosiblesIngresadas = uProducidasIngresado;
        FormResultsManager.Instance.unidadesRequeridas = QuestSampling.Instance.CurrentOperationData.requiredUnits;
        FormResultsManager.Instance.tiempoCiclo = tCicloIngresado;
        FormResultsManager.Instance.taktTime = tOptimoIngresado;//tiempoTakt;

        FormResultsManager.Instance.Evaluate(areCorrectAnswers, form);

        FormResultsManager.Instance.taktTimeCalculadas = tiempoTakt;
        FormResultsManager.Instance.tiempoCicloCalculadas = tiempoCiclo;
        FormResultsManager.Instance.unidadesProducidasCalculadas = unidadesProducidas;

        FormResultsManager.Instance.unidadesProducidasNoCumplen = QuestSampling.Instance.CurrentOperationData.unidadesRealizadas;
    }
        public void Submit()
    {
        if (!validator.CheckIsEmpty())
        {
            SaveDataInFile();
            ValidateIfDataIsCorrect();

            form.SetActive(false);
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
    public void RellenarDatosMuestreo()
    {
        tTotalDispDiario = ((horas * 60) - descansos) * numOperarios * turnos;

        tiempoOptimo = tTotalDispDiario / QuestSampling.Instance.CurrentOperationData.requiredUnits;
        tiempoTakt = tiempoOptimo;

        tiempoCiclo = ((QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo * (QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion / 100) *
            (QuestSampling.Instance.CurrentOperationData.factorRitmo / 100) * (1f + (QuestSampling.Instance.CurrentOperationData.K / 100f)))) / QuestSampling.Instance.CurrentOperationData.unidadesRealizadas;
        unidadesProducidas = tTotalDispDiario / tiempoCiclo;
        TOInput.text = tiempoOptimo.ToString();
        TCInput.text = tiempoCiclo.ToString();
        UPInput.text = unidadesProducidas.ToString();


    }
}
