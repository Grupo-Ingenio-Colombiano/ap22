using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using UnityEngine;
using UnityEngine.UI;

public class TimingRegisterCalculations : MonoBehaviour
{
    private const int factoresRitmo = 7;
    private const float numeroMuestras = 36f;

    float turnos = 1;
    float horas = 8;
    float descansos = 75;
    float numOperarios = 1;


    float numSamples;
    float[] sumatoriaTiemposFR;
    float[] tiemposNormalizados;

    float tiempoNormal;
    float tiempoCiclo;
    float tTotalDispDiario;
    float tiempoTakt;
    float unidadesProducidas;
    float unidadesRequeridas;

    //temporales por error
    /*List<float> sumatoriaTiemposFRIngresados = new List<float>();
    List<float> tiemposNormalizadosIngresados = new List<float>();
    List<float> sumatoriaTiemposFR = new List<float>();
    List<float> tiemposNormalizados = new List<float>();*/

    float[] sumatoriaTiemposFRIngresados;
    float[] tiemposNormalizadosIngresados;


    float sumTiemposCuadrado;
    float sumTiempos;

    float numSamplesIngresado;

    float tNormalIngresado;
    float tCicloIngresado;
    float tiempoTaktIngresado;
    float uProducidasIngresado;
    float uRequeridasIngresado;


    [Header("Inputs")]
    [SerializeField] InputField numSamplesInput;
    [SerializeField] InputField[] sumatoria;
    [SerializeField] InputField[] normalizados;
    [SerializeField] InputField TNormalInput;
    [SerializeField] InputField TCicloInput;
    [SerializeField] InputField TTaktInput;
    [SerializeField] InputField uProducidasInput;
    [SerializeField] InputField uRequeridasInput;

    [SerializeField] InputField justifTomadosInput;
    [SerializeField] Toggle yesNoTomados;
    [SerializeField] InputField justifSuficientesInput;
    [SerializeField] Toggle yesNoSuficientes;

    [SerializeField] InputField justifInput;
    [SerializeField] Toggle yesNo;



    [SerializeField] ValidateFields validator;
    [SerializeField] GameObject emptyMessage;

    [SerializeField] GameObject dragActivity;

    [SerializeField] ExperienceRewardManager rewardManager;

    [SerializeField] PlayerCanMove move;

    //---------------
    [Header("Correct")]
    public Text a0;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    public Text a5;
    public Text a6;
    public Text a7;
    public Text a8;
    public Text a9;
    public Text a10;
    public Text a11;
    public Text a12;
    public Text a13;
    public Text a14;
    public Text a15;
    public Text a16;
    public Text a17;
    public Text a18;
    public Text a19;

    public GameObject chulo1;
    public GameObject equis1;
    public GameObject chulo2;
    public GameObject equis2;
    public GameObject chulo3;
    public GameObject equis3;

    private void Start()
    {
        sumatoriaTiemposFR = new float[factoresRitmo];
        tiemposNormalizados = new float[factoresRitmo];
        unidadesRequeridas = QuestTiming.Instance.CurrentOperationData.requiredUnits;

        sumTiempos = 0;
        sumTiemposCuadrado = 0;
        sumatoriaTiemposFRIngresados = new float[factoresRitmo];
        tiemposNormalizadosIngresados = new float[factoresRitmo];
    }

    public void ShowCorrectAnswer()
    {
        a0.text = sumatoriaTiemposFR[0].ToString();
        a1.text = sumatoriaTiemposFR[1].ToString();
        a2.text = sumatoriaTiemposFR[2].ToString();
        a3.text = sumatoriaTiemposFR[3].ToString();
        a4.text = sumatoriaTiemposFR[4].ToString();
        a5.text = sumatoriaTiemposFR[5].ToString();
        a6.text = sumatoriaTiemposFR[6].ToString();
        a7.text = tiemposNormalizados[0].ToString();
        a8.text = tiemposNormalizados[1].ToString();
        a9.text = tiemposNormalizados[2].ToString();
        a10.text = tiemposNormalizados[3].ToString();
        a11.text = tiemposNormalizados[4].ToString();
        a12.text = tiemposNormalizados[5].ToString();
        a13.text = tiemposNormalizados[6].ToString();
        a14.text = tiempoNormal.ToString();
        a15.text = tiempoCiclo.ToString();
        a16.text = tiempoTakt.ToString();
        a17.text = unidadesProducidas.ToString();
        a18.text = unidadesRequeridas.ToString();
        a19.text = numSamples.ToString();


    }

    public void Calculate()
    {
        bool[] areCorrectAnswers = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };

