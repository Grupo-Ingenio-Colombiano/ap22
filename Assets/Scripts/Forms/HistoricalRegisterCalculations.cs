using System.Collections;
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

    public float tiempoOptimo;
    public float tiempoTakt;
    public float tiempoModal;
    public float tiempoPesimista;

    public float tiempoCiclo;

    public float unidadesProducidas;

    public float tOptimoIngresado;
    public float tCicloIngresado;
    public float uProducidasIngresado;

    [SerializeField] public Text requiredUnits;
    [SerializeField] GameObject form;
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

    private const int experience = 75;
    private void Start()
    {
        userData.experienceTalkTimeHistorical = experience;
        userData.experienceTiempoOptimoHistorical = experience;
        userData.experienceUnidadesrequeridasHistorical = experience;
        userData.experienceQuestionHistorical = experience;
    }
    public void Calculate() //calculos 
    {
        foreach (var item in QuestHistorical.Instance.CurrentOperationData.historicalSamples)
        {
            print("Dato : " +item );
        }
        tiempoModal = QuestHistorical.Instance.CurrentOperationData.modalTime;
        tiempoPesimista = QuestHistorical.Instance.CurrentOperationData.historicalSamples.Max();
        tTotalDispDiario = ((horas * 60) - descansos) * numOperarios * turnos;

        tiempoOptimo = tTotalDispDiario / QuestHistorical.Instance.CurrentOperationData.requiredUnits;
        tiempoTakt = tiempoOptimo;
        tiempoCiclo = (tiempoOptimo + 4 * tiempoModal + tiempoPesimista) / 6f;
        unidadesProducidas = tTotalDispDiario / tiempoCiclo;

        print("Required Units" + QuestHistorical.Instance.CurrentOperationData.requiredUnits);
        print("tiempo optimo " + tiempoOptimo);
        print("tiempo ciclo  " + tiempoCiclo);
        print("unidades producidas " + unidadesProducidas);

        userData.talkTimeHistorical = tiempoTakt;
        userData.tiempoCicloHistorical = tiempoCiclo;
        userData.unidadesRequeridasHistorical = unidadesProducidas;

        userData.excelReport[0].M[27] = tiempoOptimo.ToString("F2");
        userData.excelReport[0].M[28] = tiempoCiclo.ToString("F2");
        userData.excelReport[0].M[29] = unidadesProducidas.ToString("F2");

        userData.excelReport[0].M[31] = yesNo.isOn ? "Si" : "No";
       

    }
    private void ValidateIfDataIsCorrect()
    {
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
                PlayerDataManager.Instance.AddExperience(userData.experienceTalkTimeHistorical);
            }
        }
        else
        {
            userData.experienceTalkTimeHistorical -= Mathf.RoundToInt(experience * 0.33f);
            if(userData.experienceTalkTimeHistorical < 0)
            {
                userData.experienceTalkTimeHistorical = 0;
            }
        }
        if(DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo Ciclo") == true)
        {
            if(TCInput.interactable) 
            {
                TCInput.interactable = false;
                TCInput.textComponent.color = new Color(0.01f, 0.85f, 0);
                PlayerDataManager.Instance.AddExperience(userData.experienceTiempoOptimoHistorical);
            }          
        }
        else
        {
            userData.experienceTiempoOptimoHistorical -= Mathf.RoundToInt(experience * 0.33f);
            if (userData.experienceTiempoOptimoHistorical < 0)
            {
                userData.experienceTiempoOptimoHistorical = 0;
            }
        }
        if(DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 1f, "unidades Producidas") == true && UPInput.interactable)
        {
            if (UPInput.interactable)
            {
                UPInput.interactable = false;
                UPInput.textComponent.color = new Color(0.01f, 0.85f, 0);
                PlayerDataManager.Instance.AddExperience(userData.experienceUnidadesrequeridasHistorical);
            }           
        }
        else
        {
            userData.experienceUnidadesrequeridasHistorical -= Mathf.RoundToInt(experience * 0.33f);
            if (userData.experienceUnidadesrequeridasHistorical < 0)
            {
                userData.experienceUnidadesrequeridasHistorical = 0;
            }
        }
        if(!yesNo.isOn && yesNo.interactable)
        {
            if (yesNo.interactable)
            {
                yesNo.interactable = false;
                PlayerDataManager.Instance.AddExperience(userData.experienceQuestionHistorical);
            }           
        }
        else
        {
            userData.experienceQuestionHistorical -= Mathf.RoundToInt(experience * 0.33f);
            if (userData.experienceQuestionHistorical < 0)
            {
                userData.experienceQuestionHistorical = 0;
            }
        }
        userData.justifHistorical = justifInput.text;
        FormResultsManager.Instance.unidadesProdPosiblesIngresadas = uProducidasIngresado;
        FormResultsManager.Instance.unidadesRequeridas = QuestHistorical.Instance.CurrentOperationData.requiredUnits;

        FormResultsManager.Instance.tiempoCiclo = tCicloIngresado;
        FormResultsManager.Instance.taktTime = tOptimoIngresado;//tiempoTakt;

        FormResultsManager.Instance.unidadesProducidasNoCumplen = unidadesProducidas;

        FormResultsManager.Instance.Evaluate(areCorrectAnswers, form);

        FormResultsManager.Instance.taktTimeCalculadas = tiempoTakt;
        FormResultsManager.Instance.tiempoCicloCalculadas = tiempoCiclo;
        FormResultsManager.Instance.unidadesProducidasCalculadas = unidadesProducidas;
    }
    private void SetUserInputValues()
    {
        tOptimoIngresado = float.Parse(TOInput.text);
        tCicloIngresado = float.Parse(TCInput.text);
        uProducidasIngresado = float.Parse(UPInput.text);
    }

    public void Submit()
    {
        if (!validator.CheckIsEmpty())
        {
            SetUserInputValues();
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
    public void RellenarDatosHistoricos()
    {
        tiempoModal = QuestHistorical.Instance.CurrentOperationData.modalTime;
        tiempoPesimista = QuestHistorical.Instance.CurrentOperationData.historicalSamples.Max();
        tTotalDispDiario = ((horas * 60) - descansos) * numOperarios * turnos;

        tiempoOptimo = tTotalDispDiario / QuestHistorical.Instance.CurrentOperationData.requiredUnits;
        tiempoTakt = tiempoOptimo;
        tiempoCiclo = (tiempoOptimo + 4 * tiempoModal + tiempoPesimista) / 6f;
        unidadesProducidas = tTotalDispDiario / tiempoCiclo;
        TOInput.text = tiempoOptimo.ToString();
        TCInput.text = tiempoCiclo.ToString();
        UPInput.text = unidadesProducidas.ToString();
            

     }
}
