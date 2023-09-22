using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsOpener : MonoBehaviour
{
    [SerializeField] private Button instructionButton;
    [SerializeField] private GameObject helpPanel;

    private void Start() 
    {
        instructionButton.onClick.AddListener(delegate{
            helpPanel.SetActive(false);
            Vp_Packages.Instructions instructions = GameObject.FindObjectOfType<Vp_Packages.Instructions>(true);

            if(instructions != null)
            {
                instructions.ShowInstructionsFirstTime();
            }
            });    
    }
    public void OpenExternalURL(string url)
    {
        Application.OpenURL(url);

    }
}
