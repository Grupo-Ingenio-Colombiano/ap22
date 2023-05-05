using System.Collections;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VpNewNotice : MonoBehaviour
{
    static Object SavingPanel;

    public static void SetNotice(string title,string content)
    {        
        var notice = Instantiate(Resources.Load("notice/Notice"));
        notice.GetComponent<NoticeManager>().SetNotice(title, content);
    }    
    

    static public void SetNotice(string title, string content, System.Action<Button, Button> Callback )
    {
        
        var notice = Instantiate(Resources.Load("notice/Notice"));
        notice.GetComponent<NoticeManager>().SetNotice(title, content, Callback);
    }
    static public void SetNotice(string title, string content, System.Action<Button> Callback)
    {
        
       var notice = Instantiate(Resources.Load("notice/Notice"));
       notice.GetComponent<NoticeManager>().SetNotice(title, content, Callback);

    }

    public static void StartSavingAnimation()
    {    
        if(SavingPanel != null )   
        { 
            Destroy(SavingPanel);
        }     
        
        SavingPanel = Instantiate(Resources.Load("notice/SavingPanel"));        
    }    

    public static void StopSavingAnimation()
    { 
        if(SavingPanel)   
        { 
            Destroy(SavingPanel);
        } 
                
    }   
    
}
