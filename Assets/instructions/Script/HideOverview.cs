using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOverview : MonoBehaviour
{
    [SerializeField]
    GameObject firstCanvas;

    [SerializeField]
    GameObject mainUI;

    [SerializeField]
    GameObject code;



    public void StartInstructions()
    {
        GetComponentInChildren<Animator>().SetBool("animate", true);
        Invoke("init", 1f);
    }

    void init()
    {
        //firstCanvas.SetActive(false);
        mainUI.SetActive(true);
        code.GetComponent<InstructionsManagerComponent>().startNavigation();
    }

}
