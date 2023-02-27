using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerExperience : ScriptableObject
{

    float maxExperience = 500f;
    public float CurrentExperience;


    public float CurrentExperiencePercentage
    {
        get { return CurrentExperience / MaxExperience; }
    }

    public float MaxExperience
    {
        get { return maxExperience; }

        set { maxExperience = value; }
    }

    public event Action<float> OnExperienceObtained = delegate { };

    private void OnEnable()
    {
        ResetExperience();
    }

    public void AddExperience(float experience)
    {
        CurrentExperience += experience;

        if (CurrentExperience < 0)
        {
            CurrentExperience = 0;
        }

        if (OnExperienceObtained != null)
        {
            OnExperienceObtained(CurrentExperiencePercentage);
        }

    }

    public void EditCurrentExperienceValue(float newExperienceValue)
    {
        CurrentExperience = newExperienceValue;
    }


    public void ResetExperience()
    {
        CurrentExperience = 0;
        OnExperienceObtained(CurrentExperiencePercentage);
    }

}