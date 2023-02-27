using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProdUnits : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textInfo;
    [SerializeField] string title;

    private void OnEnable()
    {
        textInfo.text = QuestSampling.Instance.CurrentOperationData.unidadesRealizadas.ToString();
    }
}
