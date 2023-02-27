using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{

    [SerializeField] Text timer;

    public static float timeAux;

    private void Start()
    {
        timeAux = 0;
    }

    private void Update()
    {
        var timeSpan = TimeSpan.FromSeconds(Math.Round(Time.realtimeSinceStartup - timeAux));

        timer.text = timeSpan.ToString();
    }

}