using UnityEngine;

public class QuestTiming : MonoBehaviour
{
    public static QuestTiming Instance;

    public OperationData CurrentOperationData { get; private set; }


    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] GameObject timingForm;

    [SerializeField] GameObject operator2;
    [SerializeField] GameObject operator1;

    [SerializeField] Vector3[] cronoIndicatorPositions;
    [SerializeField] UserData userData;

    public bool isSetTimer = false;

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
        SetQuest();
    }

    public void SetQuest()
    {
        IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
        HelpManager.Instance().SetHelp("Dirijase con el supervisor de planta");
        if (userData.load >= 2 && userData.method == 2)
        {
            CurrentOperationData = new OperationData(userData.indexOperationData, 2, userData);
            IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
            FormResultsManager.Instance.currentOperationIndex = userData.indexOperationData;
        }
        else
        {
            var randomOperation = Random.Range(1, 4);         
            CurrentOperationData = new OperationData(randomOperation, 2);
            userData.indexOperationData = randomOperation;
            userData.kCronometraje = CurrentOperationData.K;

            //CurrentOperationData = new OperationData(1, 2);//TO ERASE

            FormResultsManager.Instance.currentOperationIndex = randomOperation;
        }
       
        ActivateQuestObjects();
    }


    void ActivateQuestObjects()
    {
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            objectsToActivate[i].SetActive(true);
        }
    }


    public void EnableCronometer()
    {
        isSetTimer = true;
        HelpManager.Instance().SetHelp(
            "Realice la toma de tiempos de la operación con su cronómetro." /*+"e identifique el factor de ritmo con el cual está trabajando el operario. "*/ +
            "Se recomienda que visualice al menos dos ciclos de la operación antes de realizar la respectiva toma de tiempos, para que pueda identificar adecuadamente el momento de inicio y de fin");
        CronoTrigger.instance().SetPosition(cronoIndicatorPositions[CurrentOperationData.Index - 1]);
    }


    public void EnableForm()
    {
        timingForm.SetActive(true);

    }


}
