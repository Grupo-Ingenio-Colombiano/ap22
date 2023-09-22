using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Indicator : MonoBehaviour
{
    public static Map_Indicator instance;
    [SerializeField] private GameObject indicatorPrefab;
    [SerializeField] private Vector3 indicatorScale = new Vector3(3,3,1);

    [SerializeField] private Transform[] positions;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }    
    }
    private void Start() 
    {
        indicatorPrefab =Instantiate(indicatorPrefab);
        indicatorPrefab.transform.localScale = indicatorScale;
        TurnOffIndicator();    
    }

    public void TurnOffIndicator()
    {
        indicatorPrefab.SetActive(false);
    }

    public void SetMarker(int index)
    {
        if(index < positions.Length)
        {            
            indicatorPrefab.SetActive(true);
            indicatorPrefab.transform.position = positions[index].position;
        }
        else
        {
            Debug.Log("You must assign a valid index of the indicator");
        }

    }
}