        chulo1.SetActive(false);
        equis1.SetActive(false);
        chulo2.SetActive(false);
        equis2.SetActive(false);
        chulo3.SetActive(false);
        equis3.SetActive(false);

        CalculateSumFR();
        CalculateNormalizedSum();
        CalculateTiempoNormal();
        CalculateTC();

        tTotalDispDiario = ((horas * 60) - descansos) * numOperarios * turnos;
        tiempoTakt = tTotalDispDiario / unidadesRequeridas;
        unidadesProducidas = (int)(tTotalDispDiario / tiempoCiclo);

        print("Tiempo de Ciclo " + tiempoCiclo);
        print("Unidades producidas " + unidadesProducidas);
        print("Tiempo Normal " + tiempoNormal);

        float error = 0.05f;

        numSamples = 4 * ((36 * sumTiemposCuadrado) - (sumTiempos * sumTiempos)) / (error * error * (sumTiempos * sumTiempos));
        numSamples = Mathf.Ceil(numSamples);
        //print(numSamples + " samples calc");

        SetUserInputAnswers();

        for (int i = 0; i < 7; i++)
        {
            areCorrectAnswers[i] = DataChecker.IsDataCorrect(sumatoriaTiemposFRIngresados[i], sumatoriaTiemposFR[i], 0.1f, "sumatoria fr : " + i);

            if(areCorrectAnswers[i])
            {
                sumatoria[i].enabled = false;
                sumatoria[i].image.color = Color.green;
            }else
            {
                sumatoria[i].image.color = Color.red;
            }

            print(sumatoriaTiemposFRIngresados[i] + " sumatoria" + i);
        }

        for (int i = 7; i < 14; i++)
        {
            areCorrectAnswers[i] = DataChecker.IsDataCorrect(tiemposNormalizadosIngresados[i - 7], tiemposNormalizados[i - 7], 0.1f, "Tiempo suma normalizado: " + i);

            if (areCorrectAnswers[i])
            {
                normalizados[i-7].enabled = false;
                normalizados[i-7].image.color = Color.green;
            }
            else
            {
                normalizados[i-7].image.color = Color.red;
            }

            print(tiemposNormalizadosIngresados[i - 7] + " sumatoria" + i);
        }

        areCorrectAnswers[14] = DataChecker.IsDataCorrect(tNormalIngresado, tiempoNormal, 0.1f, "tiempo normal");
        if (areCorrectAnswers[14])
        {
            TNormalInput.enabled = false;
            TNormalInput.image.color = Color.green;
        }else
        {
            TNormalInput.image.color = Color.red;
        }

        areCorrectAnswers[15] = DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo ciclo");
        if (areCorrectAnswers[15])
        {
            TCicloInput.enabled = false;
            TCicloInput.image.color = Color.green;
        }else
        {
            TCicloInput.image.color = Color.red;
        }

        areCorrectAnswers[16] = DataChecker.IsDataCorrect(tiempoTaktIngresado, tiempoTakt, 0.1f, "tiempo takt");
        if (areCorrectAnswers[16])
        {
            TTaktInput.enabled = false;
            TTaktInput.image.color = Color.green;
        }else
        {
            TTaktInput.image.color = Color.red;
        }

