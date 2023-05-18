using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{

    static HelpManager manager;

    public static HelpManager Instance()
    {
        manager = FindObjectOfType(typeof(HelpManager)) as HelpManager;
        return manager;
    }

    [SerializeField] GameObject helpPanel;

    [SerializeField] Text helpText;

    [SerializeField] Button helpButton;

    [SerializeField] Button closeButton;

    [SerializeField] GameObject helpCounter;

    [SerializeField] bool hasHelpCounter;

    [SerializeField] PlayerClues pClues;

    int time = 5;

    public void SetHelp(string clue)
    {
        SetHelpText(clue);
        Open();
        SoundManager.Instance().PlayGood();
    }

    public void SetHelpText(string clue)
    {
        helpText.text = clue;
    }

    public void Close()
    {
        helpPanel.transform.localScale = new Vector3(0, 0, 0);
        helpButton.enabled = true;
        SoundManager.Instance().PlayClic();
        time = 5;
        StopCoroutine(AnimateOpen());   
        
    }

    public void Open()
    {
        helpPanel.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(AnimateOpen());
        helpButton.enabled = false;
        SoundManager.Instance().PlayClic();
    }


    IEnumerator AnimateOpen()
    {


        yield return new WaitForSeconds(time); ;

        //helpPanel.transform.localPosition = new Vector3(0, 62.5f, 0);
       Close();
    }


}
