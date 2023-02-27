using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FRPValues : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FRtextInfo;
    [SerializeField] TextMeshProUGUI PtextInfo;

    private void OnEnable()
    {
        FRtextInfo.text = QuestSampling.Instance.CurrentOperationData.factorRitmo.ToString();
        PtextInfo.text = QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion.ToString() + "%";
    }
}
