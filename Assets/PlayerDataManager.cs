using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance { get; private set; }

    [SerializeField] PlayerExperience playerExperience;
    [SerializeField] PlayerProgress playerProgress;
    [SerializeField] PlayerAnswers playerAnswers;


    [SerializeField] UserData userData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(userData.isSave != false)
        {
            for (int i = 0; i < userData.badAnswer; i++)
            {

            }
            for (int i = 0; i < userData.goodAnswer; i++)
            {

            }
        }
    }
    public void AddIncorrect()
    {
        playerAnswers.AddIncorrectAnswer();
    }

    public void AddCorrect()
    {
        playerAnswers.AddCorrectAnswer();
    }

    public void AddProgress(float percentage)
    {
        playerProgress.AddProgressPercentage(percentage);
        //data.progress = percentage;
    }

    public void AddExperience(float experience)
    {
        playerExperience.AddExperience(experience);
    }

}
