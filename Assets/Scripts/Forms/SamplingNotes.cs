using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SamplingNotes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unidadesRequeridas;
    [SerializeField] TextMeshProUGUI horasMuestreo;
    [SerializeField] TextMeshProUGUI tiempoDedicado;
    [SerializeField] TextMeshProUGUI factorRitmo;
    [SerializeField] TextMeshProUGUI K;
    [SerializeField] TextMeshProUGUI unidadesProcesadas;


    private void OnEnable()
    {
        unidadesRequeridas.text = QuestSampling.Instance.CurrentOperationData.requiredUnits.ToString();
        horasMuestreo.text = (QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo / 60f).ToString();
        tiempoDedicado.text = QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion.ToString();
        factorRitmo.text = QuestSampling.Instance.CurrentOperationData.factorRitmo.ToString();
        K.text = QuestSampling.Instance.CurrentOperationData.K.ToString();


    }

    public void EnableProducedUnits()
    {
        unidadesProcesadas.text = QuestSampling.Instance.CurrentOperationData.unidadesRealizadas.ToString();
    }

}
