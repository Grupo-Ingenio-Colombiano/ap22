﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    GameObject boardCorte, boardDoblado, boardRectificado;

    [SerializeField]
    GameObject supervisorNulo, supervisorValidator;

    [SerializeField]
    UIDialogManager dialog;

    [SerializeField]
    GameObject sadEscene;


    [SerializeField]
    GameObject resultsOneWeekManager;

    GameObject[] supervisors;

    [SerializeField]
    MethodData methodData;

     TurnFormValuesCheck form;

    [SerializeField] UserData userData;

    int tryTurn = 0;


    private void OnEnable()
    {
        EnableBoard();
        offSupervisors();
        supervisorNulo.SetActive(true);
    }

    void offSupervisors()
    {
        supervisors = GameObject.FindGameObjectsWithTag("Supervisor");

        foreach (GameObject i in supervisors)
        {
            i.SetActive(false);
        }
    }

    public void EnableBoard()
    {

        switch (FormResultsManager.Instance.currentOperationIndex)
        {

            case 1:
                boardCorte.SetActive(true);
                form = boardCorte.GetComponent<TurnFormValuesCheck>();
                IndicatorManager.instance().SetDestiny(new Vector3(boardCorte.transform.position.x, 0, boardCorte.transform.position.z + 0.75f));
                break;

            case 2:
                boardDoblado.SetActive(true);
                form = boardDoblado.GetComponent<TurnFormValuesCheck>();
                IndicatorManager.instance().SetDestiny(new Vector3(boardDoblado.transform.position.x, 0, boardDoblado.transform.position.z + 0.75f));
                break;

            case 3:
                boardRectificado.SetActive(true);
                form = boardRectificado.GetComponent<TurnFormValuesCheck>();
                IndicatorManager.instance().SetDestiny(new Vector3(boardRectificado.transform.position.x, 0, boardRectificado.transform.position.z + 0.75f));
                break;
        }


        HelpManager.Instance().SetHelp("Ubique el tablero de producción en el proceso de estudio, haga clic en el y proponga un número de turnos y de operarios x turno que satisfaga el cumplimiento de la demanda. Cuando tenga lista su propuesta entréguela al supervisor de planta.");

    }

    public int TurnValidator()
    {
        //print("usuarios calculados " + FormResultsManager.Instance.UsersCalculate + " usuarios ingresados " + FormResultsManager.Instance.UsersInput);


        if (FormResultsManager.Instance.UsersCalculate.Equals(FormResultsManager.Instance.UsersInput))
        {

            return 1;

        }

        else if (FormResultsManager.Instance.UsersCalculate < FormResultsManager.Instance.UsersInput)
        {
            if (tryTurn < 3)
            {

                return 2;
            }
            else
                return 4;
        }

        else if (FormResultsManager.Instance.UsersCalculate > FormResultsManager.Instance.UsersInput)
        {
            if (tryTurn < 3)
            {
                return 3;
            }
            else
                return 4;
        }

        else

            return 0;

    }

    public void GotoNodeTurnValidator()
    {

        form = FindAnyObjectByType<TurnFormValuesCheck>();
        tryTurn += 1;
        dialog.GoToNode(TurnValidator());
        switch (tryTurn)
        {
            case 1:
                int turn = 0;
                if (form.toggleOperators.isOn)
                {
                     turn = int.Parse(form.operatorsExcel);
                }
                else
                {
                     turn = int.Parse(form.data[1]) + int.Parse(form.data[3]) + int.Parse(form.data[5]);
                }
                Debug.Log("La cantidad de turnos es " + turn);

                if(userData.method == 3)
                {
                    userData.operators[0] = form.operatorsField.text;
                }
               
                methodData.t1I1 = form.data[0]; methodData.o1I1 = form.data[1]; methodData.t2I1 = form.data[2]; methodData.o2I1 = form.data[3]; methodData.t3I1 = form.data[4]; methodData.o3I1 = form.data[5]; methodData.upI1 = form.data[6]; methodData.obI1 = form.observaciones.text;
                break;

            case 2:
                int turn2 = 0;
                if (form.toggleOperators.isOn)
                {
                    turn2 = int.Parse(form.operatorsExcel);
                }
                else
                {
                    turn2 = int.Parse(form.data[1]) + int.Parse(form.data[3]) + int.Parse(form.data[5]);
                }
                Debug.Log("La cantidad de turnos es " + turn2);
                if (userData.method == 3)
                {
                    userData.operators[1] = form.operatorsField.text;
                }
                methodData.t1I2 = form.data[0]; methodData.o1I2 = form.data[1]; methodData.t2I2 = form.data[2]; methodData.o2I2 = form.data[3]; methodData.t3I2 = form.data[4]; methodData.o3I2 = form.data[5]; methodData.upI2 = form.data[6]; methodData.obI2 = form.observaciones.text;
                break;

            case 3:
                int turn3 = 0;
                if (form.toggleOperators.isOn)
                {
                    turn3 = int.Parse(form.operatorsExcel);
                }
                else
                {
                    turn3 = int.Parse(form.data[1]) + int.Parse(form.data[3]) + int.Parse(form.data[5]);
                }
                if (userData.method == 3)
                {
                    userData.operators[2] = form.operatorsField.text;
                }
                Debug.Log("La cantidad de turnos es " + turn3);
              
                methodData.t1I3 = form.data[0]; methodData.o1I3 = form.data[1]; methodData.t2I3 = form.data[2]; methodData.o2I3 = form.data[3]; methodData.t3I3 = form.data[4]; methodData.o3I3 = form.data[5]; methodData.upI3 = form.data[6]; methodData.obI3 = form.observaciones.text;
                break;
        }
    }

    public void SetNullSupervisorFailMessage()
    {

        supervisorValidator.SetActive(false);
        supervisorNulo.SetActive(true);
        switch (TurnValidator())
        {
            case 2:
                HelpManager.Instance().SetHelp("Su propuesta está empleando más recursos de los necesarios. Diríjase al tablero y formule una nueva propuesta.");
                break;

            case 3:
                HelpManager.Instance().SetHelp("Su propuesta no satisface la demanda. Diríjase al tablero y formule una nueva propuesta.");
                break;

        }

        switch (FormResultsManager.Instance.currentOperationIndex)
        {

            case 1:
                boardCorte.SetActive(true);
                IndicatorManager.instance().SetDestiny(new Vector3(boardCorte.transform.position.x, 0, boardCorte.transform.position.z + 0.75f));
                break;

            case 2:
                boardDoblado.SetActive(true);
                IndicatorManager.instance().SetDestiny(new Vector3(boardDoblado.transform.position.x, 0, boardDoblado.transform.position.z + 0.75f));
                break;

            case 3:
                boardRectificado.SetActive(true);
                IndicatorManager.instance().SetDestiny(new Vector3(boardRectificado.transform.position.x, 0, boardRectificado.transform.position.z + 0.75f));
                break;
        }

    }

    public void FailTurnValidator()
    {
        sadEscene.SetActive(true);
    }

    public void CorrectTurnValidator()
    {
        resultsOneWeekManager.SetActive(true);
        userData.experienceTurnOperators = 100;
        PlayerDataManager.Instance.AddExperience(100);
        GameManager.scoreUpgradeForm = 30 - (tryTurn * 10);
        PlayerDataManager.Instance.AddProgress(35);
    }

    public void ViewData()
    {
        var takTime = FormResultsManager.Instance.taktTimeCalculadas;
        var cicloTime = FormResultsManager.Instance.tiempoCicloCalculadas;
        var unidadesProducidas = FormResultsManager.Instance.unidadesProducidasCalculadas;

        // Validacion en consola de variables
        print("Tak Time = " + takTime);
        print("cicloTime = " + cicloTime);
        print("unidades Producidas = " + unidadesProducidas);
        print("Unidades requeridas  =  " + FormResultsManager.Instance.unidadesRequeridas);
        print("Operacion seleccionada  =  " + FormResultsManager.Instance.currentOperationIndex);


        /*print("numMinutosMuestreo = " + QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo);
        print("porcentajeDedicadoOperacion  =  " + QuestSampling.Instance.CurrentOperationData.porcentajeDedicadoOperacion);
        print("factorRitmo  =  " + QuestSampling.Instance.CurrentOperationData.factorRitmo);
        print("K  =  " + QuestSampling.Instance.CurrentOperationData.K);
        print("unidadesRealizadas  =  " + QuestSampling.Instance.CurrentOperationData.unidadesRealizadas);*/
    }
}
