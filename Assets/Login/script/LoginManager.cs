
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField studentName;
    public InputField email;
    public InputField emailConfirm;
    public GameObject buttonSend; 

    [SerializeField]
    TMPro.TextMeshProUGUI titleText, contentText;

     [SerializeField]
    Image imageAsset;    
    

    [Header("*Complete todos los campos abajo según la práctica")]

    [SerializeField]
    UserData data;

    [SerializeField]
    string title;
 

    [SerializeField]
    Sprite image;

    [TextArea]

    [SerializeField]
    string  content;

    [SerializeField] Gender gender;
    [SerializeField] UserData userData;

    

    private void Start() {
        imageAsset.sprite = image;
        titleText.text = title;
        contentText.text = content;
        userData.lastScene = SceneManager.GetActiveScene().buildIndex.ToString();
    }



   
    public void Submit()
    {
        if (email.text.Contains("@") && email.text.Contains("."))
        {
            if (email.text == emailConfirm.text)
            {              
               CheckFile();
                data.name = studentName.text;
                data.email = email.text;
               
            }
            else
            {
                Debug.Log("no son iguales");                
                 VpNewNotice.SetNotice("Los correos no coinciden", "Por favor verifique la información");
            }
        } else
        {            
            Debug.Log("Formato Incorrecto");
            VpNewNotice.SetNotice("Formato Incorrecto", "Digite un Email válido");
        }
    }
     void CheckFile()
    {
        buttonSend.SetActive(false);
        StartCoroutine(VpNetServices.CheckFile( email.text, CheckFileResponse));
    }
    
    void StartUpload()
    {
        Debug.Log("Se Inicio la carga de la práctica");
       
        StartCoroutine(VpNetServices.Upload(data.email, data, UploadResponse));
       
    }
    void UserCreateSuccess(Button btnAccept)
    {
        btnAccept.onClick.RemoveAllListeners();
        btnAccept.onClick.AddListener(StartUpload);

    }
    void AlreadyExistsLoad()
    {
        VpNewNotice.SetNotice("La práctica ya existe","¿Desea continuar desde el último punto de guardado?", SetButtonsActions);
    }


    void SetButtonsActions( Button btnYes, Button btnNo)
    {
        btnYes.onClick.RemoveAllListeners();
        btnNo.onClick.RemoveAllListeners();
      
        btnYes.onClick.AddListener(LoadOldPractice);
        btnNo.onClick.AddListener(SetMessageNewPractice);
    }

    void SetMessageNewPractice()
    {       
        VpNewNotice.SetNotice("¡Cuidado!", "Su progreso anterior se perderá y empezará de cero ¿Desea continuar?", SetButtonsActionsConfirm);  
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
        Debug.Log("Se Inicio la carga de la práctica");
        StartCoroutine(VpNetServices.Download(data.email, data, DownloadResponse));
       
    }

    void ContinueScene()
    {
        data.name = studentName.text;
        data.email = email.text;
        if (data.lastScene == string.Empty)
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            LevelLoader.sceneToload = activeScene + 1;
        }
        else
        {
            LevelLoader.sceneToload = int.Parse(data.lastScene);
            gender.playerIsMan = userData.gender;
        }

        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
    }


    //Metodos de respuesta a los callbacks
    void CheckFileResponse(bool success, string handler, string error, long code)
    {        
        Debug.Log(code);

        buttonSend.SetActive(true);

        if(code >= 300)
        {
           VpNewNotice.SetNotice("Error","No pudimos conectarnos con el servidor, por favor revise su conección a Internet"); 
        }

        else 
        {
            if(code != 200)
            {
                VpNewNotice.SetNotice("Felicidades", "Usuario creado correctamente", UserCreateSuccess);
            }
            else
            {
                AlreadyExistsLoad();
            }
            
        }
    }

   
    void UploadResponse(bool success, string handler, string error, long code)
    {        
        Debug.Log(code);
        if(code>202)
        VpNewNotice.SetNotice("Error", "No pudimos guardar los datos, verifique su conexión a internet o pongase en contacto con el desarrollador");
        else        
        ContinueScene();
    }
    void DownloadResponse(bool success, string handler, string error, long code)
    {        
        Debug.Log(code);
        if(code!=200)
        VpNewNotice.SetNotice("Error", "No pudimos cargar los datos, verifique su conexión a internet o pongase en contacto con el desarrollador");
        else        
        ContinueScene();
    }


    //Open Url

     public void OpenExternalURL(string url)
    {        
        Application.OpenURL(url);

    }

    

}
