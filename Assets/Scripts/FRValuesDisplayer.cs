using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FRValuesDisplayer : MonoBehaviour
{
    [SerializeField] Text[] frValueLabels;




    private void OnEnable()
    {
        int[] frValues = QuestTiming.Instance.CurrentOperationData.rhytmfFactors;

        for (int i = 0; i < frValueLabels.Length; i++)
        {
            frValueLabels[i].text = frValues[i].ToString();
        }
    }
}
