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
                userData.excelReport[0].I[47] = 50.ToString();
                userData.excelReport[0].I[48] =75.ToString();
                userData.excelReport[0].I[49] = 75.ToString();
                userData.excelReport[0].I[50] = 75.ToString();
                userData.excelReport[0].I[51] = 75.ToString();
                userData.excelReport[0].I[52] = 100.ToString();

            }
            if (userData.method == 2)
            {
                userData.excelReport[0].I[45] = 30.ToString();
                userData.excelReport[0].I[46] = 20.ToString();
                userData.excelReport[0].I[47] = 87.ToString();
                userData.excelReport[0].I[48] = 87.ToString();
                userData.excelReport[0].I[49] = 87.ToString();
                userData.excelReport[0].I[50] = 89.ToString();
                userData.excelReport[0].I[51] = 100.ToString();

            }

        }
        else if (userData.method == 3) {
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

            //Tiempos
            userData.excelReport[0].G[41] = HistoricalAnswerData.TiempoNormalizadoIntento1[0];
            userData.excelReport[0].G[42] = HistoricalAnswerData.TiempoNormalizadoIntento2[0];
            userData.excelReport[0].G[43] = HistoricalAnswerData.TiempoNormalizadoIntento3[0];

            userData.excelReport[0].H[41] = HistoricalAnswerData.TiempoNormalizadoIntento1[1];
            userData.excelReport[0].H[42] = HistoricalAnswerData.TiempoNormalizadoIntento2[1];
            userData.excelReport[0].H[43] = HistoricalAnswerData.TiempoNormalizadoIntento3[1];

            userData.excelReport[0].I[41] = HistoricalAnswerData.TiempoNormalizadoIntento1[2];
            userData.excelReport[0].I[42] = HistoricalAnswerData.TiempoNormalizadoIntento2[2];
            userData.excelReport[0].I[43] = HistoricalAnswerData.TiempoNormalizadoIntento3[2];

            userData.excelReport[0].J[41] = HistoricalAnswerData.TiempoNormalizadoIntento1[3];
            userData.excelReport[0].J[42] = HistoricalAnswerData.TiempoNormalizadoIntento2[3];
            userData.excelReport[0].J[43] = HistoricalAnswerData.TiempoNormalizadoIntento3[3];

            userData.excelReport[0].K[41] = HistoricalAnswerData.TiempoNormalizadoIntento1[4];
            userData.excelReport[0].K[42] = HistoricalAnswerData.TiempoNormalizadoIntento2[4];
            userData.excelReport[0].K[43] = HistoricalAnswerData.TiempoNormalizadoIntento3[4];

            userData.excelReport[0].L[41] = HistoricalAnswerData.TiempoNormalizadoIntento1[5];
            userData.excelReport[0].L[42] = HistoricalAnswerData.TiempoNormalizadoIntento2[5];
            userData.excelReport[0].L[43] = HistoricalAnswerData.TiempoNormalizadoIntento3[5];

            userData.excelReport[0].M[41] = HistoricalAnswerData.TiempoNormalizadoIntento1[6];
            userData.excelReport[0].M[42] = HistoricalAnswerData.TiempoNormalizadoIntento2[6];
            userData.excelReport[0].M[43] = HistoricalAnswerData.TiempoNormalizadoIntento3[6];

            //Cuadros
            userData.excelReport[0].J[46] = HistoricalAnswerData.TiempoNormal[0];
            userData.excelReport[0].K[46] = HistoricalAnswerData.TiempoNormal[1];
            userData.excelReport[0].L[46] = HistoricalAnswerData.TiempoNormal[2];

            userData.excelReport[0].J[47] = MethodsAnswerData.TiempoCiclo[0];
            userData.excelReport[0].K[47] = MethodsAnswerData.TiempoCiclo[1];
            userData.excelReport[0].L[47] = MethodsAnswerData.TiempoCiclo[2];

            userData.excelReport[0].J[48] = MethodsAnswerData.TiempoTakt[0];
            userData.excelReport[0].K[48] = MethodsAnswerData.TiempoTakt[1];
            userData.excelReport[0].L[48] = MethodsAnswerData.TiempoTakt[2];

            userData.excelReport[0].J[49] = MethodsAnswerData.UnidadesProducidas[0];
            userData.excelReport[0].K[49] = MethodsAnswerData.UnidadesProducidas[1];
            userData.excelReport[0].L[49] = MethodsAnswerData.UnidadesProducidas[2];

            userData.excelReport[0].J[51] = MethodsAnswerData.YesNo[0];
            userData.excelReport[0].K[51] = MethodsAnswerData.YesNo[1];
            userData.excelReport[0].L[51] = MethodsAnswerData.YesNo[2];

            userData.excelReport[0].J[52] = HistoricalAnswerData.JustificationTomados[0];
            userData.excelReport[0].K[52] = HistoricalAnswerData.JustificationTomados[1];
            userData.excelReport[0].L[52] = HistoricalAnswerData.JustificationTomados[2];

            userData.excelReport[0].J[53] = HistoricalAnswerData.YesNoSuficientes[0];
            userData.excelReport[0].K[53] = HistoricalAnswerData.YesNoSuficientes[1];
            userData.excelReport[0].L[53] = HistoricalAnswerData.YesNoSuficientes[2];

            userData.excelReport[0].J[54] = HistoricalAnswerData.JustificationSuficientes[0];
            userData.excelReport[0].K[54] = HistoricalAnswerData.JustificationSuficientes[1];
            userData.excelReport[0].L[54] = HistoricalAnswerData.JustificationSuficientes[2];

            userData.excelReport[0].J[55] = MethodsAnswerData.YesNo[0];
            userData.excelReport[0].K[55] = MethodsAnswerData.YesNo[1];
            userData.excelReport[0].L[55] = MethodsAnswerData.YesNo[2];

            userData.excelReport[0].J[56] = MethodsAnswerData.Justification[0];
            userData.excelReport[0].K[56] = MethodsAnswerData.Justification[1];
            userData.excelReport[0].L[56] = MethodsAnswerData.Justification[2];

            //Propuesta mejora

            userData.excelReport[0].J[60] = methodData.t1I1;
            userData.excelReport[0].K[60] = methodData.t1I2;
            userData.excelReport[0].L[60] = methodData.t1I3;

            userData.excelReport[0].J[61] = methodData.t2I1;
            userData.excelReport[0].K[61] = methodData.t2I2;
            userData.excelReport[0].L[61] = methodData.t2I3;

            userData.excelReport[0].J[62] = methodData.t3I1;
            userData.excelReport[0].K[62] = methodData.t3I2;
            userData.excelReport[0].L[62] = methodData.t3I3;

            userData.excelReport[0].J[64] = methodData.upI1;
            userData.excelReport[0].K[64] = methodData.upI2;
            userData.excelReport[0].L[64] = methodData.upI3;

            userData.excelReport[0].J[65] = methodData.obI1;
            userData.excelReport[0].K[65] = methodData.obI2;
            userData.excelReport[0].L[65] = methodData.obI3;
            userData.excelReport[0].M[63] = FormResultsManager.Instance.UsersCalculate.ToString();


            userData.excelReport[0].I[69] = 50.ToString();
            userData.excelReport[0].I[70] = 50.ToString();
            userData.excelReport[0].I[71] = 300.ToString();
            userData.excelReport[0].I[72] = 100.ToString();
            userData.excelReport[0].I[73] = 500.ToString();

            userData.excelReport[0].K[69] = 50.ToString();
            userData.excelReport[0].K[70] = 50.ToString();
            userData.excelReport[0].K[71] = 300.ToString();
            userData.excelReport[0].K[72] = 100.ToString();
            userData.excelReport[0].K[73] = 500.ToString();
        }


    }
    public void DownloadData()
    {

        HistoricalDataForExcel historical = new HistoricalDataForExcel(

            WorkPermit.userName + " " + WorkPermit.userLastName,
            WorkPermit.userID,
            MethodsAnswerData.TiempoTakt[0], MethodsAnswerData.TiempoTakt[1], MethodsAnswerData.TiempoTakt[2],
            MethodsAnswerData.TiempoCiclo[0], MethodsAnswerData.TiempoCiclo[1], MethodsAnswerData.TiempoCiclo[2],
            MethodsAnswerData.UnidadesProducidas[0], MethodsAnswerData.UnidadesProducidas[1], MethodsAnswerData.UnidadesProducidas[2],
            MethodsAnswerData.YesNo[0], MethodsAnswerData.YesNo[1], MethodsAnswerData.YesNo[2],
            MethodsAnswerData.Justification[0], MethodsAnswerData.Justification[1], MethodsAnswerData.Justification[2],
            methodData.t1I1, methodData.t1I2, methodData.t1I3,
            methodData.o1I1, methodData.o1I2, methodData.o1I3,
            methodData.t2I1, methodData.t2I2, methodData.t2I3,
            methodData.o2I1, methodData.o2I2, methodData.o2I3,
            methodData.t3I1, methodData.t3I2, methodData.t3I3,
            methodData.o3I1, methodData.o3I2, methodData.o3I3,
            methodData.upI1, methodData.upI2, methodData.upI3,
            methodData.obI1, methodData.obI2, methodData.obI3,
            FinalResultsManager.instance.finalExperience.ToString("F0"), FinalResultsManager.instance.trophy,
            GameManager.scoreSecurityElements.ToString(), GameManager.scoreSelectData.ToString(),
            GameManager.scoreFormTCiclo.ToString(), GameManager.scoreUpgradeForm.ToString(),

            (GameManager.scoreSecurityElements + GameManager.scoreSelectData + GameManager.scoreFormTCiclo + GameManager.scoreUpgradeForm).ToString()

            );
       



        MuestreoDataForExcel muestreo = new MuestreoDataForExcel(
             WorkPermit.userName + " " + WorkPermit.userLastName,
            WorkPermit.userID,
          MethodsAnswerData.TiempoTakt[0], MethodsAnswerData.TiempoTakt[1], MethodsAnswerData.TiempoTakt[2],
            MethodsAnswerData.TiempoCiclo[0], MethodsAnswerData.TiempoCiclo[1], MethodsAnswerData.TiempoCiclo[2],
            MethodsAnswerData.UnidadesProducidas[0], MethodsAnswerData.UnidadesProducidas[1], MethodsAnswerData.UnidadesProducidas[2],
            MethodsAnswerData.YesNo[0], MethodsAnswerData.YesNo[1], MethodsAnswerData.YesNo[2],
            MethodsAnswerData.Justification[0], MethodsAnswerData.Justification[1], MethodsAnswerData.Justification[2],
            methodData.t1I1, methodData.t1I2, methodData.t1I3,
            methodData.o1I1, methodData.o1I2, methodData.o1I3,
            methodData.t2I1, methodData.t2I2, methodData.t2I3,
            methodData.o2I1, methodData.o2I2, methodData.o2I3,
            methodData.t3I1, methodData.t3I2, methodData.t3I3,
            methodData.o3I1, methodData.o3I2, methodData.o3I3,
            methodData.upI1, methodData.upI2, methodData.upI3,
            methodData.obI1, methodData.obI2, methodData.obI3,
            FinalResultsManager.instance.finalExperience.ToString("F0"), FinalResultsManager.instance.trophy,
             GameManager.scoreSecurityElements.ToString(), GameManager.scoreFormTCiclo.ToString(),
             GameManager.scoreUpgradeForm.ToString(),

            (GameManager.scoreSecurityElements + GameManager.scoreFormTCiclo + GameManager.scoreUpgradeForm).ToString()
          );

        CronoDataForExcel crono = new CronoDataForExcel(
           /*data campana*/

           WorkPermit.userName + " " + WorkPermit.userLastName,
            WorkPermit.userID,
          HistoricalAnswerData.campana85,
          HistoricalAnswerData.campana90[0], HistoricalAnswerData.campana90[1], HistoricalAnswerData.campana90[2], HistoricalAnswerData.campana90[3], HistoricalAnswerData.campana90[4],
          HistoricalAnswerData.campana95[0], HistoricalAnswerData.campana95[1], HistoricalAnswerData.campana95[2], HistoricalAnswerData.campana95[3], HistoricalAnswerData.campana95[4], HistoricalAnswerData.campana95[5], HistoricalAnswerData.campana95[6],
          HistoricalAnswerData.campana100[0], HistoricalAnswerData.campana100[1], HistoricalAnswerData.campana100[2], HistoricalAnswerData.campana100[3], HistoricalAnswerData.campana100[4], HistoricalAnswerData.campana100[5], HistoricalAnswerData.campana100[6], HistoricalAnswerData.campana100[7], HistoricalAnswerData.campana100[8], HistoricalAnswerData.campana100[9],
          HistoricalAnswerData.campana105[0], HistoricalAnswerData.campana105[1], HistoricalAnswerData.campana105[2], HistoricalAnswerData.campana105[3], HistoricalAnswerData.campana105[4], HistoricalAnswerData.campana105[5], HistoricalAnswerData.campana105[6],
          HistoricalAnswerData.campana110[0], HistoricalAnswerData.campana110[1], HistoricalAnswerData.campana110[2], HistoricalAnswerData.campana110[3], HistoricalAnswerData.campana110[4],
          HistoricalAnswerData.campana115,

          /*tiempos normalizados*/
          HistoricalAnswerData.TiempoNormalizadoIntento1[0], HistoricalAnswerData.TiempoNormalizadoIntento1[1], HistoricalAnswerData.TiempoNormalizadoIntento1[2], HistoricalAnswerData.TiempoNormalizadoIntento1[3], HistoricalAnswerData.TiempoNormalizadoIntento1[4], HistoricalAnswerData.TiempoNormalizadoIntento1[5], HistoricalAnswerData.TiempoNormalizadoIntento1[6], //tiempos normalizado intento 1
          HistoricalAnswerData.TiempoNormalizadoIntento2[0], HistoricalAnswerData.TiempoNormalizadoIntento2[1], HistoricalAnswerData.TiempoNormalizadoIntento2[2], HistoricalAnswerData.TiempoNormalizadoIntento2[3], HistoricalAnswerData.TiempoNormalizadoIntento2[4], HistoricalAnswerData.TiempoNormalizadoIntento2[5], HistoricalAnswerData.TiempoNormalizadoIntento2[6], //tiempos normalizado intento 2
          HistoricalAnswerData.TiempoNormalizadoIntento3[0], HistoricalAnswerData.TiempoNormalizadoIntento3[1], HistoricalAnswerData.TiempoNormalizadoIntento3[2], HistoricalAnswerData.TiempoNormalizadoIntento3[3], HistoricalAnswerData.TiempoNormalizadoIntento3[4], HistoricalAnswerData.TiempoNormalizadoIntento3[5], HistoricalAnswerData.TiempoNormalizadoIntento3[6], //tiempos normalizado intento 3

          /*cuadro de intentos */
          HistoricalAnswerData.TiempoNormal[0], HistoricalAnswerData.TiempoNormal[1], HistoricalAnswerData.TiempoNormal[2], // Tiempo normal TN
          MethodsAnswerData.TiempoCiclo[0], MethodsAnswerData.TiempoCiclo[1], MethodsAnswerData.TiempoCiclo[2], // tiempo de ciclo TC
          MethodsAnswerData.TiempoTakt[0], MethodsAnswerData.TiempoTakt[1], MethodsAnswerData.TiempoTakt[2], // tack time TT
          MethodsAnswerData.UnidadesProducidas[0], MethodsAnswerData.UnidadesProducidas[1], MethodsAnswerData.UnidadesProducidas[2], // unidades producidas UP
          HistoricalAnswerData.YesNoTomados[0], HistoricalAnswerData.YesNoTomados[1], HistoricalAnswerData.YesNoTomados[2], // ¿Los datos fueron tomados correctamente?	
          HistoricalAnswerData.JustificationTomados[0], HistoricalAnswerData.JustificationTomados[1], HistoricalAnswerData.JustificationTomados[2], //Justificación
          HistoricalAnswerData.YesNoSuficientes[0], HistoricalAnswerData.YesNoSuficientes[1], HistoricalAnswerData.YesNoSuficientes[2],//¿Los datos tomados en el conomentraje son suficientes ?
          HistoricalAnswerData.JustificationSuficientes[0], HistoricalAnswerData.JustificationSuficientes[1], HistoricalAnswerData.JustificationSuficientes[2],//Justificación
          MethodsAnswerData.YesNo[0], MethodsAnswerData.YesNo[1], MethodsAnswerData.YesNo[2],//¿Es posible cumplir con la demanda ?
          MethodsAnswerData.Justification[0], MethodsAnswerData.Justification[1], MethodsAnswerData.Justification[2],//Justificación

          /*  propuesta de mejora*/
          methodData.t1I1, methodData.t1I2, methodData.t1I3,
          methodData.o1I1, methodData.o1I2, methodData.o1I3,
          methodData.t2I1, methodData.t2I2, methodData.t2I3,
          methodData.o2I1, methodData.o2I2, methodData.o2I3,
          methodData.t3I1, methodData.t3I2, methodData.t3I3,
          methodData.o3I1, methodData.o3I2, methodData.o3I3,
          methodData.upI1, methodData.upI2, methodData.upI3,
          methodData.obI1, methodData.obI2, methodData.obI3,

          /* Experiencia*/
          FinalResultsManager.instance.finalExperience.ToString("F0"), FinalResultsManager.instance.trophy,
            GameManager.scoreSecurityElements.ToString(), GameManager.scoreTimeTake.ToString(),
            GameManager.scoreFormTCiclo.ToString(), GameManager.scoreUpgradeForm.ToString(),

            (GameManager.scoreSecurityElements + GameManager.scoreTimeTake + GameManager.scoreFormTCiclo + GameManager.scoreUpgradeForm).ToString()

           );

        


        switch (method.method)
        {
            case 1:
                GetComponent<DataSender>().SendAllData(historical);
                break;

            case 2:
                GetComponent<DataSender>().SendAllData(muestreo);
                break;

            case 3:
                GetComponent<DataSender>().SendAllData(crono);
                break;
        }





    }

}