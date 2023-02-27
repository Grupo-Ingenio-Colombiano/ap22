using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{

    static IndicatorManager indicatorManager;

    static public IndicatorManager instance()
    {
        indicatorManager = FindObjectOfType(typeof(IndicatorManager)) as IndicatorManager;
        return indicatorManager;
    }

    public void SetDestiny(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

}
