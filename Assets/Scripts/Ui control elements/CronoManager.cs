using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CronoManager : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    Text digitalCount;

    [SerializeField]
    AudioSource sound;

    [SerializeField]
    GameObject btnParar;

    [SerializeField]
    GameObject btnIniciar;

    [SerializeField]
    GameObject btnReiniciar;

    [SerializeField]
    GameObject btnContinuar;

    [SerializeField]
    GameObject btnRegistrar;

    [SerializeField]
    TextMeshProUGUI time1;

    [SerializeField]
    TextMeshProUGUI time2;

    [SerializeField]
    TextMeshProUGUI time3;

    [SerializeField]
    GameObject normalMesagge;

    [SerializeField]
    GameObject badMesagge;

    [SerializeField]
    PlayerCanMove move;

    [SerializeField] ExperienceRewardManager expRewardManager;

    bool crono = false;

    string minSec;

    float time = 0;

    float minTime;

    float maxTime;

    private void Start()
    {
        btnContinuar.SetActive(false);
    }
    private void OnEnable()
    {
        anim.speed = 0;
        anim.SetTrigger("start");
        time1.text = "-";
        time2.text = "-";
        time3.text = "-";
        btnRegistrar.SetActive(false);
        btnReiniciar.SetActive(false);
        btnContinuar.SetActive(false);
        badMesagge.SetActive(false);
        normalMesagge.SetActive(true);
        move.CanMove = false;

        if (QuestTiming.Instance)
        {
            minTime = QuestTiming.Instance.CurrentOperationData.minTime * 60;
            maxTime = QuestTiming.Instance.CurrentOperationData.maxTime * 60;

            //print(minTime / 60f + " mintime");
            //print(maxTime / 60f + " maxtime");
        }

        else
        {
            minTime = 30;
            maxTime = 60;
        }


        if (Debug.isDebugBuild)
        {
            btnContinuar.SetActive(true);
        }

    }


    public void StartCrono()
    {
        if (!crono)
            StartCoroutine(StartCronoCorutine());
        else
            Stop();
    }

    IEnumerator StartCronoCorutine()
    {
        btnRegistrar.SetActive(false);
        btnParar.SetActive(true);
        btnIniciar.SetActive(false);
        btnReiniciar.SetActive(false);
        anim.speed = 1;
        crono = true;
        sound.Play();
        while (crono)
        {
            yield return new WaitForSeconds(.1f);
            time += 2.3f;
            //print(time);
            minSec = string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
            digitalCount.text = minSec;
        }
        anim.speed = 0;
        sound.Stop();
        btnParar.SetActive(false);
        btnIniciar.SetActive(true);
        btnRegistrar.SetActive(true);
        btnReiniciar.SetActive(true);
    }
    public void Stop()
    {
        crono = false;
    }

    public void Restart()
    {
        time = 0;
        minSec = string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
        digitalCount.text = minSec;
        anim.SetTrigger("start");
    }

    public void RegisterTime()
    {

        if (time >= minTime && time <= maxTime)
        {
            SoundManager.Instance().PlayGood();

            if (time1.text.Equals("-"))
            {
                time1.text = minSec;
            }
            else if (time2.text.Equals("-"))
            {
                time2.text = minSec;
            }
            else if (time3.text.Equals("-"))
            {
                btnIniciar.SetActive(false);
                btnParar.SetActive(false);
                btnRegistrar.SetActive(false);
                btnReiniciar.SetActive(false);
                time3.text = minSec;
                btnContinuar.SetActive(true);
            }

            btnRegistrar.SetActive(false);
            btnReiniciar.SetActive(false);
        }

        else
        {
            if (GameManager.scoreTimeTake > 0)
            {
                GameManager.scoreTimeTake -= 10;
            }

            badMesagge.SetActive(true);
            normalMesagge.SetActive(false);
            StartCoroutine(ReactiveNormalMessage());
            btnRegistrar.SetActive(false);
            btnReiniciar.SetActive(false);
            SoundManager.Instance().PlayError();
            expRewardManager.FailAttempt();
        }


        Restart();

    }

    public void Continue()
    {
        move.CanMove = true;
    }

    IEnumerator ReactiveNormalMessage()
    {
        yield return new WaitForSeconds(5f);
        badMesagge.SetActive(false);
        normalMesagge.SetActive(true);
    }
}
