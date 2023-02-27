using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinalResultsManager : MonoBehaviour
{
    public static FinalResultsManager instance = null;

    private void Awake()
    {        
        if (instance == null)            
            instance = this;        
        else if (instance != this)            
            Destroy(gameObject);
    }

    public string trophy;

    public float finalExperience;

    private const string NOT_CONCLUDED_TEXT = "No ha concluido la práctica de ";
    private const string CONCLUDED_TEXT = "Ha completado la práctica de ";

    private const string BRONCE_TROPHY_TEXT = "Ha obtenido el trofeo de bronce";
    private const string SILVER_TROPHY_TEXT = "Ha obtenido el trofeo de plata";
    private const string GOLD_TROPHY_TEXT = "Ha obtenido el trofeo de oro";

    [SerializeField] string nombrePractica;
    [SerializeField] Image imgFelicidades;

    [Header("ResultTexts")]
    [SerializeField]
    GameObject endTime;
    [SerializeField] GameObject endCorrect;
    [SerializeField] GameObject endIncorrect;
    [SerializeField] GameObject endExperience;

    [Header("Stars")]
    [SerializeField]
    GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    [SerializeField] Sprite starOn;
    [SerializeField] Sprite starOff;

    [Header("Trophy")]
    [SerializeField]
    GameObject endTrophy;
    [SerializeField] Sprite trophyBronce;
    [SerializeField] Sprite trophySilver;
    [SerializeField] Sprite trophyGold;

    [Header("Labels")]
    [SerializeField]
    GameObject textNoTrophy;
    [SerializeField] GameObject textTrophy;
    [SerializeField] GameObject tittle;
    [SerializeField] GameObject parrafo;
    


    [Header("PlayerData")]
    [SerializeField]
    PlayerExperience experience;
    [SerializeField] PlayerAnswers answers;
    [SerializeField] PlayerProgress progress;

    [Header("Buttons")]//adiciono esto para controlar los botones de descarga y finalizar
    [SerializeField] GameObject BtnFileDownload;
    [SerializeField] GameObject BtnEnds;


    [Header("other")]

    [SerializeField]
    AudioSource scoreCount;
    [SerializeField] AudioSource star;
    [SerializeField] AudioSource win;

    float exp = 0;
    float maxExp = 500;

    private void OnEnable()
    {
        ShowResultsData();
    }

    public void ShowResultsData()
    {
        /*if (exp > maxExp)
        {
            exp = maxExp;
        }
        if (progress.CurrentProgress > progress.MaxProgress)
        {
            progress.CurrentProgress = progress.MaxProgress;
        }*/

        endTrophy.transform.localScale = Vector3.zero;
        textTrophy.GetComponent<Text>().text = "";

        exp = experience.CurrentExperience;
        maxExp = experience.MaxExperience;

        endCorrect.GetComponent<Text>().text = answers.CorrectAnswers.ToString();
        endIncorrect.GetComponent<Text>().text = answers.IncorrectAnswers.ToString();

        GetComponent<Animator>().SetTrigger("end");

        /*if (progress.CurrentProgressPercentage < 0.95f)
        {
            tittle.GetComponent<Text>().text = "";
            parrafo.GetComponent<Text>().text = CONCLUDED_TEXT + nombrePractica;//NOT_CONCLUDED_TEXT

            StartCoroutine(AnimateExperience(0, exp));
        }
        else
        {*/
            StartCoroutine(AnimateImageFelicidades(0, 1));
            StartCoroutine(AnimateExperience(0, exp));
            parrafo.GetComponent<Text>().text = CONCLUDED_TEXT + nombrePractica;
        //}

    }

    IEnumerator AnimateImageFelicidades(float value, float valueMax)
    {
        Color color;
        color = imgFelicidades.color;

        while (value < valueMax)
        {
            value += (valueMax / 100) * Time.deltaTime;
            color.a += value;
            imgFelicidades.color = color;
            yield return null;
        }
    }

    IEnumerator AnimateExperience(float value, float valueMax)
    {
        //print(valueMax);
        yield return new WaitForSeconds(1);
        scoreCount.Play();

        while (value < valueMax)
        {
            value += (valueMax / 2) * Time.deltaTime;
            //value += Time.deltaTime * 50f;// porque se cambio esta linea de codigo?

            /*if (value > experience.MaxExperience)
            {
                value = experience.MaxExperience;
            }*/

            endExperience.GetComponent<Text>().text = Mathf.Floor(value).ToString(); //Mathf.RoundToInt(value).ToString();
            yield return null;
        }

        if (value > experience.MaxExperience)
        {
              value = experience.MaxExperience;
        }

        finalExperience = value;

        endExperience.GetComponent<Text>().text = Mathf.Floor(value).ToString(); //Mathf.RoundToInt(value).ToString();
        StartCoroutine(AnimateTime(0, Time.timeSinceLevelLoad));
        scoreCount.Stop();
    }


    IEnumerator AnimateTime(float value, float valueMax)
    {
        yield return new WaitForSeconds(1f);
        scoreCount.Play();

        while (value < valueMax)
        {
            value += (valueMax / 2) * Time.deltaTime;

            endTime.GetComponent<Text>().text = TimeSpan.FromSeconds(Math.Round(value)).ToString();
            yield return null;
        }

        scoreCount.Stop();

        if (exp >= (maxExp / 100 * 31))
        {
            StartCoroutine(AnimateStar1(-90, 0));
        }
        else
        {
            textNoTrophy.SetActive(true);
            trophy = "No ha ganado ningún trofeo";
            BtnEnds.SetActive(true);
        }
    }


    IEnumerator AnimateStar1(float value, float valueMax)
    {
        yield return new WaitForSeconds(0.2f);
        star.Play();

        while (value < valueMax)
        {
            value += (90 / 1.2f) * Time.deltaTime;

            star1.transform.rotation = Quaternion.AngleAxis(value, Vector3.up);
            yield return null;
        }

        if (exp >= (maxExp / 100 * 65))
        {
            StartCoroutine(AnimateStar2(-90, 0));
        }
        else
        {
            endTrophy.GetComponent<Image>().sprite = trophyBronce;
            trophy = "Bronce";
            StartCoroutine(AnimateTrophy(0, 1, BRONCE_TROPHY_TEXT));
            BtnFileDownload.SetActive(true);
        }
    }


    IEnumerator AnimateStar2(float value, float valueMax)
    {
        yield return new WaitForSeconds(0.2f);
        star.Play();

        while (value < valueMax)
        {
            value += (90 / 1.2f) * Time.deltaTime;

            star2.transform.rotation = Quaternion.AngleAxis(value, Vector3.up);
            yield return null;
        }

        if (exp >= (maxExp / 100 * 90))
        {
            StartCoroutine(AnimateStar3(-90, 0));
        }
        else
        {
            endTrophy.GetComponent<Image>().sprite = trophySilver;
            trophy = "Plata";
            StartCoroutine(AnimateTrophy(0, 1, SILVER_TROPHY_TEXT));
            BtnFileDownload.SetActive(true);
        }
    }


    IEnumerator AnimateStar3(float value, float valueMax)
    {
        yield return new WaitForSeconds(0.2f);
        star.Play();

        while (value < valueMax)
        {
            value += (90 / 1.2f) * Time.deltaTime;

            star3.transform.rotation = Quaternion.AngleAxis(value, Vector3.up);
            yield return null;
        }

        endTrophy.GetComponent<Image>().sprite = trophyGold;
        trophy = "Oro";
        StartCoroutine(AnimateTrophy(0, 1, GOLD_TROPHY_TEXT));
        BtnFileDownload.SetActive(true);

    }

    IEnumerator AnimateTrophy(float value, float valueMax, string text)
    {
        yield return new WaitForSeconds(0.2f);
        win.Play();

        while (value < valueMax)
        {
            value += (valueMax / 1.2f) * Time.deltaTime;

            endTrophy.transform.localScale = new Vector3(value, value, value);
            yield return null;
        }

        textTrophy.GetComponent<Text>().text = text;
        textNoTrophy.SetActive(false);
        
    }

    public void EndLab()
    {
        Application.ExternalCall("salir");
        Application.Quit();
    }
}