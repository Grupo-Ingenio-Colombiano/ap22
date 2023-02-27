using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Session : MonoBehaviour
{
    public GameObject logInAlert;

    public GameObject loading;

    public void Start()
    {
        StartCoroutine(VerifySession());
    }

    IEnumerator VerifySession()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://virtualplant.co/session-control.php");
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "0")
            {
                loading.SetActive(false);
                logInAlert.SetActive(true);
            }
            else
            {
                //SESSION INICIADA - PUEDE CONTINUAR
                SceneManager.LoadScene("Introduccion");
            }
        }
    }

    public void GoToLogIn()
    {
        //Todo: ir a log in
        Application.ExternalCall("GotoToLogIn", "");
    }
}
