using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(UserData))]
public class ReportManager : MonoBehaviour
{
    string valuation;

    [Header("--------- buttons  ----------" ) ]

    [SerializeField]   GameObject buttonsGenerate;

    [SerializeField]   GameObject buttonsDownload;    

    [Header("--------- graphics  ----------")]

    [SerializeField] Image trophyImage;
    [SerializeField] Sprite[] trophySprites;

    [SerializeField] Image experienceSlider;

    [Header("--------- texts  ----------")]

    [SerializeField]    TMPro.TextMeshProUGUI experienceText ;
    [SerializeField]    TMPro.TextMeshProUGUI  timeText;

    [Header("--------- objects animate  ----------")]    

    [SerializeField] GameObject[] trophyStars;
    [SerializeField] GameObject[] progressStars;
    [SerializeField] GameObject trophyGameobject;

    [SerializeField] float animationTime;

    [Header("--------- Send Report Data ----------")]  
    [SerializeField]   Button buttonSendReport;

    [SerializeField] GameObject sendReportWindow;  
    [SerializeField] TMPro.TMP_InputField[] finlaReportFields;  
    // 0: institución , 1: programa academico, 2: Asignatura, 3: Código, 4: Nombre Profesor, 5: email profesor, 6: confirmación del correo
    [SerializeField]    TMPro.TextMeshProUGUI  nameText;
    [SerializeField]    TMPro.TextMeshProUGUI  emailText;

    [Header("--------- Valuation Data ----------")]  
    
    [SerializeField] Button buttonSendValuation;   
    [SerializeField] TMPro.TMP_InputField inputFieldValuation; 
    [SerializeField] GameObject sendValuationResponseBox; 

    [Header("--------- Answers Data ----------")]  
    [SerializeField] GameObject answersBox; 

    [SerializeField] TMPro.TextMeshProUGUI badAnswersText; 

    [SerializeField] TMPro.TextMeshProUGUI goodAnswersText; 

    
    [Header("--------- Fill User data before start  ----------")]

    [SerializeField]  UserData userData;


    
    void SetDateOnUserData()
    {
        var date = System.DateTime.Now;
        var dateString = date.ToString("MM/dd/yyyy");
        var hourString = date.ToString("hh:mm tt");

        userData.excelReport[0].G[8]=dateString + "   " + hourString;
        
       
    }


    // Start 

    private void Start() {
        buttonsGenerate.SetActive(true);
        buttonsDownload.SetActive(false);
        SetUiValues();
        ShowAnswers();

        SetDateOnUserData();

        //-------------- Report Logic ---------------
     }
   

    public void ActiveSendReportWindow()
    {
        sendReportWindow.SetActive(true);
        nameText.text = userData.name;
        emailText.text = userData.email;
    }

    public void SendReport()
    {
        foreach (var item in finlaReportFields)
        {
            if(item.text.Length==0)
            {
                VpNewNotice.SetNotice(" Campos vacíos", "Por favor complete todos los campos para continuar");
                return;
            }
              
        }

        if(!finlaReportFields[5].text.Contains('@') || !finlaReportFields[5].text.Contains('@') ||  !finlaReportFields[6].text.Contains('@') || !finlaReportFields[6].text.Contains('@')  )
        {
            VpNewNotice.SetNotice("Email no válido", "El formato del correo electrónico es incorrecto");
             return;
        }

        if(finlaReportFields[5].text != finlaReportFields[6].text  )
        {
            VpNewNotice.SetNotice("Error", "Los correos  del docente no coinciden");
            return;
        }   


        userData.institution =  finlaReportFields[0].text;
        userData.academicProgram =  finlaReportFields[1].text;
        userData.subject =  finlaReportFields[2].text;
        userData.studentCode =  finlaReportFields[3].text;
        userData.teacherName =  finlaReportFields[4].text;
        userData.teacherEmail =  finlaReportFields[5].text;

        StartCoroutine(VpNetServices.SendMail(userData, CallbackSendReport));
        buttonSendReport.interactable =false;
        
    }

     void CallbackSendReport(bool success, string handler, string error, long code)
    {
        Debug.Log(success);
        Debug.Log(handler);
        Debug.Log(error);
        Debug.Log(code);

        if(code>200)
        {            
            VpNewNotice.SetNotice("Error", "No fue posible enviar el email, por favor verifique su conexión a internet e intente nuevamente");
            buttonSendReport.interactable =true;
            return;
        }

        VpNewNotice.SetNotice("Felicidades", "Su reporte se ha enviado correctamente");
        sendReportWindow.SetActive(false);       
        buttonSendReport.interactable =true;
        
    }

