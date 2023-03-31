using System.Collections;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VpNewNotice : MonoBehaviour
{
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
}
