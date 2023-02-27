using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardButton : MonoBehaviour
{

    Vector3 initPos;
    Color initColor;

    [SerializeField] public int correctPosIndex;

    [SerializeField] public int[] correctPositionsIndexes;
    //[SerializeField] Vector3 answerPos;

    bool isButtonActive = false;

    public int indexAnswer = -1;

    void Start()
    {
        initPos = GetComponent<RectTransform>().localPosition;
        initColor = GetComponent<Image>().color;
        GetComponentInChildren<Text>().raycastTarget = false;
        //print("INIT POS: " + initPos + gameObject.name);
    }

    void Update()
    {
        if (isButtonActive)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void ActivateBoardButton()
    {
        //print(transform.localPosition + " " + (transform.localPosition == initPos) + " ACTIVANDO!!!");

        if (GetComponent<RectTransform>().localPosition == initPos)
        {
            //print("seleccionar" + gameObject.name);
            SetSelected();
        }
        else
        {
            //print("resetear" + gameObject.name);
            ResetBoardButton();
        }
    }

    public void SetSelected()
    {
        //print(gameObject.name);
        BoardManagerTest.instance.SetCurrent(this);
        isButtonActive = true;
        GetComponent<Image>().raycastTarget = false;
    }

    public void ResetBoardButton()
    {
        //print("reseted" + gameObject.name);
        GetComponent<Image>().raycastTarget = true;
        GetComponent<Image>().color = initColor;
        isButtonActive = false;
        transform.GetComponent<RectTransform>().localPosition = initPos;
        BoardManagerTest.instance.currentAnswered--;

        if (indexAnswer != -1)
        {
            BoardManagerTest.instance.ResetAnswerButton(indexAnswer);
            indexAnswer = -1;
        }

        BoardManagerTest.instance.CheckEndButton();

    }

    public void SetButtonAnswered()
    {
        isButtonActive = false;
    }

    public void SetIndexAnswer(int index)
    {
        indexAnswer = index;
    }


}
