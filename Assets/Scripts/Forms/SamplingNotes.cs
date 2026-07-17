using TMPro;
using UnityEngine;
public class SamplingNotes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unidadesRequeridas;
    [SerializeField] TextMeshProUGUI horasMuestreo;
    [SerializeField] TextMeshProUGUI tiempoDedicado;
    [SerializeField] TextMeshProUGUI factorRitmo;
    [SerializeField] TextMeshProUGUI K;
    [SerializeField] TextMeshProUGUI unidadesProcesadas;

    [SerializeField] UserData userData;

    private bool setup = false, setUpalt= false;
    private void OnEnable()
    {
        if(setup)
        {
            return;
        }
        setup = true;
        unidadesRequeridas.text+=  " " +QuestSampling.Instance.CurrentOperationData.requiredUnits.ToString();
        horasMuestreo.text += " " + (QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo / 60f).ToString();
        tiempoDedicado.text += " " + QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion.ToString();
        factorRitmo.text += " " + QuestSampling.Instance.CurrentOperationData.factorRitmo.ToString();
        K.text += " " + QuestSampling.Instance.CurrentOperationData.K.ToString() + "%";

        userData.percentageOperation = QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion;
        userData.rhythm = QuestSampling.Instance.CurrentOperationData.factorRitmo;
        userData.k = QuestSampling.Instance.CurrentOperationData.K;
        userData.unidadesProducidasMuestreo = QuestSampling.Instance.CurrentOperationData.unidadesRealizadas;
    }

    public void EnableProducedUnits()
    {
        if(setUpalt)
        {
            return;
        }
        setUpalt = true;
        unidadesProcesadas.text += QuestSampling.Instance.CurrentOperationData.unidadesRealizadas.ToString();
    }
}
