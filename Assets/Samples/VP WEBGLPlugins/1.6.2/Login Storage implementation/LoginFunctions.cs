using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_WEBGL
using VP.WEBGL.Plugins;
#endif

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
    [SerializeField] string urlEmptyEmail;
    [SerializeField] UserData data;

    ///Paso 1
    public void StartVerifyEmail()
    {
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

    ///Paso 2
    /// <summary>
    /// Metodos de respuesta a los callbacks
    /// </summary>
    /// <param name="success"></param>
    /// <param name="handler"></param>
    /// <param name="error"></param>
    /// <param name="code"></param>
    void CheckFileResponse(bool success, string handler, string error, long code)
    {
        Debug.Log(code);

        if (code >= 300)
        {
            VpNewNotice.SetNotice("Error", "No pudimos conectarnos con el servidor, por favor revise su conecci�n a Internet");
        }

        else
        {
            if (code != 200)
            {
                VpNewNotice.SetNotice("Felicidades", "Usuario creado correctamente", UserCreateSuccess);
            }
            else
            {
                AlreadyExistsLoad();
            }

        }
    }
    void UserCreateSuccess(Button btnAccept)
    {
        btnAccept.onClick.RemoveAllListeners();
        btnAccept.onClick.AddListener(StartUpload);
    }

    void StartUpload()
    {
        debugMsg += "\n" + "Se Inicio la carga de la pr�ctica" + "\n";

        StartCoroutine(VpNetServices.Upload(data.email, data, UploadResponse));

    }
    
    void AlreadyExistsLoad()
    {
        VpNewNotice.SetNotice("La práctica ya existe", "�Desea continuar desde el �ltimo punto de guardado?", SetButtonsActions);
    }


    void SetButtonsActions(Button btnYes, Button btnNo)
    {
        btnYes.onClick.RemoveAllListeners();
        btnNo.onClick.RemoveAllListeners();

        btnYes.onClick.AddListener(LoadOldPractice);
        btnNo.onClick.AddListener(SetMessageNewPractice);
    }

    void SetMessageNewPractice()
    {
        VpNewNotice.SetNotice("�Cuidado!", "Su progreso anterior se perder� y empezar� de cero �Desea continuar?", SetButtonsActionsConfirm);
    }


    void SetButtonsActionsConfirm(Button btnYes, Button btnNo)
    {
        btnYes.onClick.RemoveAllListeners();
        btnNo.onClick.RemoveAllListeners();

        btnYes.onClick.AddListener(StartUpload);
        btnNo.onClick.AddListener(AlreadyExistsLoad);
    }

    void LoadOldPractice()
    {
        Debug.Log("Se Inicio la carga de la pr�ctica");
        StartCoroutine(VpNetServices.Download(data.email, data, DownloadResponse));

    }

    void UploadResponse(bool success, string handler, string error, long code)
    {
        Debug.Log(code);
        if (code > 202)
            VpNewNotice.SetNotice("Error", "No pudimos guardar los datos, verifique su conexi�n a internet o pongase en contacto con el desarrollador");
        //else
            //ContinueScene();
    }
    void DownloadResponse(bool success, string handler, string error, long code)
    {
        Debug.Log(code);
        if (code != 200)
            VpNewNotice.SetNotice("Error", "No pudimos cargar los datos, verifique su conexi�n a internet o pongase en contacto con el desarrollador");
        //else
            //ContinueScene();
    }

    //void ContinueScene()
    //{
    //    if (data.lastScene.Length == 0)
    //    {
    //        int activeScene = SceneManager.GetActiveScene().buildIndex;
    //        LevelLoader.sceneToload = activeScene + 1;
    //    }
    //    else
    //    {
    //        LevelLoader.sceneToload = int.Parse(data.lastScene);
    //    }

    //    SceneManager.LoadScene("Loading", LoadSceneMode.Additive);

    //    PrintDebug();
    //}
    
    string debugMsg;
    void PrintDebug()
    {
        debugMsg += "\n" + "\n" + "Recuerde que la autenticacion est� en" + SceneManager.GetActiveScene().name + "/Code/" + gameObject.name;

        Debug.Log(debugMsg, gameObject);
    }
}
