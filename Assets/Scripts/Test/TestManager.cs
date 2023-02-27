using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    TestMenuControl menuControl;

    [SerializeField]
    PrizeManager prize;
    

    public void GeneratePrize()
    {

        menuControl.Close();
    }

}