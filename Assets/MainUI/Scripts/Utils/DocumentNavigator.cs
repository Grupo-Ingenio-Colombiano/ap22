using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentNavigator : MonoBehaviour
{


    private int currentPage;

    [SerializeField]
    private int currentNumberPages;

    [SerializeField]
    private GameObject[] pages;

    [SerializeField]
    private Button buttonBack;

    [SerializeField]
    private Button buttonForward;


    private void OnEnable()
    {
        buttonBack.interactable = false;
        buttonForward.interactable = true;
        currentPage = 0;
        HidePages();
        pages[0].SetActive(true);
    }

    private void HidePages()
    {
        foreach (var item in pages)
        {
            item.SetActive(false);
        }
    }

    public void GoToNextPage()
    {

        if (currentPage < currentNumberPages - 1)
        {
            HidePages();
            pages[currentPage + 1].SetActive(true);
            currentPage++;
        }

        ChekPages();

    }

    public void GoToPreviousPage()
    {
        if (currentPage > 0)
        {
            HidePages();
            pages[currentPage - 1].SetActive(true);
            currentPage--;
        }

        ChekPages();

    }

    private void ChekPages()
    {
        if (currentPage == currentNumberPages - 1)
        {

            buttonForward.interactable = false;
        }
        else
        {
            buttonForward.interactable = true;
        }

        if (currentPage == 0)
        {
            buttonBack.interactable = false;
        }
        else
        {
            buttonBack.interactable = true;
        }
    }




}
