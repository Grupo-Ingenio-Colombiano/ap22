using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIndicatorsManager : MonoBehaviour
{
    public static MapIndicatorsManager instance;

    public List<GameObject> indicators = new List<GameObject>();
    private void Awake()
    {
        instance = this;    
    }
    private void Start() 
    {
        TurnOffAllMarkers();    
    }

    public void SetMarkerOn(int index)
    {
        TurnOffAllMarkers();
        indicators[index].SetActive(true);
    }

    public void TurnOffAllMarkers()
    {
        foreach(var indicator in indicators)
        {
            indicator.SetActive(false);
        }

    }
}
