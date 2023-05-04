using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject qualityPanel;

    [SerializeField] GameObject creditsPanel;

    [SerializeField] GameObject restartPanel;

    [SerializeField] GameObject quitPanel;

    [SerializeField] GameObject soundPanel;

    [SerializeField] GameObject instructionsPanel;


    [SerializeField] private GameObject endResults;

    public void SelectQuality()
    {
        qualityPanel.SetActive(true);
        creditsPanel.SetActive(false);
        restartPanel.SetActive(false);
        quitPanel.SetActive(false);
        soundPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }

    public void SelectInstructions()
    {
        qualityPanel.SetActive(false);
        creditsPanel.SetActive(false);
        restartPanel.SetActive(false);
        quitPanel.SetActive(false);
        soundPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void SelectCredits()
    {
        qualityPanel.SetActive(false);
        creditsPanel.SetActive(true);
        restartPanel.SetActive(false);
        quitPanel.SetActive(false);
        soundPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }

    public void SelectRestart()
    {
        qualityPanel.SetActive(false);
        creditsPanel.SetActive(false);
        restartPanel.SetActive(true);
        quitPanel.SetActive(false);
        soundPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }

    public void SelectSound()
    {
        qualityPanel.SetActive(false);
        creditsPanel.SetActive(false);
        restartPanel.SetActive(false);
        soundPanel.SetActive(true);
        quitPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }

    public void SelectQuit()
    {
        qualityPanel.SetActive(false);
        creditsPanel.SetActive(false);
        restartPanel.SetActive(false);
        soundPanel.SetActive(false);
        quitPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void Close()
    {
        qualityPanel.SetActive(true);
        creditsPanel.SetActive(false);
        restartPanel.SetActive(false);
        quitPanel.SetActive(false);
        soundPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        HideMenu();

    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        VpNewNotice.SetNotice("Salir", "Para salir, por favor cierre la pestaña del navegador");
    }

}