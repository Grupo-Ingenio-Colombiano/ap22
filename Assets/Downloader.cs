using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downloader : MonoBehaviour
{
    [SerializeField]
    MethodSeleccion method;

    [SerializeField]
    MethodData methodData;

    [SerializeField] UserData userData;

    private void Start()
    {
        userData.excelReport[0].G[6] = userData.nombreForm + " " + userData.apellidoForm;
        userData.excelReport[0].G[7] = userData.email;
        userData.excelReport[0].G[8] = System.DateTime.Now.ToString("MM/dd/yyyy") + "   " + System.DateTime.Now.ToString("hh: mm:ss");

        userData.excelReport[0].F[14] = userData.experience.ToString();
        userData.excelReport[0].F[15] = userData.progress.ToString() + "%";
        userData.excelReport[0].F[16] = userData.time;
        userData.excelReport[0].F[17] = ((userData.experience / 500) * 100).ToString() + "%";


        if (userData.method == 1 || userData.method == 2)
        {
            DownloadDataHistoricOrSampling();

        }
        else if (userData.method == 3) {
            DownloadTimingData();
        }


    }
    public void DownloadDataHistoricOrSampling()
    {


        userData.excelReport[0].J[27] = MethodsAnswerData.TiempoTakt[0];
        userData.excelReport[0].K[27] = MethodsAnswerData.TiempoTakt[1];
        userData.excelReport[0].L[27] = MethodsAnswerData.TiempoTakt[2];

        userData.excelReport[0].J[28] = MethodsAnswerData.TiempoCiclo[0];
        userData.excelReport[0].K[28] = MethodsAnswerData.TiempoCiclo[1];
        userData.excelReport[0].L[28] = MethodsAnswerData.TiempoCiclo[2];

        userData.excelReport[0].J[29] = MethodsAnswerData.UnidadesProducidas[0];
        userData.excelReport[0].K[29] = MethodsAnswerData.UnidadesProducidas[1];
        userData.excelReport[0].L[29] = MethodsAnswerData.UnidadesProducidas[2];

        userData.excelReport[0].J[31] = MethodsAnswerData.YesNo[0];
        userData.excelReport[0].K[31] = MethodsAnswerData.YesNo[1];
        userData.excelReport[0].L[31] = MethodsAnswerData.YesNo[2];

        userData.excelReport[0].J[32] = MethodsAnswerData.Justification[0];
        userData.excelReport[0].K[32] = MethodsAnswerData.Justification[1];
        userData.excelReport[0].L[32] = MethodsAnswerData.Justification[2];

        userData.excelReport[0].J[36] = methodData.t1I1;
        userData.excelReport[0].K[36] = methodData.t1I2;
        userData.excelReport[0].L[36] = methodData.t1I3;

        userData.excelReport[0].J[37] = methodData.t2I1;
        userData.excelReport[0].K[37] = methodData.t2I2;
        userData.excelReport[0].L[37] = methodData.t2I3;

        userData.excelReport[0].J[38] = methodData.t3I1;
        userData.excelReport[0].K[38] = methodData.t3I2;
        userData.excelReport[0].L[38] = methodData.t3I3;

        userData.excelReport[0].M[39] = FormResultsManager.Instance.UsersCalculate.ToString();
        userData.excelReport[0].M[40] = FormResultsManager.Instance.unidadesProducidasCalculadas.ToString();

        userData.excelReport[0].J[40] = methodData.upI1;
        userData.excelReport[0].K[40] = methodData.upI2;
        userData.excelReport[0].L[40] = methodData.upI3;

        userData.excelReport[0].J[41] = methodData.obI1;
        userData.excelReport[0].K[41] = methodData.obI2;
        userData.excelReport[0].L[41] = methodData.obI3;

        if (userData.method == 1)
        {
            userData.excelReport[0].I[45] = 30.ToString();
            userData.excelReport[0].I[46] = 20.ToString();
            userData.excelReport[0].I[47] = userData.experienceSelectHistoricalData.ToString();
            userData.excelReport[0].I[48] = userData.experienceTalkTimeHistorical.ToString();
            userData.excelReport[0].I[49] = userData.experienceTiempoOptimoHistorical.ToString();
            userData.excelReport[0].I[50] = userData.experienceUnidadesrequeridasHistorical.ToString();
            userData.excelReport[0].I[51] = userData.experienceQuestionHistorical.ToString();
            userData.excelReport[0].I[52] = userData.experienceTurnOperators.ToString();

        }
        if (userData.method == 2)
        {
            userData.excelReport[0].I[45] = 30.ToString();
            userData.excelReport[0].I[46] = 20.ToString();
            userData.excelReport[0].I[47] = userData.experienceTalkTimeSample.ToString();
            userData.excelReport[0].I[48] = userData.experienceTiempoOptimoSample.ToString();
            userData.excelReport[0].I[49] = userData.experienceUnidadesrequeridasSample.ToString();
            userData.excelReport[0].I[50] = userData.experienceQuestionSample.ToString();
            userData.excelReport[0].I[51] = userData.experienceTurnOperators.ToString();
        }
    }
    void DownloadTimingData()
    {
        //Campana
        userData.excelReport[0].E[29] = HistoricalAnswerData.campana85;

        userData.excelReport[0].F[29] = HistoricalAnswerData.campana90[0];
        userData.excelReport[0].F[30] = HistoricalAnswerData.campana90[1];
        userData.excelReport[0].F[31] = HistoricalAnswerData.campana90[2];
        userData.excelReport[0].F[32] = HistoricalAnswerData.campana90[3];
        userData.excelReport[0].F[33] = HistoricalAnswerData.campana90[4];

        userData.excelReport[0].G[29] = HistoricalAnswerData.campana95[0];
        userData.excelReport[0].G[30] = HistoricalAnswerData.campana95[1];
        userData.excelReport[0].G[31] = HistoricalAnswerData.campana95[2];
        userData.excelReport[0].G[32] = HistoricalAnswerData.campana95[3];
        userData.excelReport[0].G[33] = HistoricalAnswerData.campana95[4];
        userData.excelReport[0].G[34] = HistoricalAnswerData.campana95[5];
        userData.excelReport[0].G[35] = HistoricalAnswerData.campana95[6];

        userData.excelReport[0].H[29] = HistoricalAnswerData.campana100[0];
        userData.excelReport[0].H[30] = HistoricalAnswerData.campana100[1];
        userData.excelReport[0].H[31] = HistoricalAnswerData.campana100[2];
        userData.excelReport[0].H[32] = HistoricalAnswerData.campana100[3];
        userData.excelReport[0].H[33] = HistoricalAnswerData.campana100[4];
        userData.excelReport[0].H[34] = HistoricalAnswerData.campana100[5];
        userData.excelReport[0].H[35] = HistoricalAnswerData.campana100[6];
        userData.excelReport[0].H[36] = HistoricalAnswerData.campana100[7];
        userData.excelReport[0].H[37] = HistoricalAnswerData.campana100[8];
        userData.excelReport[0].H[38] = HistoricalAnswerData.campana100[9];

        userData.excelReport[0].I[29] = HistoricalAnswerData.campana105[0];
        userData.excelReport[0].I[30] = HistoricalAnswerData.campana105[1];
        userData.excelReport[0].I[31] = HistoricalAnswerData.campana105[2];
        userData.excelReport[0].I[32] = HistoricalAnswerData.campana105[3];
        userData.excelReport[0].I[33] = HistoricalAnswerData.campana105[4];
        userData.excelReport[0].I[34] = HistoricalAnswerData.campana105[5];
        userData.excelReport[0].I[35] = HistoricalAnswerData.campana105[6];

        userData.excelReport[0].J[29] = HistoricalAnswerData.campana110[0];
        userData.excelReport[0].J[30] = HistoricalAnswerData.campana110[1];
        userData.excelReport[0].J[31] = HistoricalAnswerData.campana110[2];
        userData.excelReport[0].J[32] = HistoricalAnswerData.campana110[3];
        userData.excelReport[0].J[33] = HistoricalAnswerData.campana110[4];

        userData.excelReport[0].K[29] = HistoricalAnswerData.campana115;

        //Sumatoria
        userData.excelReport[0].G[39] = HistoricalAnswerData.SumatoriaDatosCorrecto[0];
        userData.excelReport[0].H[39] = HistoricalAnswerData.SumatoriaDatosCorrecto[1];
        userData.excelReport[0].I[39] = HistoricalAnswerData.SumatoriaDatosCorrecto[2];
        userData.excelReport[0].J[39] = HistoricalAnswerData.SumatoriaDatosCorrecto[3];
        userData.excelReport[0].K[39] = HistoricalAnswerData.SumatoriaDatosCorrecto[4];
        userData.excelReport[0].L[39] = HistoricalAnswerData.SumatoriaDatosCorrecto[5];
        userData.excelReport[0].M[39] = HistoricalAnswerData.SumatoriaDatosCorrecto[6];

        userData.excelReport[0].G[40] = HistoricalAnswerData.SumatoriaDatosIntento1[0];
        userData.excelReport[0].H[40] = HistoricalAnswerData.SumatoriaDatosIntento1[1];
        userData.excelReport[0].I[40] = HistoricalAnswerData.SumatoriaDatosIntento1[2];
        userData.excelReport[0].J[40] = HistoricalAnswerData.SumatoriaDatosIntento1[3];
        userData.excelReport[0].K[40] = HistoricalAnswerData.SumatoriaDatosIntento1[4];
        userData.excelReport[0].L[40] = HistoricalAnswerData.SumatoriaDatosIntento1[5];
        userData.excelReport[0].M[40] = HistoricalAnswerData.SumatoriaDatosIntento1[6];

        userData.excelReport[0].G[41] = HistoricalAnswerData.SumatoriaDatosIntento2[0];
        userData.excelReport[0].H[41] = HistoricalAnswerData.SumatoriaDatosIntento2[1];
        userData.excelReport[0].I[41] = HistoricalAnswerData.SumatoriaDatosIntento2[2];
        userData.excelReport[0].J[41] = HistoricalAnswerData.SumatoriaDatosIntento2[3];
        userData.excelReport[0].K[41] = HistoricalAnswerData.SumatoriaDatosIntento2[4];
        userData.excelReport[0].L[41] = HistoricalAnswerData.SumatoriaDatosIntento2[5];
        userData.excelReport[0].M[41] = HistoricalAnswerData.SumatoriaDatosIntento2[6];

        userData.excelReport[0].G[42] = HistoricalAnswerData.SumatoriaDatosIntento3[0];
        userData.excelReport[0].H[42] = HistoricalAnswerData.SumatoriaDatosIntento3[1];
        userData.excelReport[0].I[42] = HistoricalAnswerData.SumatoriaDatosIntento3[2];
        userData.excelReport[0].J[42] = HistoricalAnswerData.SumatoriaDatosIntento3[3];
        userData.excelReport[0].K[42] = HistoricalAnswerData.SumatoriaDatosIntento3[4];
        userData.excelReport[0].L[42] = HistoricalAnswerData.SumatoriaDatosIntento3[5];
        userData.excelReport[0].M[42] = HistoricalAnswerData.SumatoriaDatosIntento3[6];

        //Tiempos Normalizados
        userData.excelReport[0].G[44] = HistoricalAnswerData.TiempoNormalizadCorrecto[0];
        userData.excelReport[0].H[44] = HistoricalAnswerData.TiempoNormalizadCorrecto[1];
        userData.excelReport[0].I[44] = HistoricalAnswerData.TiempoNormalizadCorrecto[2];
        userData.excelReport[0].J[44] = HistoricalAnswerData.TiempoNormalizadCorrecto[3];
        userData.excelReport[0].K[44] = HistoricalAnswerData.TiempoNormalizadCorrecto[4];
        userData.excelReport[0].L[44] = HistoricalAnswerData.TiempoNormalizadCorrecto[5];
        userData.excelReport[0].M[44] = HistoricalAnswerData.TiempoNormalizadCorrecto[6];

        userData.excelReport[0].G[45] = HistoricalAnswerData.TiempoNormalizadoIntento1[0];
        userData.excelReport[0].H[45] = HistoricalAnswerData.TiempoNormalizadoIntento1[1];
        userData.excelReport[0].I[45] = HistoricalAnswerData.TiempoNormalizadoIntento1[2];
        userData.excelReport[0].J[45] = HistoricalAnswerData.TiempoNormalizadoIntento1[3];
        userData.excelReport[0].K[45] = HistoricalAnswerData.TiempoNormalizadoIntento1[4];
        userData.excelReport[0].L[45] = HistoricalAnswerData.TiempoNormalizadoIntento1[5];
        userData.excelReport[0].M[45] = HistoricalAnswerData.TiempoNormalizadoIntento1[6];

        userData.excelReport[0].G[46] = HistoricalAnswerData.TiempoNormalizadoIntento2[0];
        userData.excelReport[0].H[46] = HistoricalAnswerData.TiempoNormalizadoIntento2[1];
        userData.excelReport[0].I[46] = HistoricalAnswerData.TiempoNormalizadoIntento2[2];
        userData.excelReport[0].J[46] = HistoricalAnswerData.TiempoNormalizadoIntento2[3];
        userData.excelReport[0].K[46] = HistoricalAnswerData.TiempoNormalizadoIntento2[4];
        userData.excelReport[0].L[46] = HistoricalAnswerData.TiempoNormalizadoIntento2[5];
        userData.excelReport[0].M[46] = HistoricalAnswerData.TiempoNormalizadoIntento2[6];

        userData.excelReport[0].G[47] = HistoricalAnswerData.TiempoNormalizadoIntento3[0];
        userData.excelReport[0].H[47] = HistoricalAnswerData.TiempoNormalizadoIntento3[1];
        userData.excelReport[0].I[47] = HistoricalAnswerData.TiempoNormalizadoIntento3[2];
        userData.excelReport[0].J[47] = HistoricalAnswerData.TiempoNormalizadoIntento3[3];
        userData.excelReport[0].K[47] = HistoricalAnswerData.TiempoNormalizadoIntento3[4];
        userData.excelReport[0].L[47] = HistoricalAnswerData.TiempoNormalizadoIntento3[5];
        userData.excelReport[0].M[47] = HistoricalAnswerData.TiempoNormalizadoIntento3[6];

        //Cuadros
        userData.excelReport[0].J[50] = HistoricalAnswerData.TiempoNormal[0];
        userData.excelReport[0].K[50] = HistoricalAnswerData.TiempoNormal[1];
        userData.excelReport[0].L[50] = HistoricalAnswerData.TiempoNormal[2];

        userData.excelReport[0].J[51] = MethodsAnswerData.TiempoCiclo[0];
        userData.excelReport[0].K[51] = MethodsAnswerData.TiempoCiclo[1];
        userData.excelReport[0].L[51] = MethodsAnswerData.TiempoCiclo[2];

        userData.excelReport[0].J[52] = MethodsAnswerData.TiempoTakt[0];
        userData.excelReport[0].K[52] = MethodsAnswerData.TiempoTakt[1];
        userData.excelReport[0].L[52] = MethodsAnswerData.TiempoTakt[2];

        userData.excelReport[0].J[53] = MethodsAnswerData.UnidadesProducidas[0];
        userData.excelReport[0].K[53] = MethodsAnswerData.UnidadesProducidas[1];
        userData.excelReport[0].L[53] = MethodsAnswerData.UnidadesProducidas[2];

        userData.excelReport[0].J[55] = MethodsAnswerData.YesNo[0];
        userData.excelReport[0].K[55] = MethodsAnswerData.YesNo[1];
        userData.excelReport[0].L[55] = MethodsAnswerData.YesNo[2];

        userData.excelReport[0].J[56] = HistoricalAnswerData.JustificationTomados[0];
        userData.excelReport[0].K[56] = HistoricalAnswerData.JustificationTomados[1];
        userData.excelReport[0].L[56] = HistoricalAnswerData.JustificationTomados[2];

        userData.excelReport[0].J[57] = HistoricalAnswerData.YesNoSuficientes[0];
        userData.excelReport[0].K[57] = HistoricalAnswerData.YesNoSuficientes[1];
        userData.excelReport[0].L[57] = HistoricalAnswerData.YesNoSuficientes[2];

        userData.excelReport[0].J[58] = HistoricalAnswerData.JustificationSuficientes[0];
        userData.excelReport[0].K[58] = HistoricalAnswerData.JustificationSuficientes[1];
        userData.excelReport[0].L[58] = HistoricalAnswerData.JustificationSuficientes[2];

        userData.excelReport[0].J[59] = MethodsAnswerData.YesNo[0];
        userData.excelReport[0].K[59] = MethodsAnswerData.YesNo[1];
        userData.excelReport[0].L[59] = MethodsAnswerData.YesNo[2];

        userData.excelReport[0].J[60] = MethodsAnswerData.Justification[0];
        userData.excelReport[0].K[60] = MethodsAnswerData.Justification[1];
        userData.excelReport[0].L[60] = MethodsAnswerData.Justification[2];

        //Propuesta mejora

        userData.excelReport[0].J[64] = methodData.t1I1;
        userData.excelReport[0].K[64] = methodData.t1I2;
        userData.excelReport[0].L[64] = methodData.t1I3;

        userData.excelReport[0].J[65] = methodData.t2I1;
        userData.excelReport[0].K[65] = methodData.t2I2;
        userData.excelReport[0].L[65] = methodData.t2I3;

        userData.excelReport[0].J[66] = methodData.t3I1;
        userData.excelReport[0].K[66] = methodData.t3I2;
        userData.excelReport[0].L[66] = methodData.t3I3;

        userData.excelReport[0].J[67] = userData.operators[0];
        userData.excelReport[0].K[67] = userData.operators[1];
        userData.excelReport[0].L[67] = userData.operators[2];
        userData.excelReport[0].M[67] = FormResultsManager.Instance.UsersCalculate.ToString();

        userData.excelReport[0].J[68] = methodData.upI1;
        userData.excelReport[0].K[68] = methodData.upI2;
        userData.excelReport[0].L[68] = methodData.upI3;
        userData.excelReport[0].M[68] = FormResultsManager.Instance.unidadesProducidasCalculadas.ToString();

        userData.excelReport[0].J[69] = methodData.obI1;
        userData.excelReport[0].K[69] = methodData.obI2;
        userData.excelReport[0].L[69] = methodData.obI3;

        if (!userData.failPractice)
        {
            userData.excelReport[0].I[73] = 50.ToString();
            userData.excelReport[0].I[74] = 50.ToString();
            userData.excelReport[0].I[75] = 300.ToString();
            userData.excelReport[0].I[76] = 100.ToString();
            userData.excelReport[0].I[77] = 500.ToString();
        }
        else
        {
            userData.excelReport[0].I[73] = 50.ToString();
            userData.excelReport[0].I[74] = 50.ToString();
            userData.excelReport[0].I[75] = 0.ToString();
            userData.excelReport[0].I[76] = 0.ToString();
            userData.excelReport[0].I[77] = 100.ToString();
        }


        userData.excelReport[0].K[73] = 50.ToString();
        userData.excelReport[0].K[74] = 50.ToString();
        userData.excelReport[0].K[75] = 300.ToString();
        userData.excelReport[0].K[76] = 100.ToString();
        userData.excelReport[0].K[77] = 500.ToString();
    }
}