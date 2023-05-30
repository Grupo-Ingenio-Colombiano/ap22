using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnFormValuesCheck : MonoBehaviour
{
    public string[] data;

    [SerializeField]
    Toggle Turn1;

    [SerializeField]
    Toggle Turn2;

    [SerializeField]
    Toggle Turn3;

    [SerializeField]
    TMP_Dropdown operators1;

    [SerializeField]
    TMP_Dropdown operators2;

    [SerializeField]
    TMP_Dropdown operators3;

    [SerializeField]
    Text upText;

    [SerializeField]
    Text urText;

    [SerializeField]
    Collider col;

    [SerializeField]
    GameObject btnContinue, supervisorNulo, supervisorValidador;

    [SerializeField]
    InputField input;

    [SerializeField]
    InputField observaciones;

    GameObject player;

    [SerializeField] UserData userData;
    public int upValue;

    public int urValue;

  
    public void validateTurns()
    {
        data = new string[8];

        var op = 0;

        if (Turn1.isOn)
        {
            operators1.gameObject.SetActive(true);
            op += int.Parse(operators1.options[operators1.value].text);
            data[0] = "Si";
            data[1] = operators1.options[operators1.value].text;
            userData.turn1 = true;
        }
        else
        {
            operators1.gameObject.SetActive(false);
            data[0] = "No";
            data[1] = "0";
            userData.turn1 = false;
        }


        if (Turn2.isOn)
        {
            operators2.gameObject.SetActive(true);
            op += int.Parse(operators2.options[operators2.value].text);
            data[2] = "Si";
            data[3] = operators2.options[operators1.value].text;
            userData.turn2 = true;
        }

        else
        {
            operators2.gameObject.SetActive(false);
            data[2] = "No";
            data[3] = "0";
            userData.turn2 = false;
        }


        if (Turn3.isOn)
        {
            operators3.gameObject.SetActive(true);
            op += int.Parse(operators3.options[operators3.value].text);
            data[4] = "Si";
            data[5] = operators3.options[operators1.value].text;
            userData.turn3 = true;
        }

        else
        {
            operators3.gameObject.SetActive(false);
            data[4] = "No";
            data[5] = "0";
            userData.turn3 = false;
        }

        //btnContinue.SetActive(true);

        urValue = (int)FormResultsManager.Instance.unidadesRequeridas;

        upValue = (int)(((((8 * 60) - 75) * op) / FormResultsManager.Instance.tiempoCicloCalculadas));

        FormResultsManager.Instance.unidadesProducidasCalculadas = upValue;

        upText.text = upValue.ToString("F0");

        urText.text = urValue.ToString("F0");

        FormResultsManager.Instance.UsersInput = op;

        FormResultsManager.Instance.UsersCalculate = Mathf.CeilToInt(FormResultsManager.Instance.tiempoCicloCalculadas / FormResultsManager.Instance.taktTimeCalculadas);

        userData.excelReport[0].M[31] = FormResultsManager.Instance.unidadesProducidasCalculadas.ToString();

        data[6] = upValue.ToString("F0");

      
    }

    private void OnEnable()
    {
        validateTurns();
        //btnContinue.SetActive(false);
        //btnContinue.SetActive(true);
        player = GameObject.FindWithTag("Player");
    }

    public void Continue()
    {
        userData.unitPerDay = upValue;
        userData.unitsRquired = urValue;
        data[7] = observaciones.text;
        player.SetActive(true);
        FollowCameraController.instance.ResetCameraFollow();
        col.enabled = true;
        btnContinue.SetActive(false);
        input.interactable = false;
        IndicatorManager.instance().SetDestiny(new Vector3(35.42f, 0, -73.8f));
        HelpManager.Instance().SetHelp("Hable con el supervisor de planta para validar su propuesta.");
        supervisorNulo.SetActive(false);
        supervisorValidador.SetActive(true);
    }

    public void ValidateUsers()
    {
        var takTime = FormResultsManager.Instance.taktTimeCalculadas;
        var cicloTime = FormResultsManager.Instance.tiempoCicloCalculadas;
        var unidadesProducidas = FormResultsManager.Instance.unidadesProducidasCalculadas;
    }


}
