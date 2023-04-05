using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProgress : ScriptableObject
{


    public UserData data;
    float maxProgress = 100f;
    public float CurrentProgress;

    public float CurrentProgressPercentage
    {
        get { return (float)CurrentProgress / maxProgress; }
    }

    public float MaxProgress
    {
        get { return maxProgress; }
        set { maxProgress = value; }
    }

    public event Action<float> OnProgressMade = delegate { };


    private void OnEnable()
    {
        ResetProgress();
    }


    public void AddProgressPercentage(float percentage)
    {
        CurrentProgress += percentage;
        data.progress = CurrentProgress;

        if (OnProgressMade != null)
        {
            OnProgressMade(CurrentProgressPercentage);
        }

    }

    public void ResetProgress()
    {
        CurrentProgress = 0;
        data.progress = CurrentProgress;
        OnProgressMade(CurrentProgressPercentage);
    }

}