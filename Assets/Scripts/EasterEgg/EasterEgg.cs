using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public static bool IsProjectSetToTest = false;

    AudioSource sound;
    public string secretCode;
    string currentCode;
    public GameObject test;    

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            currentCode += Input.inputString;
        }


        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            print(currentCode);
            if (currentCode == secretCode)
            {
                test.SetActive(!test.activeInHierarchy);
                sound.Play();
                currentCode = "";
            }
            else
            {
                currentCode = "";
            }
        }
    }

    
}
