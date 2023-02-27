using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoricalOperatorManager : MonoBehaviour
{
    [SerializeField] GameObject animatedCorteOperator;
    [SerializeField] GameObject animatedDobladoOperator;
    [SerializeField] GameObject animatedRectificadoOperator;

    [SerializeField] GameObject CorteCharacter;
    [SerializeField] GameObject DobladoCharacter;
    [SerializeField] GameObject RectificadoCharacter;

    [SerializeField] Vector3 toSetPosition1;
    [SerializeField] Vector3 toSetPosition2;
    [SerializeField] Vector3 toSetPosition3;


    void Start()
    {
        var operatorType = QuestHistorical.Instance.CurrentOperationData.Index;

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

        //IndicatorManager.instance().SetDestiny(transform.position);

    }

    public void SetIndicator()
    {
        IndicatorManager.instance().SetDestiny(transform.position);
        HelpManager.Instance().SetHelp("Dirijase al área indicada, si tiene dudas hable nuevamente con el supervisor");
    }
}
