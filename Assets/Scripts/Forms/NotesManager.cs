using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    public static NotesManager Instance;

    [SerializeField] GameObject[] pagesToEnable;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void EnablePage(int index)
    {
        for (int i = 0; i < pagesToEnable.Length; i++)
        {
            if (i == index)
            {
                pagesToEnable[i].SetActive(true);
            }
            else
            {
                pagesToEnable[i].SetActive(false);
            }
        }
    }

}
