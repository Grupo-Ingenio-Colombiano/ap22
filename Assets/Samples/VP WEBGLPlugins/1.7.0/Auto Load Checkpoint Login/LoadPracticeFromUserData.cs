using UnityEngine;
using UnityEngine.SceneManagement;
using VP.WEBGL.Plugins;
public class LoadPracticeFromUserData : MonoBehaviour
{
    [SerializeField] private string testEmail, testName;
    [SerializeField] private UserData data;

    private string emailToUse,nameToUse;
    public void StartDownloadProcess()
    {
        data.ResetToItsDefaults();

#if UNITY_EDITOR
    nameToUse = testName;
    emailToUse = testEmail;        
#else
    nameToUse = AutoLoginUI.Name; 
    emailToUse = AutoLoginUI.Email; 
#endif
        StartCoroutine(VpNetServices.CheckFile(emailToUse, CheckFileResponse));
    }
    void CheckFileResponse(bool success, string handler, string error, long code)
    {
        if (code >= 300)
        {
            Debug.Log(code);
        }
        else
        {
            if (code != 200)
            {
                Debug.Log("Not exist");
                StartUpload();
            }
            else
            {
                Debug.Log("Exist");
                AlreadyExistsLoad();
            }
        }
    }
    void StartUpload()
    {
        StartCoroutine(VpNetServices.Upload(emailToUse, data, UploadResponse));
    }
    void AlreadyExistsLoad()
    {
        LoadOldPractice();
    }
    void LoadOldPractice()
    {
        StartCoroutine(VpNetServices.Download(emailToUse, data, DownloadResponse));

    }
    public void ContinueScene()
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
        data.studentName = nameToUse;
        data.email = emailToUse;
        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
    }
    void UploadResponse(bool success, string handler, string error, long code)
    {
        if (code > 202)
        {
            Debug.Log(code);
        }
        else
        {
            ContinueScene();
        }
    }
    void DownloadResponse(bool success, string handler, string error, long code)
    {
        if (code != 200)
        {
            Debug.Log(code);
        }
        else
        {
            ContinueScene();
        }
    }
}
