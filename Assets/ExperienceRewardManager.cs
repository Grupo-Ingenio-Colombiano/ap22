using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceRewardManager : MonoBehaviour
{
    int currentAttempts;
    [SerializeField] UserData userData;
    
    
    private void Start()
    {

    }
    
    public int GetCurrentAttempts()
    {
        return currentAttempts;
    }

    public void SetCurrentAttempts(int value)
    {
        currentAttempts = value;
    }

    void Awake()
    {
        SetCurrentAttempts(3);
        
    }

    public void AddScore()
    {
        PlayerDataManager.Instance.AddExperience(GetCurrentAttempts() * 40);
        PlayerDataManager.Instance.AddProgress(25);
    }
   

    public void FailAttempt()
    {

        if (GetCurrentAttempts() > 0)
        {
            //print("fallo intento en" + gameObject.name);

            SetCurrentAttempts(GetCurrentAttempts() - 1);
        }
    }

}
