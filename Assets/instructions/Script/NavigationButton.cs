using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NavigationButton : MonoBehaviour, IPointerClickHandler
{

    InstructionsManagerComponent code;
    int pos;
    string[] posChcar;
    Color colorFull;
    Color colorMid;

    public void OnPointerClick(PointerEventData eventData)
    {
        code.evalInstruction(pos);
        colorsReset();
        GetComponent<Image>().color = colorFull;
        InstructionsManagerComponent.actualInstruction = pos;
    }

    void Start()
    {

        code = FindObjectOfType<InstructionsManagerComponent>();
        posChcar = gameObject.name.Split(new string[] { "t" }, StringSplitOptions.None);
        pos = int.Parse(posChcar[1]);
        colorFull = GetComponent<Image>().color;
        colorMid = colorFull;
        colorMid.a = 0.3f;

    }

    void Update()
    {

        if (pos == InstructionsManagerComponent.actualInstruction)
        {
            colorsReset();
            GetComponent<Image>().color = colorFull;
        }
    }


    void colorsReset()
    {
        foreach (GameObject g in InstructionsManagerComponent.pointsPos)
        {
            g.GetComponent<Image>().color = colorMid;
        }
    }
}
