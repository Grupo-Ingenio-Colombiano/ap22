using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{

    [SerializeField] Text timer;

    [SerializeField]
    UserData data;

    public static float timeAux;

    private void Start()
    {
        timeAux = 0;
        if (data.isSave == true)
        {
            timer.text = data.timer;

        }

    }

    private void Update()
    {
        var timeSpan = TimeSpan.FromSeconds(Math.Round(Time.realtimeSinceStartup - timeAux));
        if (data.isSave == true)
        {
            timeSpan = TimeSpan.FromSeconds(Math.Round(Time.realtimeSinceStartup - timeAux) + Int32.Parse(timer.text));

        }

        timer.text = timeSpan.ToString();

        data.timer = timer.text;

      
    }

}