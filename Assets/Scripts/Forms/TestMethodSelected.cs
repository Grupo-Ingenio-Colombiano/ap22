using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMethodSelected : MonoBehaviour
{
    [SerializeField] int methodSelected;

    [SerializeField] GameObject[] methodManagers;

    private void Start()
    {
        methodManagers[methodSelected].gameObject.SetActive(true);
    }
}
