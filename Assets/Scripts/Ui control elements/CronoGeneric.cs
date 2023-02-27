using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CronoGeneric : MonoBehaviour
{
    //[SerializeField]
    //Animator anim;

    [SerializeField]
    Text digitalCount;

    [SerializeField]
    AudioSource sound;

    [SerializeField]
    RectTransform manilla;

    [SerializeField] GameObject talkOperatorCapsule;


    string minSec;

    float time = 0;

    float randomTime = 0;

    private void OnEnable()
    {

        time = 0;

        randomTime = 0;

        minSec = string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
        digitalCount.text = minSec;

        if (!QuestSampling.Instance)
        {
            randomTime = 180;
        }

        else
        {
            randomTime = QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo;
        }

        randomTime *= 60;

        StartCoroutine(StartCronoCorutine());
    }


    IEnumerator StartCronoCorutine()
    {
        sound.Play();
        var rot = -62f;

        while (time < randomTime)
        {
            yield return new WaitForSecondsRealtime(.1f);

            time += randomTime / 100;
            //print(time);
            rot -= 36;
            minSec = string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
            digitalCount.text = minSec;
            manilla.localRotation = Quaternion.Euler(0, 0, rot);
        }
        time = randomTime;
        minSec = string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
        digitalCount.text = minSec;
        manilla.localRotation = Quaternion.Euler(0, 0, -62f);
        sound.Stop();

        if (GameObject.FindWithTag("TextContainer"))
        {
            var dialogManager = FindObjectOfType(typeof(UIDialogManager)) as UIDialogManager;
            dialogManager.CallNext();
        }

        talkOperatorCapsule.SetActive(true);
    }

    public void Restart()
    {
        time = 0;
        minSec = string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
        digitalCount.text = minSec;
    }
}
