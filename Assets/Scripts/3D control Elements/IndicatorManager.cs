using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class IndicatorManager : MonoBehaviour
{

    static IndicatorManager indicatorManager;
    [SerializeField] UserData userData;
    [SerializeField] LoadManager loadManager;

    static public IndicatorManager instance()
    {
        indicatorManager = FindObjectOfType(typeof(IndicatorManager)) as IndicatorManager;

        return indicatorManager;
    }

    public void SetDestiny(Vector3 pos)
    {
        gameObject.transform.position = pos;
        loadManager.Upload(userData.load++);

    }

}
