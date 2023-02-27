using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerCortadoraTubos : MonoBehaviour {

    public GameObject tuboLargo;

    public GameObject tuboCortoIzq;

    public GameObject tuboCortoDer;

    public GameObject tuboLargoCortadora;

    public GameObject tuboCortoIzqCortadora;

    public GameObject tuboCortoDerCortadora;

    public ParticleSystem sparks;


    void Start ()
    {
        tuboLargo.SetActive(false);

        tuboCortoIzq.SetActive(false);

        tuboCortoDer.SetActive(false);

        tuboLargoCortadora.SetActive(false);

        tuboCortoIzqCortadora.SetActive(false);

        tuboCortoDerCortadora.SetActive(false);
    }

    public void InMachine()
    {
        tuboLargo.SetActive(true);

        tuboCortoIzq.SetActive(false);

        tuboCortoDer.SetActive(false);

        tuboLargoCortadora.SetActive(false);

        tuboCortoIzqCortadora.SetActive(false);

        tuboCortoDerCortadora.SetActive(false);
    }

    public void WhileMachine()
    {
        tuboLargo.SetActive(false);

        tuboCortoIzq.SetActive(false);

        tuboCortoDer.SetActive(false);

        tuboLargoCortadora.SetActive(true);

        tuboCortoIzqCortadora.SetActive(false);

        tuboCortoDerCortadora.SetActive(false);
    }

    public void CutMachine()
    {
        tuboLargo.SetActive(false);

        tuboCortoIzq.SetActive(false);

        tuboCortoDer.SetActive(false);

        tuboLargoCortadora.SetActive(false);

        tuboCortoIzqCortadora.SetActive(true);

        tuboCortoDerCortadora.SetActive(true);
    }

    public void OutMachine()
    {
        tuboLargo.SetActive(false);

        tuboCortoIzq.SetActive(true);

        tuboCortoDer.SetActive(true);

        tuboLargoCortadora.SetActive(false);

        tuboCortoIzqCortadora.SetActive(false);

        tuboCortoDerCortadora.SetActive(false);
    }

    public void EndMachine()
    {
        tuboLargo.SetActive(false);

        tuboCortoIzq.SetActive(false);

        tuboCortoDer.SetActive(false);

        tuboLargoCortadora.SetActive(false);

        tuboCortoIzqCortadora.SetActive(false);

        tuboCortoDerCortadora.SetActive(false);
    }

    public void sparksPlay()
    {
        sparks.Play();
    }

    public void sparksStop()
    {
        sparks.Stop();
    }





}
