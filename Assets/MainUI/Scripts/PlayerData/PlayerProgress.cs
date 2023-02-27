using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProgress : ScriptableObject
{

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

        if (OnProgressMade != null)
        {
            OnProgressMade(CurrentProgressPercentage);
        }

    }

    public void ResetProgress()
    {
        CurrentProgress = 0;
        OnProgressMade(CurrentProgressPercentage);
    }

}