using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UserData userData;
    [SerializeField] GameObject dialogSST;
    [SerializeField] VIDE_Assign vigilante;

    [SerializeField]
    VIDE_Assign videJefe;

    [SerializeField]
    VIDE_Assign inspectorSeguridad;

    [Header("-- Datos históricos")]
    [SerializeField] VIDE_Assign supervHistorico1VIDE;
    [SerializeField] VIDE_Assign supervHistorico2VIDE;
    [SerializeField] GameObject operarioHistorico1;
    [SerializeField] GameObject operarioHistorico2;
    [SerializeField] GameObject supervHistoprico2;
    [SerializeField] GameObject supervHistoprico1;

    [SerializeField] GameObject questHistorical;

    [Header("--Datos muestreo")]
    [SerializeField] GameObject questSamplingMuestreo;
    [SerializeField] GameObject supervMuestreo2;
    [SerializeField] GameObject supervMuestreo1;

    [Header("--Datos Cronometro")]
    [SerializeField] GameObject questTimignCronometro;
    [SerializeField] GameObject actividadTiming;
    [SerializeField] GameObject supervCronom1;
    [SerializeField] GameObject formTimingQuestCronometro;
    [SerializeField] GameObject timingDragActivity;
    [SerializeField] NotesManager notesManager;
    // Update is called once per frame

    private void Start()
    {
        MethodFlujo();
    }

    public void SetIndicatorLoad()
    {
        if(userData.load >= 1)
        {
            dialogSST.SetActive(true);
        }
    }

    void MethodFlujo()
    {
        if (userData.isSave == true)
        {
            if (userData.load >= 1)
            {
                videJefe.overrideStartNode = 10;
                vigilante.overrideStartNode = 3;
            }

            if (userData.load >= 2)
            {
                videJefe.overrideStartNode = 10;
                vigilante.overrideStartNode = 3;
            }
            switch (userData.method)
            {
                case 1:
                    if(userData.load == 2)
                    {
                        questHistorical.SetActive(true);
                        operarioHistorico1.SetActive(false);
                        supervHistoprico1.SetActive(false);
                        supervHistoprico2.SetActive(true);
                        operarioHistorico2.SetActive(true);
                       // notesManager.EnablePage(0);

                    }
                    break;
                case 2:
                    if (userData.load == 2)
                    {
                     
                      questSamplingMuestreo.SetActive(true);
                      supervMuestreo2.SetActive(true);
                      supervMuestreo1.SetActive(false);
                        //notesManager.EnablePage(1);

                    }
                    break;
                case 3:
                    if (userData.load == 2)
                    {
                       questTimignCronometro.SetActive(true);
                        timingDragActivity.SetActive(true);
                        //actividadTiming.SetActive(true);                                            
                        //formTimingQuestCronometro.SetActive(true);
                        //notesManager.EnablePage(2);

                    }
                    break;
                default:
                    break;
            }
        }

    }
}
