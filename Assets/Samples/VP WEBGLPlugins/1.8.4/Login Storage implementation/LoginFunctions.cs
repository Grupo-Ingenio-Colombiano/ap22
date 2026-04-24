using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_WEBGL
using VP.WEBGL.Plugins;
#endif

/// <summary>
/// Esta clase hace uso de VP NetworkServices y VP Data para funcionar
/// </summary>
public class LoginFunctions : MonoBehaviour
{
    #region Testing

#if UNITY_EDITOR

    [Header("TestTools")]
    [SerializeField] string nameTest = "TestName";
    [SerializeField] string emailTest = "TestEmail@lugnia.com";
    
    private void Start()
    {
        debugMsg = "Se ha iniciado un testeo en Editor" + "\n";
    }
#endif

    #endregion

    [Header("options")]
    [SerializeField] private TextMeshProUGUI errorLabel;
    [SerializeField] UserData data;

    public void StartVerifyEmail()
    {
        data.ResetToItsDefaults();
#if UNITY_EDITOR

        data.name = nameTest;
        data.email = emailTest;

        debugMsg += "Name: " + data.name + "\n";
        debugMsg += "Email: " + data.email + "\n";

#elif UNITY_WEBGL
        
        data.name = AutoLoginUI.Name;
        data.email = AutoLoginUI.Email;
        
#endif
        
        StartCoroutine(VpNetServices.CheckFile(data.email, CheckFileResponse));
    }
    void CheckFileResponse(bool success, string handler, string error, long code)
    {
        if (code >= 300)
        {
            errorLabel.text = "No se ha podido establecer conexión con el servidor.";
            Debug.Log(code);
        }
        else
        {
            if (code != 200)
            {
                Debug.Log("Not exist");
                //StartUpload
                StartCoroutine(VpNetServices.Upload(data.email, data, UploadResponse));
            }
            else
            {
                Debug.Log("Exist");
                //LoadOldPractice
                StartCoroutine(VpNetServices.Download(data.email, data, DownloadResponse));
            }
        }
    }
    
    void UploadResponse(bool success, string handler, string error, long code)
    {
        Debug.Log(code);
        if(code >= 300)
        {
            errorLabel.text = "Ha ocurrido un error de conexión al intentar subir la nueva partida al servidor.";
        }
        else if (code <= 202)
            ContinueScene();
    }
    void DownloadResponse(bool success, string handler, string error, long code)
    {
        Debug.Log(code);
        if(code >= 300)
        {
            errorLabel.text = "Ha ocurrido un error de conexión al intentar descargar su partida guardada del servidor.";
        }
        else if (code == 200)
            ContinueScene();
        
    }
    void ContinueScene()
    {
        if (data.lastScene.Length == 0 || data.lastScene == "0")
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            LevelLoader.sceneToload = activeScene + 1;
            Debug.Log("THE SCENE IS ZERO");
        }
        else
        {
            Debug.Log($"Scene is not zero, it is {data.lastScene}");
            LevelLoader.sceneToload = int.Parse(data.lastScene);
        }
        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
    }

    string debugMsg;
    void PrintDebug()
    {
        debugMsg += "\n" + "\n" + "Recuerde que la autenticacion est� en" + SceneManager.GetActiveScene().name + "/Code/" + gameObject.name;

        Debug.Log(debugMsg, gameObject);
    }
}
