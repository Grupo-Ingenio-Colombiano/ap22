using UnityEngine;

public class QuestSampling : MonoBehaviour
{
    public static QuestSampling Instance;

    public OperationData CurrentOperationData { get; private set; }

    [SerializeField] SamplingRegisterCalculations samplingRegisterCalculations;

    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] GameObject[] infoObjects;
    [SerializeField] GameObject[] infoCapsuleObjects;
    [SerializeField] GameObject operatorInfo;

    [SerializeField] GameObject samplingForm;
    [SerializeField] SamplingNotes samplingNotes;
    [SerializeField] GameObject genericClock;

    [SerializeField] GameObject operator2;
    [SerializeField] GameObject operator1;

    [SerializeField] GameObject supervisor2;
    [SerializeField] GameObject supervisor1;

    [SerializeField] UserData userData;
    [SerializeField] LoadManager loadManager;

    [SerializeField] NotesManager notesManager;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SetSamplingQuest();
    }

    public void SetSamplingQuest()
    {
      
        HelpManager.Instance().SetHelp("Diríjase con el supervisor de planta");
        if (userData.load >= 2 && userData.method == 2 )
        {
            CurrentOperationData = new OperationData(userData.indexOperationData, 1, userData);
            IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
            FormResultsManager.Instance.currentOperationIndex = userData.indexOperationData;
            samplingRegisterCalculations.requiredUnits.text = CurrentOperationData.requiredUnits.ToString();
            samplingRegisterCalculations.Calculate();
            SwapOperator();
            
        }
        else
        {
            IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
            do
            {
                var randomOperation = Random.Range(1, 4);
                userData.indexOperationData = randomOperation;
                CurrentOperationData = new OperationData(randomOperation, 1);
                userData.proccessUnits = CurrentOperationData.requiredUnits;
                userData.numMinutos = CurrentOperationData.numMinutosMuestreo;
                userData.percentageOperation = CurrentOperationData.porcentajeDedicadoOperacion;
                userData.rhythm = CurrentOperationData.factorRitmo;
                userData.k = CurrentOperationData.K;
                userData.unidadesProducidasMuestreo = CurrentOperationData.unidadesRealizadas;
                FormResultsManager.Instance.currentOperationIndex = randomOperation;
                samplingRegisterCalculations.requiredUnits.text = CurrentOperationData.requiredUnits.ToString();
                samplingRegisterCalculations.Calculate();
            }
            while(samplingRegisterCalculations.tiempoTakt >= samplingRegisterCalculations.tiempoCiclo);                    
        }

        notesManager.EnablePage(1);
        ActivateObjects();
    }

    void ActivateObjects()
    {
        Debug.Log("Activar Objetos");
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            objectsToActivate[i].SetActive(true);
        }
    }

    public void EnableGenericClock()
    {
        genericClock.SetActive(true);
    }

    public void DisableGenericClock()
    {
        genericClock.SetActive(false);
        IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
    }

    public void EnableForm()
    {
        samplingForm.SetActive(true);
    }

    public void SwapOperator()
    {
        operator2.SetActive(true);
        operatorInfo.SetActive(true);
        operator1.SetActive(false);
        supervisor1.SetActive(false);
        supervisor2.SetActive(true);
        samplingNotes.EnableProducedUnits();
    }

    public void EnableCountElement()
    {
        infoObjects[CurrentOperationData.Index - 1].GetComponent<InfoObject>().enabled = true;
        infoCapsuleObjects[CurrentOperationData.Index - 1].SetActive(true);
        infoObjects[CurrentOperationData.Index - 1].GetComponent<MouseOverEvent>().enabled = true;
        HelpManager.Instance().SetHelp("Realice el conteo de unidades dando clic sobre el carro indicado, luego hable nuevamente con el supervisor");
        loadManager.Upload(2);

    }

}
