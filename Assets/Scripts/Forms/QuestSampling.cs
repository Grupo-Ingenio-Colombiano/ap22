using UnityEngine;

public class QuestSampling : MonoBehaviour
{
    public static QuestSampling Instance;

    public OperationData CurrentOperationData { get; private set; }


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
        IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
        HelpManager.Instance().SetHelp("Dirijase con el supervisor de planta");
        var randomOperation = Random.Range(1, 4);
        CurrentOperationData = new OperationData(randomOperation, 1);
        FormResultsManager.Instance.currentOperationIndex = randomOperation;
        ActivateObjects();
    }

    void ActivateObjects()
    {
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

    }

}
