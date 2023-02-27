using TMPro;
using UnityEngine;

public class CriteriaManager : MonoBehaviour
{

    [SerializeField] PlayerExperience playerExperience;
    [SerializeField] PlayerProgress playerProgress;

    //[Header("Settings")]
    //[SerializeField] string[] correctResult;
    //[SerializeField] string[] incorrectResult;

    //[SerializeField] string correctFinalResult;
    //[SerializeField] string incorrectFinalResult;

    //[SerializeField] Color correctColor;
    //[SerializeField] Color incorrectColor;

    //[Header("UI Elements")]
    //[SerializeField] TextMeshProUGUI[] resultLabel;
    //[SerializeField] TextMeshProUGUI finalResultLabel;


    GameObject currentCalc;

    int totalCurrentCriteria;

    bool hasBeenResolved = false;

    int currentAtempts = 3;
    int questionaryPoints = 0;

    private void Start()
    {
        //totalCurrentCriteria = resultLabel.Length;
    }

    public void SetResults(bool[] results, GameObject calculator)
    {
        //currentCalc = calculator;

        //var correct = 0;

        //correct = CheckAnswers(results, correct);
        //SetFinalresult(correct);
        //gameObject.SetActive(true);
    }



    private int CheckAnswers(bool[] results, int correct)
    {

        //for (int i = 0; i < resultLabel.Length; i++)
        //{

        //    //correct++;
        //    if (results[i])
        //    {
        //        correct++;
        //        resultLabel[i].text = correctResult[i];
        //        resultLabel[i].color = correctColor;
        //    }
        //    else
        //    {
        //        resultLabel[i].text = incorrectResult[i];
        //        resultLabel[i].color = incorrectColor;
        //    }

        //}

        return correct;
    }

    private void SetQuestionaryPoints()
    {
        questionaryPoints = currentAtempts * 10;
    }

    public void ContinueActivity()
    {
        //if (!DebugHelper.IsProjectSetToTest)
        //{
        //    if (hasBeenResolved)
        //    {
        //        pcProgressManager.gameObject.SetActive(true);

        //        AddScore();
        //    }
        //    else
        //    {
        //        if (currentAtempts - 1 >= 0)
        //        {
        //            currentAtempts--;
        //        }

        //        currentCalc.gameObject.SetActive(true);
        //        gameObject.SetActive(false);
        //    }
        //}
        //else
        //{

        //    pcProgressManager.gameObject.SetActive(true);
        //    AddScore();
        //}

    }

    public void ContinueSecondActivity(GameObject toActivate)
    {
        //if (DebugHelper.IsProjectSetToTest || hasBeenResolved)
        //{
        //    toActivate.SetActive(true);
        //}
        //else
        //{
        //    if (currentAtempts - 1 >= 0)
        //    {
        //        currentAtempts--;
        //    }

        //    currentCalc.gameObject.SetActive(true);
        //    gameObject.SetActive(false);
        //}

    }

    public void SetNextLevelAvailable()
    {

        //Alert.Instance.Generate("Simulación Completada", "Ha diseñado el elemento correctamente", 1);
        //Alert.Instance.gameObject.SetActive(true);

        //currentLevel.isLevelResolved = true;
        //currentLevel.SetIndicator();

        //nextLevel.isLevelPlayable = true;
        //nextLevel.SetIndicator();

        ////print(gameObject.name + " " + currentLevel.numLevel + " " + nextLevel.numLevel);
        //currentLevel.gameObject.layer = 2;
        //LevelUIIndicatorsManager.Instance.SetIndicator(currentLevel.numLevel, true);
        //LevelUIIndicatorsManager.Instance.SetIndicator(nextLevel.numLevel, false);
        //playerProgress.AddProgressPercentage(3);

        //if (isLastZoneLevel)
        //{
        //    MapController.Instance.EnableNewZone();
        //}
    }

    private void AddScore()
    {
        //QuestionPointManager.FormPoints[QuestionPointManager.FormIndex] = questionaryPoints;
        //QuestionPointManager.FormIndex++;

        playerExperience.AddExperience(questionaryPoints);
    }


}
