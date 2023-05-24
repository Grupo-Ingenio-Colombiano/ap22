
using UnityEngine;

public class SaveUserData : MonoBehaviour
{

    [SerializeField]
    
    UserData data;
    private void OnEnable() {

        StartCoroutine(VpNetServices.Upload(data.name,  data, CallbackUpload )); 
    }

    void CallbackUpload(bool success, string handler, string error, long code)
    {
        Debug.Log(success);
        Debug.Log(handler);
        Debug.Log(error);
        Debug.Log(code);
        
    }

}
