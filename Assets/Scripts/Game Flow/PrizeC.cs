using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeC : MonoBehaviour
{
    [SerializeField]
    GameManager manager;

 
    private void OnDisable()
    {
        manager.enableSSGTdialog1();
    }
}
