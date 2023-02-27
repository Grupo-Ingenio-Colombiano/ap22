using UnityEngine;

public class QuestHistorical : MonoBehaviour
{
    public static QuestHistorical Instance;

    public OperationData CurrentOperationData { get; private set; }


    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] GameObject dataSelector;
    [SerializeField] GameObject historicalForm;
    [SerializeField] GameObject historicalDataViewer;
    [SerializeField] GameObject operator2;
    [SerializeField] GameObject operator1;

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
    }

    private void Start()
    {
        SetHistoricalQuest();
    }


    public void SetHistoricalQuest()
    {
        IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
        HelpManager.Instance().SetHelp("Dirijase con el supervisor de planta, si tiene dudas de su ubicación recuerde consultar el plot plan, este se encuentra en el costado derecho.");
        var randomOperation = Random.Range(1, 4);
        //var randomOperation = 3;
        CurrentOperationData = new OperationData(randomOperation, 0);
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

    public void EnableDataSelector()
    {
        dataSelector.SetActive(true);
        operator2.SetActive(true);
        operator1.SetActive(false);
    }

    public void EnableForm()
    {
        HelpManager.Instance().SetHelp("Puede consultar la Ficha de datos historicos en el bloc de notas, para revisarlo haga clic en el botón que se encuentra en el costado derecho.");
        historicalForm.SetActive(true);
        historicalDataViewer.SetActive(true);
    }

    public void SetIndicator()
    {
        HelpManager.Instance().SetHelp("Dirijase con el supervisor de planta");
        IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
    }

}
