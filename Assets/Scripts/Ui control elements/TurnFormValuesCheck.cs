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
    Toggle toggleOperators;

    [SerializeField]
    GameObject operatorsDropsObject;

    [SerializeField]
    GameObject operatorsFieldsObject;

    [SerializeField]
    TMP_Dropdown operators1;

    [SerializeField]
    TMP_Dropdown operators2;

    [SerializeField]
    TMP_Dropdown operators3;

    [SerializeField]
    TMP_InputField operatorsField;

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

    [SerializeField]
    GameObject[] selectors;

    [SerializeField] UserData userData;
    public int upValue;

    public int urValue;

    private bool enable;

    private void Update()
    {
        if(toggleOperators.isOn)
        {
            if (operatorsField.text == "")
            {
                Calculate(0);
            }
            else
            {
                Calculate(int.Parse(operatorsField.text));
            }
            
        }
    }
    public void ToggleOperator()
    {
        if (toggleOperators.isOn)
        {
           
            operatorsDropsObject.SetActive(false);
            operatorsFieldsObject.SetActive(true);
            ValidateTurnsField();
        }
        else
        {
            for (int i = 0; i < selectors.Length; i++)
            {
                selectors[i].SetActive(true);
            }
            operatorsDropsObject.SetActive(true);
            operatorsFieldsObject.SetActive(false);
            ValidateTurnsDrops();
        }
    }
    public void ValidateTurnsDrops()
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

        Calculate(op);
    }
    public void ValidateTurnsField()
    {
        var op = 0; 
        if(operatorsField.text == "")
        {
            operatorsField.text = "0";
        }
        op = int.Parse(operatorsField.text);
        Calculate(op);
    }
    public void Calculate(int op)
    {
        //btnContinue.SetActive(true);
        data = new string[8];

        urValue = (int)FormResultsManager.Instance.unidadesRequeridas;

        upValue = (int)(((((8 * 60) - 75) * op) / FormResultsManager.Instance.tiempoCicloCalculadas));

        FormResultsManager.Instance.unidadesProducidasCalculadas = upValue;

        upText.text = upValue.ToString("F0");

        urText.text = urValue.ToString("F0");

        FormResultsManager.Instance.UsersInput = op;

        FormResultsManager.Instance.UsersCalculate = Mathf.CeilToInt(FormResultsManager.Instance.tiempoCicloCalculadas / FormResultsManager.Instance.taktTimeCalculadas);

        if(userData.method == 1 || userData.method == 2)
        {
            userData.excelReport[0].M[42] = FormResultsManager.Instance.unidadesProducidasCalculadas.ToString();
        }
        else
        {
            userData.excelReport[0].M[66] = FormResultsManager.Instance.unidadesProducidasCalculadas.ToString();
        }
     

        data[6] = upValue.ToString("F0");

        Debug.Log("Operarios" + FormResultsManager.Instance.UsersCalculate);
      
    }

    private void OnEnable()
    {
        enable = true;       
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
