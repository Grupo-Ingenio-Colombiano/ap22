using UnityEngine;
using UnityEngine.UI;

public class TimeFilesManager : MonoBehaviour
{
    [SerializeField] GameObject[] pages;
    [SerializeField] Text[] pagesTitles;
    [SerializeField] Text[] pagesTextIndex;
    [SerializeField] GameObject buttonNext;
    [SerializeField] GameObject buttonBack;
    GameObject[] currentPages;
    Text[] currentTitles;
    Text[] currentPagesIndexes;

    int currentPageIndex;

    void Start()
    {
        currentPageIndex = 0;

        currentPages = new GameObject[pages.Length];
        currentTitles = new Text[pages.Length];
        currentPagesIndexes = new Text[pages.Length];

        int order = Random.Range(0, 6);

        switch (order)
        {
            case 0:
                currentPages = pages;
                currentTitles = pagesTitles;
                currentPagesIndexes = pagesTextIndex;
                break;
            case 1:
                currentPages[0] = pages[0];
                currentPages[1] = pages[2];
                currentPages[2] = pages[1];

                currentTitles[0] = pagesTitles[0];
                currentTitles[1] = pagesTitles[2];
                currentTitles[2] = pagesTitles[1];

                currentPagesIndexes[0] = pagesTextIndex[0];
                currentPagesIndexes[1] = pagesTextIndex[2];
                currentPagesIndexes[2] = pagesTextIndex[1];

                break;
            case 2:
                currentPages[0] = pages[1];
                currentPages[1] = pages[0];
                currentPages[2] = pages[2];

                currentTitles[0] = pagesTitles[1];
                currentTitles[1] = pagesTitles[0];
                currentTitles[2] = pagesTitles[2];

                currentPagesIndexes[0] = pagesTextIndex[1];
                currentPagesIndexes[1] = pagesTextIndex[0];
                currentPagesIndexes[2] = pagesTextIndex[2];

                break;
            case 3:
                currentPages[0] = pages[2];
                currentPages[1] = pages[0];
                currentPages[2] = pages[1];

                currentTitles[0] = pagesTitles[2];
                currentTitles[1] = pagesTitles[0];
                currentTitles[2] = pagesTitles[1];

                currentPagesIndexes[0] = pagesTextIndex[2];
                currentPagesIndexes[1] = pagesTextIndex[0];
                currentPagesIndexes[2] = pagesTextIndex[1];

                break;
            case 4:
                currentPages[0] = pages[1];
                currentPages[1] = pages[2];
                currentPages[2] = pages[0];

                currentTitles[0] = pagesTitles[1];
                currentTitles[1] = pagesTitles[2];
                currentTitles[2] = pagesTitles[0];

                currentPagesIndexes[0] = pagesTextIndex[1];
                currentPagesIndexes[1] = pagesTextIndex[2];
                currentPagesIndexes[2] = pagesTextIndex[0];

                break;
            case 5:
                currentPages[0] = pages[2];
                currentPages[1] = pages[1];
                currentPages[2] = pages[0];

                currentTitles[0] = pagesTitles[2];
                currentTitles[1] = pagesTitles[1];
                currentTitles[2] = pagesTitles[0];

                currentPagesIndexes[0] = pagesTextIndex[2];
                currentPagesIndexes[1] = pagesTextIndex[1];
                currentPagesIndexes[2] = pagesTextIndex[0];

                break;
            default:
                break;
        }

        currentTitles[0].text = currentTitles[0].text + "1 (Minutos)";
        currentTitles[1].text = currentTitles[1].text + "2 (Minutos)";
        currentTitles[2].text = currentTitles[2].text + "3 (Minutos)";

        currentPagesIndexes[0].text = "Hoja 1";
        currentPagesIndexes[1].text = "Hoja 2";
        currentPagesIndexes[2].text = "Hoja 3";

        currentPages[0].SetActive(true);
    }

    public void GoNext()
    {
        if (currentPageIndex == 0)
        {
            currentPageIndex++;
            currentPages[0].SetActive(false);
            currentPages[1].SetActive(true);
            currentPages[2].SetActive(false);
            buttonBack.SetActive(true);
            buttonNext.SetActive(true);
            return;
        }

        if (currentPageIndex == 1)
        {
            currentPageIndex++;
            currentPages[0].SetActive(false);
            currentPages[1].SetActive(false);
            currentPages[2].SetActive(true);
            buttonNext.SetActive(false);
            buttonBack.SetActive(true);
            return;
        }

    }

    public void GoBack()
    {
        if (currentPageIndex == 1)
        {
            currentPageIndex--;
            currentPages[0].SetActive(true);
            currentPages[1].SetActive(false);
            currentPages[2].SetActive(false);
            buttonBack.SetActive(false);
            buttonNext.SetActive(true);
            return;
        }

        if (currentPageIndex == 2)
        {
            currentPageIndex--;
            currentPages[0].SetActive(false);
            currentPages[1].SetActive(true);
            currentPages[2].SetActive(false);
            buttonBack.SetActive(true);
            buttonNext.SetActive(true);
            return;
        }
    }
}
