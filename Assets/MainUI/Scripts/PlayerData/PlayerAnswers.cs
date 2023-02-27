using System;
using UnityEngine;


[CreateAssetMenu]
public class PlayerAnswers : ScriptableObject
{

    public int CorrectAnswers;
    public int IncorrectAnswers;


    public event Action<int> OnIncorrectAdded = delegate { };
    public event Action<int> OnCorrectAdded = delegate { };

    private void OnEnable()
    {
        ResetAnswersToZero();
    }

    public void AddCorrectAnswer()
    {
        CorrectAnswers++;

        if (OnCorrectAdded != null)
        {
            OnCorrectAdded(CorrectAnswers);
        }
    }

    public void AddIncorrectAnswer()
    {
        IncorrectAnswers++;

        if (OnIncorrectAdded != null)
        {
            OnIncorrectAdded(IncorrectAnswers);
        }
    }

    public void ResetAnswersToZero()
    {
        CorrectAnswers = 0;
        IncorrectAnswers = 0;
    }
}