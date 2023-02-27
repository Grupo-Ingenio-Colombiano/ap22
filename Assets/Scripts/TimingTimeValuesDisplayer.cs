using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingTimeValuesDisplayer : MonoBehaviour
{
    [SerializeField] Text[] timeValueLabels;

    int[] indexes0 = { 00 };
    int[] indexes1 = { 01, 02, 03, 04, 05 };
    int[] indexes2 = { 06, 07, 08, 09, 10, 11, 12 };
    int[] indexes3 = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
    int[] indexes4 = { 23, 24, 25, 26, 27, 28, 29, };
    int[] indexes5 = { 30, 31, 32, 33, 34 };
    int[] indexes6 = { 35 };


    private void OnEnable()
    {
        float[] timeValues = QuestTiming.Instance.CurrentOperationData.historicalSamples;
        int[] frValues = QuestTiming.Instance.CurrentOperationData.rhytmfFactors;

        for (int i = 0; i < timeValueLabels.Length; i++)
        {
            timeValueLabels[i].text = timeValues[i].ToString();
            SetCorrectPosiblePositions(frValues, i);

        }
    }

    private void SetCorrectPosiblePositions(int[] frValues, int i)
    {

        try
        {
            switch (frValues[i])
            {
                case 85:
                    timeValueLabels[i].GetComponentInParent<BoardButton>().correctPositionsIndexes = indexes0;
                    break;
                case 90:
                    timeValueLabels[i].GetComponentInParent<BoardButton>().correctPositionsIndexes = indexes1;
                    break;
                case 95:
                    timeValueLabels[i].GetComponentInParent<BoardButton>().correctPositionsIndexes = indexes2;
                    break;
                case 100:
                    timeValueLabels[i].GetComponentInParent<BoardButton>().correctPositionsIndexes = indexes3;
                    break;
                case 105:
                    timeValueLabels[i].GetComponentInParent<BoardButton>().correctPositionsIndexes = indexes4;
                    break;
                case 110:

                    timeValueLabels[i].GetComponentInParent<BoardButton>().correctPositionsIndexes = indexes5;
                    break;
                case 115:
                    timeValueLabels[i].GetComponentInParent<BoardButton>().correctPositionsIndexes = indexes6;
                    break;
                default:
                    break;
            }
        }
        catch (System.Exception)
        {
            print(timeValueLabels[i].transform.parent.name);
            print(timeValueLabels[i].GetComponentInParent<BoardButton>() != null);

        }


    }
}
