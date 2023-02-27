using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{

    [SerializeField] private Text incorrect;

    [SerializeField] private Text correct;

    [SerializeField] PlayerAnswers answers;


    private void Start()
    {
        if (answers != null)
        {
            answers.OnCorrectAdded += HandleCorrectChanged;
            answers.OnIncorrectAdded += HandleIncorrectChanged;
        }
    }

    private void HandleCorrectChanged(int numberCorrect)
    {
        correct.text = numberCorrect.ToString();
    }

    private void HandleIncorrectChanged(int numberIncorrect)
    {
        incorrect.text = numberIncorrect.ToString();
    }

    private void OnDisable()
    {
        if (answers != null)
        {
            answers.OnCorrectAdded -= HandleCorrectChanged;
            answers.OnIncorrectAdded -= HandleIncorrectChanged;
        }

    }
}