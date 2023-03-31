
using UnityEngine;
using UnityEngine.UI;


public class NoticeManager : MonoBehaviour
{

    [SerializeField]
    GameObject canavasNotice, btn1, btn2, btn3;

    [SerializeField]
    Button  btnYes, btnNo, btnAccept;

    [SerializeField]
    TMPro.TextMeshProUGUI title, aviso;


    public void CloseNotice()
    {
        Destroy(gameObject);
    }

    public void AnswerNotice( bool response)
    {
        Destroy(gameObject);
    }

    public void SetNotice(string title, string content)
    {
        this.title.text = title;
        aviso.text = content;
        canavasNotice.SetActive(true); 
        btn1.SetActive(true);     
        btn2.SetActive(false); 
    }

    public void SetNotice(string title, string content, System.Action<Button, Button> Callback )
    {
        this.title.text = title;
        aviso.text = content;
        canavasNotice.SetActive(true); 
        btn1.SetActive(false);     
        btn2.SetActive(true);

        Callback(btnYes, btnNo);
        
    }
    public void SetNotice(string title, string content, System.Action<Button> Callback)
    {
        this.title.text = title;
        aviso.text = content;
        canavasNotice.SetActive(true);
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(true);

        Callback(btnAccept);

    }



}
