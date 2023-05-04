using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesManager : MonoBehaviour
{
    public static NotesManager Instance;

    [SerializeField] GameObject[] pagesToEnable;
    [SerializeField] InputField notes;
    [SerializeField] UserData userData;

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

    private void Start()
    {
        if(userData.load >= 1)
        {
            notes.text = userData.note;
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
    public void LoadNote()
    {
        userData.note = notes.text;
    }

}
