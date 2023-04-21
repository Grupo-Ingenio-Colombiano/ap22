using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoricalDataFile : MonoBehaviour
{

    [SerializeField] Text[] historicalDataTexts;
    [SerializeField] bool isCorrectData;
    [SerializeField] bool notEnoughData;
    [SerializeField] bool isNotCorrectData;

    [SerializeField] ExperienceRewardManager rewardManager;

    [SerializeField] UserData userData;

    void Start()
    {
        SetDataInFile();
    }

    void SetDataInFile()
    {
        var dataCount = QuestHistorical.Instance.CurrentOperationData.historicalSamples.Length;
        var minTime = QuestHistorical.Instance.CurrentOperationData.minTime;
        var maxTime = QuestHistorical.Instance.CurrentOperationData.maxTime;
        float [] historicalSamples = QuestHistorical.Instance.CurrentOperationData.historicalSamples;
      
     
        if(userData.load >= 2)
        {
            QuestHistorical.Instance.CurrentOperationData.requiredUnits = userData.proccessUnits;

            for (int i = 0; i < dataCount; i++)
            {
                historicalDataTexts[i].text = userData.historicData[i].ToString();
               
            }
        }
        else
        {
            if (isCorrectData)
            {
                for (int i = 0; i < dataCount; i++)
                {
                    historicalDataTexts[i].text = historicalSamples[i].ToString();
                    userData.historicData[i] = historicalSamples[i];
                }
            }
          
        }
        if (notEnoughData)
        {
            for (int i = 0; i < 20; i++)
            {
                historicalDataTexts[i].text = Random.Range(minTime, maxTime).ToString();
            }

            for (int i = 20; i < dataCount; i++)
            {
                historicalDataTexts[i].text = "";
            }
        }

        if (isNotCorrectData)
        {
            var bias = 3.0f;
            for (int i = 0; i < dataCount; i++)
            {
                historicalDataTexts[i].text = (historicalSamples[i] + Random.Range(minTime - bias, maxTime + bias)).ToString();
            }
        }


    }

    public void Submit()
    {

        if (!isCorrectData)
        {
            GameManager.scoreSelectData -= 10;
            rewardManager.FailAttempt();
        }

    }

}
