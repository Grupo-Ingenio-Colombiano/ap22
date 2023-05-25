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

    [SerializeField] UserData userData;
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
    }

    private void Start()
    {
         SetHistoricalQuest();
       

    }


    public void SetHistoricalQuest()
    {
        //IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
        HelpManager.Instance().SetHelp("Dirijase con el supervisor de planta, si tiene dudas de su ubicación recuerde consultar el plot plan, este se encuentra en el costado derecho.");
        
        if (userData.load >= 2 && userData.method ==1)
        {
            CurrentOperationData = new OperationData(userData.indexOperationData, 0, userData);
            IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));          
            FormResultsManager.Instance.currentOperationIndex = userData.indexOperationData;
            notesManager.EnablePage(0);
           
            
        }
        else
        {
            IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
            var randomOperation = Random.Range(1, 4);
            userData.indexOperationData = randomOperation;
            //var randomOperation = 3;
            CurrentOperationData = new OperationData(randomOperation, 0);
            userData.proccessUnits = CurrentOperationData.requiredUnits;
            userData.minTimeHistorical = CurrentOperationData.minTime;
            userData.maxTimeHistorical = CurrentOperationData.maxTime;
            userData.modalTimeHistorical = CurrentOperationData.modalTime;
            FormResultsManager.Instance.currentOperationIndex = randomOperation;
                     
        }
        ActivateObjects();
        notesManager.EnablePage(0);
    }


    void ActivateObjects()
    {
        if(userData.load >= 2 && userData.method == 1)
        {
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(true);
            }
        }
       
    }

    public void UserDataLoad()
    {
        userData.questsCheck = true;
    }
    public void EnableDataSelector()
    {
        dataSelector.SetActive(true);
        operator2.SetActive(true);
        operator1.SetActive(false);
    }

    public void EnableForm()
    {
        HelpManager.Instance().SetHelp("Puede consultar la Ficha de datos historicos, para revisarlo haga clic en el botón que se encuentra en el costado derecho debajo del botón para hablar.");
        historicalForm.SetActive(true);
        historicalDataViewer.SetActive(true);
        notesManager.EnablePage(0);

    }

    public void SetIndicator()
    {
        HelpManager.Instance().SetHelp("Dirijase con el supervisor de planta");
        IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
    }

}
