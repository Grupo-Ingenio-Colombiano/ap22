using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public RectTransform imgTrasnform;
     

    public void OnPointerEnter(PointerEventData eventData)
    {

        StartCoroutine(animateScale(6f, 0, 1));
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        StartCoroutine(animateScale(6f, 1, 0));
    }

    

    IEnumerator animateScale(float time, float valueIn, float valueOut)
    {
        float t = 0;
        
        while (t < 1)
        {
            t += time * Time.deltaTime;

            imgTrasnform.localScale = new Vector3(Mathf.Lerp(valueIn,valueOut,t), 1, 1);

            yield return null;
        }
    }
	
    
}
