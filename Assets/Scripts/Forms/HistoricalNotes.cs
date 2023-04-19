using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoricalNotes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unidadesRequeridas;
    [SerializeField] UserData userData;

    private void OnEnable()
    {
        if (userData.load >= 1)
        {
            unidadesRequeridas.text = userData.proccessUnits.ToString();
        }
        else
        {
            unidadesRequeridas.text = QuestHistorical.Instance.CurrentOperationData.requiredUnits.ToString();
        }

    }



}
