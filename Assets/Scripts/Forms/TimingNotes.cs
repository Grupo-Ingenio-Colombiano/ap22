using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimingNotes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unidadesRequeridas;
    [SerializeField] TextMeshProUGUI k;

    private void OnEnable()
    {
        unidadesRequeridas.text = QuestTiming.Instance.CurrentOperationData.requiredUnits.ToString();
        k.text = QuestTiming.Instance.CurrentOperationData.K.ToString() + "%";
    }



}
