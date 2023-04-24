using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingFormValuesDistrib : MonoBehaviour
{
    [SerializeField] Text[] values;



    private void OnEnable()
    {
        SetValues();
    }

    void SetValues()
    {
      
        var currentTimeValues = QuestTiming.Instance.CurrentOperationData.historicalSamples;
        var currentFRValues = QuestTiming.Instance.CurrentOperationData.rhytmfFactors;
        


        float[] col1 = new float[5];
        float[] col2 = new float[7];
        float[] col3 = new float[10];
        float[] col4 = new float[7];
        float[] col5 = new float[5];

        int col1Count = 0;
        int col2Count = 0;
        int col3Count = 0;
        int col4Count = 0;
        int col5Count = 0;



        for (int i = 0; i < currentFRValues.Length; i++)
        {
            if (currentFRValues[i] == 85)
            {
                values[0].text = currentTimeValues[i].ToString();
                HistoricalAnswerData.campana85 = currentTimeValues[i].ToString();
            }

            if (currentFRValues[i] == 115)
            {
                values[35].text = currentTimeValues[i].ToString();
                HistoricalAnswerData.campana115 = currentTimeValues[i].ToString();
            }

            if (currentFRValues[i] == 90)
            {
                col1[col1Count] = currentTimeValues[i];
                //print(i + ": 90  " + col1Count);
                HistoricalAnswerData.campana90[col1Count] = currentTimeValues[i].ToString();
                col1Count++;
            }

            if (currentFRValues[i] == 95)
            {
                col2[col2Count] = currentTimeValues[i];
                //print(i + ": 95  " + col2Count);
                HistoricalAnswerData.campana95[col2Count] = currentTimeValues[i].ToString();
                col2Count++;
            }

            if (currentFRValues[i] == 100)
            {
                col3[col3Count] = currentTimeValues[i];
                //print(i + ": 100  " + col3Count);
                HistoricalAnswerData.campana100[col3Count] = currentTimeValues[i].ToString();
                col3Count++;
            }

            if (currentFRValues[i] == 105)
            {
                col4[col4Count] = currentTimeValues[i];
                //print(i + ": 105  " + col4Count);
                HistoricalAnswerData.campana105[col4Count] = currentTimeValues[i].ToString();
                col4Count++;
            }

            if (currentFRValues[i] == 110)
            {
                col5[col5Count] = currentTimeValues[i];
                //print(i + ": 110  " + col5Count);
                HistoricalAnswerData.campana110[col5Count] = currentTimeValues[i].ToString();
                col5Count++;
            }

        }

        var temp = 1;
        for (int i = 0; i < 5; i++)
        {
            values[temp].text = col1[i].ToString();
            temp++;
        }

        for (int i = 0; i < 7; i++)
        {
            values[temp].text = col2[i].ToString();
            temp++;
        }

        for (int i = 0; i < 10; i++)
        {
            values[temp].text = col3[i].ToString();
            temp++;
        }

        for (int i = 0; i < 7; i++)
        {
            values[temp].text = col4[i].ToString();
            temp++;
        }

        for (int i = 0; i < 5; i++)
        {
            values[temp].text = col5[i].ToString();
            temp++;
        }


    }

}
