using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsOneWeekManager : MonoBehaviour
{

    [SerializeField]
    GameObject transition;

    [SerializeField]
    Image transitionImage;

    [SerializeField]
    Image logoTransition;

    [SerializeField]
    Text textTransition;

    [SerializeField]
    PlayerCanMove move;

    [SerializeField]
    UIDialogManager dialog;

    int dialogState;

    [SerializeField] GameObject resultsSupervisor;
    [SerializeField] GameObject[] supervisors;
    [SerializeField] GameObject getPriceDance;
    [SerializeField] GameObject getPriceMontacargas;

    [SerializeField] GameObject finalBoard;

    [SerializeField] GameObject finalResult;

    GameObject player;

    Color colorWhite = Color.white;
    Color colorBlack = Color.black;


    private void OnEnable()
    {
        dialogState = 1;
        transition.SetActive(true);
        colorWhite.a = 0;
        colorBlack.a = 0;
        transitionImage.color = colorBlack;
        logoTransition.color = colorWhite;
        StartCoroutine(AnimTransition());
        player = GameObject.FindWithTag("Player");
        move.CanMove = false;

    }

    void offSupervisors()
    {
        supervisors = GameObject.FindGameObjectsWithTag("Supervisor");

        foreach (GameObject i in supervisors)
        {
            i.SetActive(false);
        }
    }




    IEnumerator AnimTransition()
    {
        for (float i = 0; i < 1; i += 0.02f)
        {
            colorBlack.a = i;
            colorWhite.a = i;
            transitionImage.color = colorBlack;
            logoTransition.color = colorWhite;
            textTransition.color = colorWhite;
            yield return null;
        }


        player.transform.position = new Vector3(19f, 0, -36f);
        player.transform.rotation = Quaternion.Euler(0, -50, 0);
        offSupervisors();
        resultsSupervisor.SetActive(true);

        yield return new WaitForSecondsRealtime(2);

        for (float i = 1; i > 0; i -= 0.02f)
        {
            colorBlack.a = i;
            colorWhite.a = i;
            transitionImage.color = colorBlack;
            logoTransition.color = colorWhite;
            textTransition.color = colorWhite;
            yield return null;
        }

        transition.SetActive(false);
        SoundManager.Instance().PlayNaturalAmbience();
        move.CanMove = true;
        HelpManager.Instance().SetHelp("La propuesta fue implementada y ha pasado una semana, busque al supervisor de la planta para observar los resultados obtenidos.");
        getPriceDance.SetActive(true);
        IndicatorManager.instance().SetDestiny(new Vector3(resultsSupervisor.transform.position.x, 0, resultsSupervisor.transform.position.z));
    }

    public void EndAlertMesagge()
    {
        move.CanMove = true;

        gameObject.SetActive(false);
    }

    public void EnbleFInalBoard()
    {
        finalBoard.SetActive(true);
        HelpManager.Instance().SetHelp("En el momento que lo desee puede finalizar la práctica hablando con el supervisor.");
        IndicatorManager.instance().SetDestiny(new Vector3(resultsSupervisor.transform.position.x, 0, resultsSupervisor.transform.position.z));
        getPriceMontacargas.SetActive(true);
        dialogState = 2;
    }

    public void EnbleFInalResult()
    {
        finalResult.SetActive(true);
        resultsSupervisor.SetActive(false);
        gameObject.SetActive(false);
    }


    public void DialogController()
    {
        dialog.GoToNode(dialogState);
    }



}
