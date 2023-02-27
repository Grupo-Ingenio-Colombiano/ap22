using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDate : MonoBehaviour
{

    [SerializeField] Text startDate;
    [SerializeField] Text endDate;

    [SerializeField] int daysDistance;
    [SerializeField] int daysAgo = 0;


    private void Start()
    {
        startDate.text = System.DateTime.Now.AddDays(-daysAgo).ToString("dd-MM-yyyy");
        endDate.text = System.DateTime.Now.AddDays(daysDistance).ToString("dd-MM-yyyy");
    }

}
