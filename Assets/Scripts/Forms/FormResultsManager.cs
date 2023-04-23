using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormResultsManager : MonoBehaviour
{
    [SerializeField] GameObject correct;
    [SerializeField] GameObject incorrect;
    [SerializeField] GameObject outSupervisor;

    [SerializeField] GameObject[] oldSupervisors;
    [SerializeField] GameObject[] oldOperators;
    [SerializeField] GameObject reward;
    [SerializeField] ExperienceRewardManager expRewardManager;
    [SerializeField] GameObject sadSequenceActivationObject;
    [SerializeField] GameObject turnOperatorSequenceActivationObject;
    [SerializeField] LoadManager loadManager;

    GameObject currentForm;

    int currentAttempts = 3;

    public float unidadesProdPosiblesIngresadas;
    public float unidadesRequeridas;
    public float taktTime;
    public float tiempoCiclo;

    public float unidadesProducidasNoCumplen;

    public float unidadesProducidasCalculadas;
    public float taktTimeCalculadas;
    public float tiempoCicloCalculadas;

    public int UsersCalculate;

    public int UsersInput;

    public int currentOperationIndex = 0;

    public string canAcomplishDailyGoal;
    public string TCTTComparison;

    public static FormResultsManager Instance;

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

    public void TestEvaluate()
    {
        bool[] test = { true };

        Evaluate(test, gameObject);
    }


    public void Evaluate(bool[] areCorrect, GameObject form)
    {

        currentForm = form;

        DisableOldSupervisors();
        DisableOldOperators();

        SetConversationsAnswers();

        bool allAnswersAreCorrect = true;

        allAnswersAreCorrect = CheckCorrectAnswers(areCorrect);//, allAnswersAreCorrect);

        SetAnswerObjects(allAnswersAreCorrect);
    }

    private void SetAnswerObjects(bool allAnswersAreCorrect)
    {
        if (allAnswersAreCorrect || DebugHelper.IsProjectSetToTest)
        {
            incorrect.SetActive(false);
            correct.SetActive(true);
            expRewardManager.AddScore();
        }else
        {
            GameManager.scoreFormTCiclo -= 10;
            currentAttempts--;
            expRewardManager.FailAttempt();
            //print("cosito = " + expRewardManager.GetCurrentAttempts());

            if (currentAttempts <= 0)
            {
                incorrect.SetActive(false);
                outSupervisor.SetActive(true);
            }else
            {
                /*if (Debug.isDebugBuild && currentAttempts == 1)
                {
                    incorrect.SetActive(false);
                    correct.SetActive(true);
                    expRewardManager.AddScore();
                }
                else
                {
                    incorrect.SetActive(true);
                }*/
                correct.SetActive(false);
                incorrect.SetActive(true);
            }

        }
    }

    public bool CheckCorrectAnswers(bool[] areCorrect)
    {
        bool value = true;

        for (int i = 0; i < areCorrect.Length; i++)
        {
            //print(areCorrect[i] + "  RESPUESTA CORRECTA " + i);
            if (!areCorrect[i])
            {
                Debug.Log("ALGUNA RESPUESTA ESTA MAL "+ i);
                value = false;
                break;
            }
           
        }


        return value;
    }


    public void ActivateSadSequence()
    {
        outSupervisor.SetActive(true);

        sadSequenceActivationObject.SetActive(true);
        sadSequenceActivationObject.GetComponent<SadEscene>().SetMesagge("No ha logrado realizar la practica correctamente, intentelo nuevamente");

    }

    public void GoBackToForm()
    {
        currentForm.SetActive(true);
    }

    public void ActivateReward()
    {
        GameObject.FindWithTag("TextContainer").GetComponentInParent<Canvas>().enabled = false;
        reward.SetActive(true);
    }

    void DisableOldSupervisors()
    {
        for (int i = 0; i < oldSupervisors.Length; i++)
        {
            oldSupervisors[i].SetActive(false);
        }
    }

    void DisableOldOperators()
    {
        for (int i = 0; i < oldOperators.Length; i++)
        {
            Destroy(oldOperators[i].GetComponentInParent<VIDE_Assign>());
            oldOperators[i].SetActive(false);
        }
    }

    void SetConversationsAnswers()
    {
        canAcomplishDailyGoal = (unidadesProdPosiblesIngresadas >= unidadesRequeridas) ? "si" : "no";
        TCTTComparison = (tiempoCiclo == taktTime) ? "igual" : (tiempoCiclo < taktTime) ? "inferior" : "superior";
    }

    public void EnableTurnsOperatorsSequence()
    {
        turnOperatorSequenceActivationObject.SetActive(true);
    }

}
