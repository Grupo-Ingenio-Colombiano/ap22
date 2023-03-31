using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color32 normalColor;
    public Color32 hoverColor;
    public GameObject boxText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(boxText != null)
        {
            boxText.SetActive(false);
        }

        Image icon = null;
        icon = transform.GetChild(0).GetComponent<Image>();
        if(icon != null)
        {
            icon.color = hoverColor;
        }

        if (boxText != null)
        {
            boxText.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image icon = null;
        icon = transform.GetChild(0).GetComponent<Image>();
        if (icon != null)
            icon.color = normalColor;

        if (boxText != null)
        {
            boxText.GetComponent<Animator>().Play("Hover_Out");
        }
    }
}
