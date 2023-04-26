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
        userData.excelReport[0].E[3] = WorkPermit.userName + " " + WorkPermit.userLastName;
        userData.excelReport[0].E[5] = WorkPermit.userID;

        if(userData.method == 1 || userData.method == 2)
        {
            userData.excelReport[0].J[15] = MethodsAnswerData.TiempoTakt[0];
            userData.excelReport[0].K[15] = MethodsAnswerData.TiempoTakt[1];
            userData.excelReport[0].L[15] = MethodsAnswerData.TiempoTakt[2];
            userData.excelReport[0].J[16] = MethodsAnswerData.TiempoCiclo[0];
            userData.excelReport[0].K[16] = MethodsAnswerData.TiempoCiclo[1];
            userData.excelReport[0].L[16] = MethodsAnswerData.TiempoCiclo[2];
            userData.excelReport[0].J[17] = MethodsAnswerData.UnidadesProducidas[0];
            userData.excelReport[0].K[17] = MethodsAnswerData.UnidadesProducidas[1];
            userData.excelReport[0].L[17] = MethodsAnswerData.UnidadesProducidas[2];
            userData.excelReport[0].J[19] = MethodsAnswerData.YesNo[0];
            userData.excelReport[0].K[19] = MethodsAnswerData.YesNo[1];
            userData.excelReport[0].L[19] = MethodsAnswerData.YesNo[2];
            userData.excelReport[0].J[20] = MethodsAnswerData.Justification[0];
            userData.excelReport[0].K[20] = MethodsAnswerData.Justification[1];
            userData.excelReport[0].L[20] = MethodsAnswerData.Justification[2];
            userData.excelReport[0].J[25] = methodData.t1I1;
            userData.excelReport[0].K[25] = methodData.t1I2;
            userData.excelReport[0].L[25] = methodData.t1I3;
            userData.excelReport[0].J[26] = methodData.o1I1;
            userData.excelReport[0].K[26] = methodData.o1I2;
            userData.excelReport[0].L[26] = methodData.o1I3;
            userData.excelReport[0].J[27] = methodData.t2I1;
            userData.excelReport[0].K[27] = methodData.t2I2;
            userData.excelReport[0].L[27] = methodData.t2I3;
            userData.excelReport[0].J[28] = methodData.o2I1;
            userData.excelReport[0].K[28] = methodData.o2I2;
            userData.excelReport[0].L[28] = methodData.o2I3;
            userData.excelReport[0].J[29] = methodData.t3I1;
            userData.excelReport[0].K[29] = methodData.t3I2;
            userData.excelReport[0].L[29] = methodData.t3I3;
            userData.excelReport[0].J[30] = methodData.o3I1;
            userData.excelReport[0].K[30] = methodData.o3I2;
            userData.excelReport[0].L[30] = methodData.o3I3;
            userData.excelReport[0].J[31] = methodData.upI1;
            userData.excelReport[0].K[31] = methodData.upI2;
            userData.excelReport[0].L[31] = methodData.upI3;
            userData.excelReport[0].J[32] = methodData.obI1;
            userData.excelReport[0].K[32] = methodData.obI2;
            userData.excelReport[0].L[32] = methodData.obI3;

            userData.excelReport[0].I[36] = GameManager.scoreSecurityElements.ToString();
            userData.excelReport[0].I[37] = GameManager.scoreSelectData.ToString();
            userData.excelReport[0].I[38] = GameManager.scoreFormTCiclo.ToString();
            userData.excelReport[0].I[39] = GameManager.scoreUpgradeForm.ToString();
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