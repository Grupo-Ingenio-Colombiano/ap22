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
        Debug.Log("Se subieron datos de la práctica");
        data.isSave = true;
        StartCoroutine(VpNetServices.Upload(data.email, data, UploadResponse));

    }
    void UploadResponse(bool success, string handler, string error, long code)
    {
        Debug.Log("Datos Subidos");
    }


    private void Start()
    {
        //if(data.load == 1)
        //{
        //    VD.isActive = true;
        //    dialogManager.SetOverrideStartNode(10);
        //}
    }
}
