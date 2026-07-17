using TMPro;
using UnityEngine;

public class TimingNotes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unidadesRequeridas;
    [SerializeField] TextMeshProUGUI k;

    private bool setup = false;
    private void OnEnable()
    {
        if(setup)
        {
            return;
        }
        setup = true;
        unidadesRequeridas.text += " " + QuestTiming.Instance.CurrentOperationData.requiredUnits.ToString();
        k.text += " " + QuestTiming.Instance.CurrentOperationData.K.ToString() + "%";
    }
}