        areCorrectAnswers[17] = DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 0.1f, "unidades producidas");
        if (areCorrectAnswers[17])
        {
            uProducidasInput.enabled = false;
            uProducidasInput.image.color = Color.green;
        }else
        {
            uProducidasInput.image.color = Color.red;
        }

        areCorrectAnswers[18] = DataChecker.IsDataCorrect(uRequeridasIngresado, unidadesRequeridas, 0.1f, "unidades requeridas");
        if (areCorrectAnswers[18])
        {
            uRequeridasInput.enabled = false;
            uRequeridasInput.image.color = Color.green;
        }else
        {
            uRequeridasInput.image.color = Color.red;
        }

        areCorrectAnswers[19] = DataChecker.IsDataCorrect(numSamplesIngresado, numSamples, 0, "numero muestras");
        if (areCorrectAnswers[19])
        {
            numSamplesInput.enabled = false;
            numSamplesInput.image.color = Color.green;
        }else
        {
            numSamplesInput.image.color = Color.red;
        }

        areCorrectAnswers[20] = yesNoTomados.isOn;
        if (areCorrectAnswers[20])
        {
            chulo1.SetActive(true);
        }else
        {
            equis1.SetActive(true);
        }

        areCorrectAnswers[21] = yesNoSuficientes.isOn;
        if (areCorrectAnswers[21])
        {
            chulo2.SetActive(true);
        }else
        {
            equis2.SetActive(true);
        }

        areCorrectAnswers[22] = !yesNo.isOn;
        if (areCorrectAnswers[22])
        {
            chulo3.SetActive(true);
        }
        else
        {
            equis3.SetActive(true);
        }


        FormResultsManager.Instance.unidadesProdPosiblesIngresadas = uProducidasIngresado;
        FormResultsManager.Instance.unidadesRequeridas = QuestTiming.Instance.CurrentOperationData.requiredUnits;
        FormResultsManager.Instance.tiempoCiclo = tCicloIngresado;
        FormResultsManager.Instance.taktTime = tiempoTaktIngresado;//tiempoTakt;

      
        //print("tTotalDispDiario " + tTotalDispDiario);
        //print("Takt time " + tiempoTakt);

        FormResultsManager.Instance.Evaluate(areCorrectAnswers, gameObject);

        FormResultsManager.Instance.taktTimeCalculadas = tiempoTakt;
        FormResultsManager.Instance.tiempoCicloCalculadas = tiempoCiclo;
        FormResultsManager.Instance.unidadesProducidasCalculadas = unidadesProducidas;
        FormResultsManager.Instance.unidadesProducidasNoCumplen = unidadesProducidas;

        bool experienceBool = false;

        for (int i = 0; i < areCorrectAnswers.Length; i++)
        {
            if (areCorrectAnswers[i])
            {
                experienceBool = true;
            }
            else
            {
                experienceBool = false;
                break;
            }
        }
        if(experienceBool)
        {
            PlayerDataManager.Instance.AddExperience(300);
        }
        ShowCorrectAnswer();

        //for (int i = 0; i < areCorrectAnswers.Length; i++)
        //{
        //    print("correct?: " + i + " " + areCorrectAnswers[i]);
        //}

    }

    private void SetUserInputAnswers()
    {

        for (int i = 0; i < sumatoria.Length; i++)
        {
            sumatoriaTiemposFRIngresados[i] = float.Parse(sumatoria[i].text);
            //print("datos ingresados: " + sumatoriaTiemposFRIngresados[i] + " " + sumatoria[i].text + " " + float.Parse(sumatoria[i].text));
        }

        for (int i = 0; i < normalizados.Length; i++)
        {
            tiemposNormalizadosIngresados[i] = float.Parse(normalizados[i].text);
            //print("datos ingresados: " + tiemposNormalizadosIngresados[i] + "  " + float.Parse(normalizados[i].text));
        }

        numSamplesIngresado = float.Parse(numSamplesInput.text);
        //print("datos ingresados: " + numSamplesIngresado + " " + numSamplesInput.text + " " + float.Parse(numSamplesInput.text));

        tNormalIngresado = float.Parse(TNormalInput.text);
        //print("datos ingresados: " + tNormalIngresado + " " + TNormalInput.text + " " + tiempoNormal);
        tCicloIngresado = float.Parse(TCicloInput.text);
        //print("datos ingresados: " + tCicloIngresado + " " + TCicloInput.text + " " + tiempoCiclo);
        tiempoTaktIngresado = float.Parse(TTaktInput.text);
        //print("datos ingresados: " + tiempoTaktIngresado + " " + TTaktInput.text + " " + tiempoTakt);
        uProducidasIngresado = float.Parse(uProducidasInput.text);
        //print("datos ingresados: " + uProducidasIngresado + " " + uProducidasInput.text + " " + unidadesProducidas);
        uRequeridasIngresado = float.Parse(uRequeridasInput.text);
        //print("datos ingresados: " + uRequeridasIngresado + " " + uRequeridasInput.text + " " + unidadesRequeridas);
    }

    void CalculateSumFR()
    {
        var currentTimeValues = QuestTiming.Instance.CurrentOperationData.historicalSamples;
        var currentFRValues = QuestTiming.Instance.CurrentOperationData.rhytmfFactors;

        sumTiempos = 0;
        sumTiemposCuadrado = 0;
        //print("campos current lenght = " +currentFRValues.Length);

        for (int i = 0; i < sumatoriaTiemposFR.Length; i++) // linea adicional para resetear tiempos a 0
        {
            sumatoriaTiemposFR[i] = 0;
        }

        for (int i = 0; i < currentFRValues.Length; i++)
        {
            //print("currentFRValue  = " + currentFRValues[i]);

            if (currentFRValues[i] == 85)
            {
                sumatoriaTiemposFR[0] = currentTimeValues[i];
                sumTiempos += currentTimeValues[i];
                sumTiemposCuadrado += (currentTimeValues[i] * currentTimeValues[i]);
                //print(sumatoriaTiemposFR[0] + " = " + currentTimeValues[i] + " fr 85");
            }

            if (currentFRValues[i] == 115)
            {
                sumatoriaTiemposFR[6] = currentTimeValues[i];
                sumTiempos += currentTimeValues[i];
                sumTiemposCuadrado += (currentTimeValues[i] * currentTimeValues[i]);
                //print(sumatoriaTiemposFR[6] + " = " + currentTimeValues[i] + " fr 115");
            }

            if (currentFRValues[i] == 90)
            {
                sumatoriaTiemposFR[1] += currentTimeValues[i];//correccion suma lista incorrecta currentFRValues[i]
                sumTiempos += currentTimeValues[i];
                sumTiemposCuadrado += (currentTimeValues[i] * currentTimeValues[i]);
                //print(sumatoriaTiemposFR[1] + " = " + currentTimeValues[i] + " fr 90");
            }

            if (currentFRValues[i] == 95)
            {
                sumatoriaTiemposFR[2] += currentTimeValues[i];//correccion suma lista incorrecta currentFRValues[i]
                sumTiempos += currentTimeValues[i];
                sumTiemposCuadrado += (currentTimeValues[i] * currentTimeValues[i]);
                //print(sumatoriaTiemposFR[2] + " = " + currentTimeValues[i] + " fr 95");
            }

            if (currentFRValues[i] == 100)
            {
                sumatoriaTiemposFR[3] += currentTimeValues[i];//correccion suma lista incorrecta currentFRValues[i]
                sumTiempos += currentTimeValues[i];
                sumTiemposCuadrado += (currentTimeValues[i] * currentTimeValues[i]);
                //print(sumatoriaTiemposFR[3] + " = " + currentTimeValues[i] + " fr 100");
            }

            if (currentFRValues[i] == 105)
            {
                sumatoriaTiemposFR[4] += currentTimeValues[i];//correccion suma lista incorrecta currentFRValues[i]
                sumTiempos += currentTimeValues[i];
                sumTiemposCuadrado += (currentTimeValues[i] * currentTimeValues[i]);
                //print(sumatoriaTiemposFR[4] + " = " + currentTimeValues[i] + " fr 105");
            }

            if (currentFRValues[i] == 110)
            {
                sumatoriaTiemposFR[5] += currentTimeValues[i];//correccion suma lista incorrecta currentFRValues[i]
                sumTiempos += currentTimeValues[i];
                sumTiemposCuadrado += (currentTimeValues[i] * currentTimeValues[i]);
                //print(sumatoriaTiemposFR[5] + " = " + currentTimeValues[i] + " fr 110");
            }

        }


    }

    void CalculateNormalizedSum()
    {

        for (int i = 0; i < factoresRitmo; i++)
        {
            var fr = ((i * 5) + 85); // correccion a fromula  sumatoriaTiemposFR[i] * ((i * 5) + 85) / 100
            tiemposNormalizados[i] = (sumatoriaTiemposFR[i] * fr) / 100f;
            //print("Sum " + fr + " = " + sumatoriaTiemposFR[i]);
            //print("tiemposNormalizados " + fr + " = " + tiemposNormalizados[i]);
        }
    }

    void CalculateTiempoNormal()
    {
        tiempoNormal = 0;

        for (int i = 0; i < tiemposNormalizados.Length; i++)
        {
            tiempoNormal += tiemposNormalizados[i];
        }

        tiempoNormal = tiempoNormal / numeroMuestras;
        //print("numero muestras = " + numeroMuestras);
        //print("tiempo normal = " + tiempoNormal);
    }

    void CalculateTC()
    {
        tiempoCiclo = tiempoNormal * (1 + (QuestTiming.Instance.CurrentOperationData.K));
        //print("tiempo ciclo  = " + tiempoCiclo);
        //print("K  = " + QuestTiming.Instance.CurrentOperationData.K);
    }

    public void Submit()
    {
        if (!validator.CheckIsEmpty())
        {
            SaveDataInFile();
            Calculate();

            HelpManager.Instance().SetHelp("Hable con el supervisor de planta");
            emptyMessage.SetActive(false);
            move.CanMove = true;
            dragActivity.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            emptyMessage.SetActive(true);
        }
    }


    void SaveDataInFile()
    {
        int currentIndex = -(rewardManager.GetCurrentAttempts() - 3);

        try
        {
            print(currentIndex + " try");

            HistoricalAnswerData.TiempoNormal[currentIndex] = TNormalInput.text;
            MethodsAnswerData.TiempoTakt[currentIndex] = TTaktInput.text;
            MethodsAnswerData.TiempoCiclo[currentIndex] = TCicloInput.text;

            print(MethodsAnswerData.TiempoCiclo[currentIndex] + " TC!!");
            MethodsAnswerData.UnidadesProducidas[currentIndex] = uProducidasInput.text;
            MethodsAnswerData.YesNo[currentIndex] = yesNo.isOn ? "Si" : "No";
            MethodsAnswerData.Justification[currentIndex] = justifInput.text;

            HistoricalAnswerData.YesNoTomados[currentIndex] = yesNoTomados.isOn ? "Si" : "No";
            HistoricalAnswerData.JustificationTomados[currentIndex] = justifTomadosInput.text;
            HistoricalAnswerData.YesNoSuficientes[currentIndex] = yesNoSuficientes.isOn ? "Si" : "No";
            HistoricalAnswerData.JustificationSuficientes[currentIndex] = justifSuficientesInput.text;

            if (currentIndex == 0)
            {
                print("1 intento");
                HistoricalAnswerData.TiempoNormalizadoIntento1[0] = normalizados[0].text;
                HistoricalAnswerData.TiempoNormalizadoIntento1[1] = normalizados[1].text;
                HistoricalAnswerData.TiempoNormalizadoIntento1[2] = normalizados[2].text;
                HistoricalAnswerData.TiempoNormalizadoIntento1[3] = normalizados[3].text;
                HistoricalAnswerData.TiempoNormalizadoIntento1[4] = normalizados[4].text;
                HistoricalAnswerData.TiempoNormalizadoIntento1[5] = normalizados[5].text;
                HistoricalAnswerData.TiempoNormalizadoIntento1[6] = normalizados[5].text;
            }

            if (currentIndex == 1)
            {
                print("2 intento");
                HistoricalAnswerData.TiempoNormalizadoIntento2[0] = normalizados[0].text;
                HistoricalAnswerData.TiempoNormalizadoIntento2[1] = normalizados[1].text;
                HistoricalAnswerData.TiempoNormalizadoIntento2[2] = normalizados[2].text;
                HistoricalAnswerData.TiempoNormalizadoIntento2[3] = normalizados[3].text;
                HistoricalAnswerData.TiempoNormalizadoIntento2[4] = normalizados[4].text;
                HistoricalAnswerData.TiempoNormalizadoIntento2[5] = normalizados[5].text;
                HistoricalAnswerData.TiempoNormalizadoIntento2[6] = normalizados[6].text;
            }

            if (currentIndex == 2)
            {
                print("3 intento");
                HistoricalAnswerData.TiempoNormalizadoIntento3[0] = normalizados[0].text;
                HistoricalAnswerData.TiempoNormalizadoIntento3[1] = normalizados[1].text;
                HistoricalAnswerData.TiempoNormalizadoIntento3[2] = normalizados[2].text;
                HistoricalAnswerData.TiempoNormalizadoIntento3[3] = normalizados[3].text;
                HistoricalAnswerData.TiempoNormalizadoIntento3[4] = normalizados[4].text;
                HistoricalAnswerData.TiempoNormalizadoIntento3[5] = normalizados[5].text;
                HistoricalAnswerData.TiempoNormalizadoIntento3[6] = normalizados[6].text;
            }
        }
        catch (System.Exception e)
        {
            print("current index: " + currentIndex);
        }

    }
    public void RellenarDatosCronometraje()
    {
        CalculateSumFR();
        CalculateNormalizedSum();
        CalculateTiempoNormal();
        CalculateTC();

        tTotalDispDiario = ((horas * 60) - descansos) * numOperarios * turnos;
        tiempoTakt = tTotalDispDiario / unidadesRequeridas;
        unidadesProducidas = (int)(tTotalDispDiario / tiempoCiclo);
        float error = 0.05f;
        numSamples = 4 * ((36 * sumTiemposCuadrado) - (sumTiempos * sumTiempos)) / (error * error * (sumTiempos * sumTiempos));
        numSamples = Mathf.Ceil(numSamples);
        for (int i = 0; i < sumatoria.Length; i++)
        {
            sumatoria[i].text = sumatoriaTiemposFR[i].ToString();
        }
        for (int i = 0; i < normalizados.Length; i++)
        {
            normalizados[i].text = tiemposNormalizados[i].ToString();
        }
        numSamplesInput.text = numSamples.ToString();
        TNormalInput.text = tiempoNormal.ToString();
        TCicloInput.text = tiempoCiclo.ToString();
        TTaktInput.text = tiempoTakt.ToString();
        uProducidasInput.text = unidadesProducidas.ToString();
        uRequeridasInput.text = unidadesRequeridas.ToString();

    }
}
