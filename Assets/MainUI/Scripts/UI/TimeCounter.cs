using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{

    [SerializeField] Text timer;

    [SerializeField]
    UserData userData;

    float second = 1;
    private float savedTime;

    DateTime startTime;

    private void Start()
    {


        float dataTime;

        float.TryParse(userData.tiempoTotal, out dataTime);
        if (dataTime > 0)
        {
            savedTime = dataTime;

        }
        startTime = System.DateTime.Now - TimeSpan.FromSeconds(savedTime);

    }

    private void Update()
    {
        second -= Time.deltaTime;
        if (second <= 0)
        {
            second = 1;
            var countedTime = CountTimeFrom(startTime);
            timer.text = countedTime.ToString(@"hh\:mm\:ss");
            userData.tiempoTotal = countedTime.TotalSeconds.ToString("F0");
            userData.time = timer.text;
        }

    }

    TimeSpan CountTimeFrom(DateTime startTime)
    {
        var result = System.DateTime.Now - startTime;
        return result;
    }


}