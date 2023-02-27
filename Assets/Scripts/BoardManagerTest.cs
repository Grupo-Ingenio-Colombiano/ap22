using UnityEngine;
using UnityEngine.UI;

public class BoardManagerTest : MonoBehaviour
{

    public static BoardManagerTest instance = null;

    BoardButton currentButton;

    Vector3[] posiblePositions;

    [Header("puzzle elements")]
    [SerializeField] int numPosiblePositions;

    [SerializeField] Color correctIndicatorColor;
    [SerializeField] Color incorrectIndicatorColor;

    [SerializeField] GameObject[] answerButtonsIndicators;
    [SerializeField] GameObject[] initialButtons;

    [Header("flow control")]
    [SerializeField] GameObject endButton;

    [SerializeField] GameObject buttonContinue;
    [SerializeField] GameObject wrongActivityText;

    [Header("player data")]
    [SerializeField] PlayerExperience playerExperience;
    [SerializeField] PlayerProgress playerProgress;

    public int currentAnswered;

    public int correctAnswers = 0;

    int currentAtempts = 3;
    int questionaryPoints = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        InitializeBoard();

        if (Debug.isDebugBuild)
        {
            endButton.SetActive(true);
        }
    }

    private void InitializeBoard()
    {
        SetPosiblePositions();
        currentAnswered = 0;
    }


    private void SetPosiblePositions()
    {
        posiblePositions = new Vector3[numPosiblePositions];

        for (int i = 0; i < answerButtonsIndicators.Length; i++)
        {
            posiblePositions[i] = answerButtonsIndicators[i].GetComponent<RectTransform>().localPosition;
        }
    }


    public void SetAnswer(int index)
    {
        //print(currentButton.gameObject.name);

        if (currentButton != null)
        {
            currentAnswered++;

            //print(currentButton.GetComponent<RectTransform>().localPosition + " " + posiblePositions[index]);
            currentButton.GetComponent<BoardButton>().SetButtonAnswered();
            currentButton.transform.localPosition = posiblePositions[index];
            //print(currentButton.GetComponent<RectTransform>().localPosition + " " + posiblePositions[index] + " index: " + index);
            answerButtonsIndicators[index].GetComponent<Image>().raycastTarget = false;
            currentButton.gameObject.GetComponent<Image>().raycastTarget = true;
            currentButton.GetComponent<BoardButton>().SetIndexAnswer(index);
            currentButton = null;

            CheckEndButton();
        }
    }

    public void CheckEndButton()
    {
        int aux = 0;
        for (int i = 0; i < initialButtons.Length; i++)
        {
            if (initialButtons[i].GetComponent<BoardButton>().indexAnswer != -1)
            {
                aux++;
            }
        }
        if (aux == numPosiblePositions)
        {
            endButton.SetActive(true);
        }
        else
        {
            endButton.SetActive(false);
        }

    }

    public void SetCurrent(BoardButton btn)
    {
        //print("setting current button");
        if (currentButton != null)
        {
            currentButton.ResetBoardButton();
        }

        currentButton = btn;
    }

    public void RestartButtons()
    {
        for (int i = 0; i < initialButtons.Length; i++)
        {
            RestartButton(i);
        }

    }

    public void RestartButton(int index)
    {
        initialButtons[index].GetComponent<BoardButton>().ResetBoardButton();

        int temp = initialButtons[index].GetComponent<BoardButton>().indexAnswer;
        if (temp != -1)
        {
            answerButtonsIndicators[temp].GetComponent<Image>().raycastTarget = false;
        }
    }

    public void ResetAnswerButton(int index)
    {
        answerButtonsIndicators[index].GetComponent<Image>().raycastTarget = true;
        wrongActivityText.SetActive(false);
    }

    public void CheckAnswers()
    {
        correctAnswers = 0;
        for (int i = 0; i < numPosiblePositions; i++)
        {
            var posibleCorrectPos = initialButtons[i].GetComponent<BoardButton>().correctPositionsIndexes;
            //print(posibleCorrectPos != null);

            bool isCorrect = false;
            for (int j = 0; j < posibleCorrectPos.Length; j++)
            {

                if (posibleCorrectPos[j] == initialButtons[i].GetComponent<BoardButton>().indexAnswer)
                {
                    isCorrect = true;
                }
            }

            if (isCorrect)
            {
                correctAnswers++;
                initialButtons[i].GetComponent<Image>().color = correctIndicatorColor;
            }
            else
            {
                initialButtons[i].GetComponent<Image>().color = incorrectIndicatorColor;
            }

        }

        //print(correctAnswers);
        ProcessEndResult(correctAnswers);
    }

    void ProcessEndResult(int numAnswers)
    {
        if (numAnswers == numPosiblePositions)
        {
            EndDragActivity();
        }
        else
        {
            if (currentAtempts - 1 >= 0)
            {
                currentAtempts--;
            }

            wrongActivityText.SetActive(true);

            if (Debug.isDebugBuild)
            {
                EndDragActivity();
            }
        }
    }

    private void EndDragActivity()
    {
        buttonContinue.SetActive(true);
        endButton.SetActive(false);
        AddScore();
    }

    public void SetCorrectAnswers()
    {
        EndDragActivity();
    }


    private void AddScore()
    {
        //TODO
        //QuestionPointManager.boardPoints[QuestionPointManager.BoardIndex] = questionaryPoints;
        //QuestionPointManager.BoardIndex++;

        //playerExperience.AddExperience(questionaryPoints);
    }

}