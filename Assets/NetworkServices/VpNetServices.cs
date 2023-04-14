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


    static public IEnumerator CreateReportWithUserData(UserData data, System.Action<bool, string, string, long> callback)
    {
        WWWForm form = new WWWForm();
       
        var jsonData = JsonUtility.ToJson(data);

        Debug.Log(jsonData);

        form.AddField("studentName", data.name);
        form.AddField("tamplateName", data.templateName);
        form.AddField("reportName", data.fileName);
        form.AddField("data", jsonData);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://54.144.50.139/virtualplantApiServices/reportData/endpoint/report.php", form))
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


    static public IEnumerator SendMail(UserData data, System.Action<bool, string, string, long> callback)
    {
        WWWForm form = new WWWForm();
       
        var jsonData = JsonUtility.ToJson(data);

        Debug.Log(jsonData);

        form.AddField("email1", data.email);
        form.AddField("email2", data.teacherEmail);
        form.AddField("reportUrl", data.reportUrl);
        form.AddField("studentName", data.name);
        form.AddField("practiceName", data.practiceName);
        form.AddField("institution", data.institution);
        form.AddField("academicProgram", data.academicProgram);
        form.AddField("subject", data.subject);
        form.AddField("studentCode", data.studentCode);
        form.AddField("teacherName", data.teacherName);        
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://54.144.50.139/virtualplantApiServices/mailService/endPoint/sendMail.php", form))
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


     static public IEnumerator SendValuation(UserData data, string value, string valueDetails, System.Action<bool, string, string, long> callback)
    {
        WWWForm form = new WWWForm();
       
        var jsonData = JsonUtility.ToJson(data);

        Debug.Log(jsonData);

        form.AddField("studentName", data.name);
        form.AddField("practiceName", data.practiceName + " " +Application.productName);
        form.AddField("value", value);
        form.AddField("valueDetails", valueDetails);        
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://54.144.50.139/virtualplantApiServices/mailService/endPoint/sendValuation.php", form))
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
