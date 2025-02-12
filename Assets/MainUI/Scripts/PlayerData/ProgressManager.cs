﻿
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{

    [SerializeField] private Image progressBar;

    [SerializeField] private Text progressPercentage;

    [SerializeField] PlayerProgress progress;

    [SerializeField] UserData userData;


    private void Start()
    {
        if (progress != null)
        {
            progress.OnProgressMade += HandleProgressBarChanged;
            progress.OnProgressMade += HandleProgressPercentageChanged;
        }
        
    }

    private void HandleProgressBarChanged(float pct)
    {
        progressBar.fillAmount = pct;
    }

    private void HandleProgressPercentageChanged(float pct)
    {
        progressPercentage.text = Mathf.Ceil(pct * 100).ToString() + "%";
        userData.progress = progress.CurrentProgress;

        if (Mathf.Ceil(pct * 100) > 98)
        {
            progressPercentage.text = "100%";
            userData.progress = 100f;
        }
    }

    private void OnDisable()
    {
        if (progress != null)
        {
            progress.OnProgressMade -= HandleProgressBarChanged;
            progress.OnProgressMade -= HandleProgressPercentageChanged;

        }
    }
}