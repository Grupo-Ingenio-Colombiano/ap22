using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingOperatorManager : MonoBehaviour
{
    [SerializeField] GameObject CorteCharacter;
    [SerializeField] GameObject DobladoCharacter;
    [SerializeField] GameObject RectificadoCharacter;

    [SerializeField] GameObject animatedCorteOperator;
    [SerializeField] GameObject animatedDobladoOperator;
    [SerializeField] GameObject animatedRectificadoOperator;

    [SerializeField] Vector3 toSetPosition1;
    [SerializeField] Vector3 toSetPosition2;
    [SerializeField] Vector3 toSetPosition3;

    [SerializeField] Canvas progressCanvas1;
    [SerializeField] Canvas progressCanvas2;
    [SerializeField] Canvas progressCanvas3;

    public GameObject padre;

    private void Update()
    {
        var operatorType = QuestTiming.Instance.CurrentOperationData.Index;

        if (operatorType == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    void Start()
    {
        var operatorType = QuestTiming.Instance.CurrentOperationData.Index;

        if (operatorType == 1)
        {
            CorteCharacter.SetActive(true);
            transform.position = toSetPosition1;
            animatedCorteOperator.SetActive(false);
        }

        if (operatorType == 2)
        {
            DobladoCharacter.SetActive(true);
            transform.position = toSetPosition2;
            animatedDobladoOperator.SetActive(false);
        }

        if (operatorType == 3)
        {
            RectificadoCharacter.SetActive(true);
            transform.position = toSetPosition3;
            animatedRectificadoOperator.SetActive(false);
        }

    }

    public void SetIndicator()
    {
        IndicatorManager.instance().SetDestiny(transform.position);
    }

    public void EnableProgressCanvas()
    {
        var operatorType = QuestTiming.Instance.CurrentOperationData.Index;

        if (operatorType == 1)
        {
            progressCanvas1.enabled = true;
        }

        if (operatorType == 2)
        {
            progressCanvas2.enabled = true;
        }

        if (operatorType == 3)
        {
            progressCanvas3.enabled = true;
        }
    }
}
