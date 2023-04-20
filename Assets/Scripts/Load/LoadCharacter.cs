using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UserData userData;
    [SerializeField] GameObject dialogSST;

    [SerializeField]
    VIDE_Assign videJefe;

    [SerializeField]
    VIDE_Assign inspectorSeguridad;

    [Header("--Dialogos datos históricos")]
    [SerializeField] VIDE_Assign supervHistorico1;
    [SerializeField] GameObject operarioHistorico1;
    [SerializeField] GameObject operarioHistorico2;
    [SerializeField] GameObject supervHistoprico2;
    [SerializeField] GameObject supervHistoprico1;

    [SerializeField] GameObject questHistorical;

    [Header("--Dialogos datos muestreo")]
    [SerializeField] VIDE_Assign supervMuestreo1;
   

    [Header("--Dialogos datos cronometro")]
    [SerializeField] VIDE_Assign supervCronometro1;

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
            }
            switch (userData.method)
            {
                case 1:
                    if(userData.load == 2)
                    {
                        operarioHistorico1.SetActive(false);
                        supervHistoprico1.SetActive(false);
                        supervHistoprico2.SetActive(true);
                        operarioHistorico2.SetActive(true);
                        questHistorical.SetActive(true);
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
