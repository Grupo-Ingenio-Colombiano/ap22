using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadNetTest : MonoBehaviour
{

    public TMPro.TMP_InputField name, practice;

    public GameObject buttonSend, buttonDownload;

    public UserData data;

    private void Start() {
        
        print(data.lastName);

       string aleatorio;

        if(data.lastName.Length==0)
        {
            print("genere aleatorio");
        }
        else
        {
            aleatorio = data.lastName;
        }

        
    }

    public void StartUpload()
    {
        buttonSend.SetActive(false);
        StartCoroutine( VpNetServices.Upload(name.text,  data, CallbackUpload ));
    }

    public void StartDownload()
    {
        buttonSend.SetActive(false);
        StartCoroutine( VpNetServices.Download(name.text, data, CallbackUpload ));
    }




    void CallbackUpload(bool success, string handler, string error, long code)
    {
        Debug.Log(success);
        Debug.Log(handler);
        Debug.Log(error);
        Debug.Log(code);

        buttonSend.SetActive(true);
    }

    void CallbackDownload(bool success, string handler, string error, long code)
    {
        Debug.Log(success);
        Debug.Log(handler);
        Debug.Log(error);
        Debug.Log(code);

        buttonSend.SetActive(true);
    }

   

    }
