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
        StartCoroutine(AnimateClose());
        closeButton.enabled = false;
        SoundManager.Instance().PlayClic();
    }

    public void Open()
    {
        StartCoroutine(AnimateOpen());
        helpButton.enabled = false;
        SoundManager.Instance().PlayClic();
    }

    IEnumerator AnimateClose()
    {
        for (int i = 0; i > -850; i -= 50)
        {
            helpPanel.transform.localPosition = new Vector3(i, 62.5f, 0);
            //yield return new WaitForSecondsRealtime(0.1f);
            yield return null;
        }
        helpPanel.transform.localPosition = new Vector3(-850f, 62.5f, 0);
        helpButton.enabled = true;
    }

    IEnumerator AnimateOpen()
    {
        for (int i = -850; i < 0; i += 50)
        {
            helpPanel.transform.localPosition = new Vector3(i, 62.5f, 0);
            yield return null;
        }
        helpPanel.transform.localPosition = new Vector3(0, 62.5f, 0);
        closeButton.enabled = true;
    }


}
