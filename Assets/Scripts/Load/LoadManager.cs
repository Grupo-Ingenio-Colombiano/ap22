using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class LoadManager : MonoBehaviour
{
    [SerializeField] UserData data;
    public int load;


    [SerializeField] UIDialogManager dialogManager;
    
    // Start is called before the first frame update
    public void Upload(int point)
    {

        data.load = point;
        Debug.Log("Se subieron datos de la pr�ctica");
        Debug.Log(data.lastScene);
        data.isSave = true;
        StartCoroutine(VpNetServices.Upload(data.email, data, UploadResponse));

    }
    void UploadResponse(bool success, string handler, string error, long code)
    {
        Debug.Log("Datos Subidos");
    }


  public void TimeInvoke()
    {
        Invoke("Load", 3f);
    }

     void Load()
    {
        Upload(1);
    }
}
