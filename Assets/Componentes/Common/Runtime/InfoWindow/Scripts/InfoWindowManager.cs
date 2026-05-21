using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace VP.Common.InfoWindow
{
    /// <summary>
    /// se encarga de la administracion de los paneles
    /// y brinda herramientas para construir nuevas ventanas [ en desarrollo ]
    /// [David Baquero]
    /// </summary>
    public class InfoWindowManager : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameObject panel;
        [SerializeField] private Button closeBtn;

        [SerializeField] private bool useInternal_btn_HUD_Open = true;
        [SerializeField] private Button btn_HUD_Open;

        [System.Serializable]
        public class Window
        {
            public string name;
            public GameObject panel;
            public LateralButton button;
        }

        [Header("Paneles")]
        [SerializeField] private List<Window> panelList;

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

            ConfigButtons();
        }

        #region Lista Contenidos
        /// <summary>
        /// [David] seria bueno separarlo en el futuro en su proia ventana, script
        /// </summary>


        void ConfigButtons()
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].button.Config(panelList[i].name, i, this);
            }
        }

        public void OpenPanel()
        {
            panel.SetActive(true);
            OpenPanel(0);
        }
        public void ClosePanel()
        {
            panel.SetActive(false);
        }

        public void OpenPanel(int index)
        {
            CloseAllMenus();

            panelList[index].panel.SetActive(true);
            panelList[index].button.SetSelectedColor();
        }

        private void CloseAllMenus()
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].panel.SetActive(false);
                panelList[i].button.SetUnSelectedColor();
            }
        }


        #endregion
        #region EditorTools

        /// <summary>
        /// [David] en desarrollo
        /// </summary>

        //[Header("EditorTools Config (in dev)")]
        //[SerializeField] string nameNewWindow;
        //[SerializeField] GameObject panelPrefab;
        //[SerializeField] GameObject buttonPrefab;

        //[SerializeField] Transform panelsContent;
        //[SerializeField] Transform buttonsContent;

        //[ContextMenu("CreateNewWindow")]
        //void CreateNewWindow()
        //{
        //    Window window = new Window();

        //}

        #endregion
    }
}
