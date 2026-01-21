using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace VP.Common.InfoWindow
{
    public class InfoWindowManager : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameObject panel;
        [SerializeField] private Button closeBtn;

        [SerializeField] private bool useInternal_btn_HUD_Open = true;
        [SerializeField] private Button btn_HUD_Open;

        [Header("Paneles")]
        [SerializeField] private GameObject[] menus;
        [SerializeField] private ButtonColorHandler[] panelButtons;
        [SerializeField] private string[] buttonsLabels;

        void Start()
        {
            if (useInternal_btn_HUD_Open)
            {
                btn_HUD_Open.onClick.AddListener(OpenPanel);
            }
            else
            {
                btn_HUD_Open.gameObject.SetActive(false);
            }

            closeBtn.onClick.RemoveAllListeners();
            closeBtn.onClick.AddListener(ClosePanel);

            for (int i = 0; i < panelButtons.Length; i++)
            {
                panelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = buttonsLabels[i];
            }
        }

        public void OpenPanel()
        {
            panel.SetActive(true);
            OpenMenu(0);
        }
        public void ClosePanel()
        {
            panel.SetActive(false);
        }

        public void OpenMenu(int index)
        {
            CloseAllMenus();

            menus[index].SetActive(true);
            panelButtons[index].SetSelectedColor();
        }

        private void CloseAllMenus()
        {
            for (int i = 0; i < menus.Length; i++)
            {
                menus[i].SetActive(false);
                panelButtons[i].SetUnSelectedColor();
            }

        }
    }
}
