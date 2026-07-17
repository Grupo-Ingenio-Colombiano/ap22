using TMPro;
using UnityEngine;

public class HistoricalNotes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unidadesRequeridas;
    [SerializeField] UserData userData;

    private bool setup = false;
    private void OnEnable()
    {
        if(setup)
        {
            return;
        }
        setup = true;
        unidadesRequeridas.text += " " +QuestHistorical.Instance.CurrentOperationData.requiredUnits.ToString();
    }



}