        public void DownloadReport()
    {
        Application.OpenURL(userData.reportUrl);
    }


    public void GenerateReport()
    {
        buttonsGenerate.SetActive(false);
        buttonsDownload.SetActive(false);
        StartCoroutine(VpNetServices.CreateReportWithUserData(userData, CallbackDownloadReport));
    }

    void CallbackDownloadReport(bool success, string handler, string error, long code)
    {
        Debug.Log(success);
        Debug.Log(handler);
        Debug.Log(error);
        Debug.Log(code);

        if(code>200)
        {
            buttonsGenerate.SetActive(true);
            VpNewNotice.SetNotice("Error", "No fue posible generar su reporte, por favor verifique su conexión a internet e intente nuevamente");
            return;
        }

        userData.reportUrl = handler;
        buttonsDownload.SetActive(true);
        
        
    }

    //-------------- Set Values on UI ---------------

    void SetUiValues()
    {
        if (userData.experience > 500)
        {
            userData.experience = 500;
        }
        switch (userData.experience)
        {            
            default:
            TurnOnStars(0);
            trophyImage.gameObject.SetActive(false);
            userData.excelReport[0].F[18] = "No Obtenido";

                break;

            case >=450:
            TurnOnStars(3);
            trophyImage.sprite = trophySprites[0];
                userData.excelReport[0].F[18] = "Oro";
                break;

            case >=400:
            TurnOnStars(2);
            trophyImage.sprite = trophySprites[1];
                userData.excelReport[0].F[18] = "Plata";
                break;

            case >=300:
            TurnOnStars(1);
            trophyImage.sprite = trophySprites[2];
                userData.excelReport[0].F[18] = "Bronce";
                break;
        }

        timeText.text = userData.time;

        var sliderValueConversion = userData.experience / 500f;

        float fillval = 0;
                DOTween.To(() => fillval, x => fillval = x, sliderValueConversion, animationTime)
                .OnUpdate(() => { experienceSlider.fillAmount = fillval;   });

        int experienceValue = 0;
        DOTween.To(() => experienceValue, x => experienceValue = (int)x, userData.experience, animationTime)
        .OnUpdate( ()=> {experienceText.text =experienceValue.ToString() + " EXP"; });
} 

    void TurnOnStars(int index)
    {
        for (int i = 0; i < index; i++)
        {            
            trophyStars[i].SetActive(true);
            progressStars[i].SetActive(true);
        }
    }


    //-------------- Show Exit messagge ---------------

    public void ShowExitMessage()
    {
        VpNewNotice.SetNotice("Salir","Para salir, por favor cierre la pestaña en su navegador");
    }


    //--------------Valuation Logic ---------------

    public void SetValuation(string val)
    {
        valuation = val.ToString();
        buttonSendValuation.interactable = true;   
             
    }

     public void SendValuation()
    {
        StartCoroutine(VpNetServices.SendValuation(userData, valuation, inputFieldValuation.text,CallbackSendValuation )); 
        buttonSendValuation.interactable = false; 
    }

    void CallbackSendValuation(bool success, string handler, string error, long code)
    {
        Debug.Log(success);
        Debug.Log(handler);
        Debug.Log(error);
        Debug.Log(code);

        if(code>200)
        {
            buttonsGenerate.SetActive(true);
            VpNewNotice.SetNotice("Error", "No fue posible enviar su valoración, por favor verifique su conexión a internet e intente nuevamente");
            buttonSendValuation.interactable = true;  
            return;
        }

        VpNewNotice.SetNotice("Gracias", "Su valoración fue enviada correctamente");
        buttonSendValuation.interactable = true;  
        
        
    }

    //--------------Answers Logic ---------------

    public void ShowAnswers()
    {
        if(userData.goodAnswer == 0 && userData.badAnswer == 0)
        {
            answersBox.SetActive(false);
        }
        else
        {
            answersBox.SetActive(true);

            int goodValue = 0;
            DOTween.To( ()=> goodValue, x => goodValue = x, userData.goodAnswer, animationTime )
            .OnUpdate( ()=> { goodAnswersText.text =goodValue.ToString(); });

            int badValue = 0;       
            DOTween.To( ()=> badValue, x => badValue = x, userData.badAnswer, animationTime  )
            .OnUpdate( ()=> { badAnswersText.text =badValue.ToString(); });
        }
    }

       
}
