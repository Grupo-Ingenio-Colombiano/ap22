using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int scoreSecurityElements = 30;
    public static int scoreTimeTake = 30;
    public static int scoreSelectData = 30;
    public static int scoreFormTCiclo = 30;
    public static int scoreUpgradeForm = 30;


    [SerializeField]
    GameObject plantBossFirstInteraccion;


    [SerializeField]
    UserData userData;

    private void Start()
    {
        userData.lastScene = SceneManager.GetActiveScene().buildIndex;
        
        if (userData.load >= 1)
        {
          
            EnableSecurityNPC();
            disablePlantBossFirstInteraccion();
            scoreSecurityElements = userData.scoreSecurityElements;
            scoreTimeTake = userData.scoreTimeTake; 
            scoreSelectData = userData.scoreSelectData;
            scoreFormTCiclo = userData.scoreFormTCiclo;
            scoreUpgradeForm = userData.scoreUpgradeForm;

        }
        if (userData.load == 1)
        {
            enableSSGTdialog1();
         
        }
    }
    public void enablePlantBossFirstInteraccion()
    {
        plantBossFirstInteraccion.SetActive(true);
    }

    public void disablePlantBossFirstInteraccion()
    {
        plantBossFirstInteraccion.SetActive(false);
    }

    [SerializeField]
    GameObject methodSelection;

    public void enableMethodSelection()
    {
        methodSelection.SetActive(true);
    }

    public void disableMethodSelection()
    {
        methodSelection.SetActive(false);
    }

    [SerializeField]
    GameObject SSGTdialog1;

    public void enableSSGTdialog1()
    {
        SSGTdialog1.SetActive(true);
    }

    public void disableSSGTdialog1()
    {
        SSGTdialog1.SetActive(false);
    }

    [SerializeField]
    GameObject prizeC;

    public void enablePrizeC()
    {
        prizeC.SetActive(true);
    }

    public void disablePrizeC()
    {
        prizeC.SetActive(false);
    }


    [SerializeField] GameObject securityNPC;


    public void EnableSecurityNPC()
    {
        securityNPC.SetActive(true);

        HelpManager.Instance().SetHelp("Hable con el inspector de SST, para obtener los EPP para ingreso a planta");
    }
}
