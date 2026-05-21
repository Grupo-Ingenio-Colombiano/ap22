using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VP.Common.InfoWindow;

public class WindowManager : MonoBehaviour
{
    [System.Serializable]
    public class Window
    {
        public string name;
        public GameObject panel;
        public LateralButton button;
    }

    [Header("Paneles")]
    [SerializeField] private List<Window> windowsList;

    private void Start()
    {
        ConfigButtons();


        ///[David] probablemente esto sirva mas en onEnable
        int wActives = 0;
        foreach (Window window in windowsList) { if (window.panel.activeSelf) wActives++; }
        if (wActives >= 2 || wActives == 0) { OpenWindow(0); }
    }

    void ConfigButtons()
    {
        for (int i = 0; i < windowsList.Count; i++)
        {
            windowsList[i].button.Config(windowsList[i].name, i, this);
        }
    }

    public void OpenWindow(int index)
    {
        CloseAllWindows();

        windowsList[index].panel.SetActive(true);
        windowsList[index].button.SetSelectedColor();
    }

    private void CloseAllWindows()
    {
        for (int i = 0; i < windowsList.Count; i++)
        {
            windowsList[i].panel.SetActive(false);
            windowsList[i].button.SetUnSelectedColor();
        }
    }
}
