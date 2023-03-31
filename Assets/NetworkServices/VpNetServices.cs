using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class VpNetServices : MonoBehaviour
{
    
    static public IEnumerator Upload( string studentEmail, UserData data, System.Action<bool, string, string, long> callback)
    {
        var jsonData = JsonUtility.ToJson(data);
        
        WWWForm form = new WWWForm();
        form.AddField("FILENAME", studentEmail);
        form.AddField("PRACTICENAME", Application.productName);
        form.AddField("FILEDATA", jsonData);

        using (UnityWebRequest www = UnityWebRequest.Post("http://54.144.50.139/virtualplantApiServices/userData/endpoint/Upload.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {                
                callback(false, www.downloadHandler.text, www.error, www.responseCode);
            }
            else
            {
                callback(true, www.downloadHandler.text, www.error, www.responseCode);
            }
        }
    }


    static public IEnumerator Download(string studentEmail, UserData data, System.Action<bool, string, string, long> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("FILENAME", studentEmail);
        form.AddField("PRACTICENAME", Application.productName);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://54.144.50.139/virtualplantApiServices/userData/endpoint/Download.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {                
                callback(false, www.downloadHandler.text, www.error, www.responseCode);
            }
            else
            {
                callback(true, www.downloadHandler.text, www.error, www.responseCode);
                if(www.responseCode==200)
                JsonUtility.FromJsonOverwrite( www.downloadHandler.text, data);
            }
        }
    }

    static public IEnumerator CheckFile(string studentEmail, System.Action<bool, string, string, long> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("FILENAME", studentEmail);
        form.AddField("PRACTICENAME", Application.productName);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://54.144.50.139/virtualplantApiServices/userData/endpoint/CheckFile.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {                
                callback(false, www.downloadHandler.text, www.error, www.responseCode);
            }
            else
            {
                callback(true, www.downloadHandler.text, www.error, www.responseCode);                
                
            }
        }
    }
    
   
}
