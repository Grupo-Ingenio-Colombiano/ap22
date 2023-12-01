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
    [SerializeField] UserData userData;
    private void OnEnable()
    {
        requiredUnits.text = QuestSampling.Instance.CurrentOperationData.requiredUnits.ToString();
    }

    public void Calculate() //calculos 
    {
        bool[] areCorrectAnswers = { true, true, true };

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

        tOptimoIngresado = float.Parse(TOInput.text);
        tCicloIngresado = float.Parse(TCInput.text);
        uProducidasIngresado = float.Parse(UPInput.text);
        userData.excelReport[0].M[15] = tiempoOptimo.ToString();
        userData.excelReport[0].M[16] = tiempoCiclo.ToString();
        userData.excelReport[0].M[17] = unidadesProducidas.ToString();

        areCorrectAnswers[0] = DataChecker.IsDataCorrect(tOptimoIngresado, tiempoOptimo, 0.1f, "Tiempo optimo");
        areCorrectAnswers[1] = DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo Ciclo");
        areCorrectAnswers[2] = DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 1f, "unidades Producidas");
        userData.excelReport[0].M[19] = yesNo.isOn ? "Si" : "No";

        print(yesNo.isOn ? "Si" : "No" + " Cumple");


        if (DataChecker.IsDataCorrect(tOptimoIngresado, tiempoOptimo, 0.1f, "Tiempo optimo") == true
          && DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo Ciclo") == true
          && DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 1f, "unidades Producidas") == true)
        {

            PlayerDataManager.Instance.AddExperience(350);
            PlayerDataManager.Instance.AddProgress(25);
        }

        print("tiempo optimo " + tiempoOptimo);
        print("tiempo ciclo  " + tiempoCiclo);
        print("unidades producidas " + unidadesProducidas);
        FormResultsManager.Instance.unidadesProdPosiblesIngresadas = uProducidasIngresado;
        FormResultsManager.Instance.unidadesRequeridas = QuestSampling.Instance.CurrentOperationData.requiredUnits;
        FormResultsManager.Instance.tiempoCiclo = tCicloIngresado;
        FormResultsManager.Instance.taktTime = tOptimoIngresado;//tiempoTakt;

        FormResultsManager.Instance.Evaluate(areCorrectAnswers, gameObject);

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
