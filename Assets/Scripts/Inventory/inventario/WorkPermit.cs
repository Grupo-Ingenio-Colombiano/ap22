using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkPermit : MonoBehaviour
{

    public InputField[] fields;

    [SerializeField]
    GameObject label;

    [SerializeField] Canvas canvasForm;

    [SerializeField] GameObject instructionsBlock;

    [SerializeField] InputField userNameField;
    [SerializeField] InputField userIDField;
    [SerializeField] InputField userLastNameField;

    [SerializeField] UserData userData;

    public static string userName;
    public static string userLastName;
    public static string userID;


    private void Start()
    {
        if(userData.isSave == true)
        {
            userNameField.text = userData.nombreForm;
            userLastNameField.text = userData.apellidoForm;
            userIDField.text = userData.iDForm;
        }
    }
    private void OnEnable()
    {
        DisableFields();
    }


    public bool ValidateFields()
    {

        foreach (InputField i in fields)
        {
            if (i.text == "")
            {
                return false;
            }
        }

        return true;

    }

    public void blockFields()
    {
        foreach (InputField i in fields)
        {
            i.interactable = false;
        }
    }

    public void EnableCanvas()
    {
        var dialog = FindObjectOfType(typeof(UIDialogManager)) as UIDialogManager;
        dialog.GetComponentInParent<Canvas>().enabled = false;

        canvasForm.enabled = true;

        EnableFields();
    }

    public void Validate()
    {
        if (ValidateFields())
        {
            SoundManager.Instance().PlayGood();
            canvasForm.enabled = false;
            userName = userNameField.text;
            userLastName = userLastNameField.text;
            userID = userIDField.text;

            userData.nombreForm = userNameField.text;
            userData.apellidoForm = userLastNameField.text;
            userData.iDForm = userIDField.text;

            var dialog = FindObjectOfType(typeof(UIDialogManager)) as UIDialogManager;
            dialog.GetComponentInParent<Canvas>().enabled = true;
            dialog.CallNext();
            instructionsBlock.SetActive(false);
            DisableFields();
        }
        else
        {
            SoundManager.Instance().PlayError();
            label.SetActive(true);
        }

    }

    void DisableFields()
    {
        foreach (var item in fields)
        {
            item.interactable = false;
        }
    }

    void EnableFields()
    {
        foreach (var item in fields)
        {
            item.interactable = true;
        }
    }

}
