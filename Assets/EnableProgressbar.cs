using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableProgressbar : MonoBehaviour
{
    [SerializeField] Canvas progressbar;

    [SerializeField] QuestTiming quest;

    public void EnableProgressBar()
    {
        if (QuestTiming.Instance != null && QuestTiming.Instance.isSetTimer)
        {
            progressbar.enabled = true;
        }
    }

    public void DisableProgressBar()
    {
        progressbar.enabled = false;
    }
}
