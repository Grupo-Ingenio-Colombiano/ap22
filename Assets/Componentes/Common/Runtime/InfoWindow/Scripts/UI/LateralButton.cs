using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VP.Common.InfoWindow
{
    /// <summary>
    /// se encarga de la configuracion y control del comportamiento del boton
    /// </summary>
    public class LateralButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI labelComponent;
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private Color selectedColor/*03A29D*/, unSelectedColor/*042F36*/;

        private bool isSelected;

        public void SetSelectedColor()
        {
            isSelected = true;
            image.color = selectedColor;
        }
        public void SetUnSelectedColor()
        {
            isSelected = false;
            image.color = unSelectedColor;
        }

        public void OnPointerEnter(PointerEventData data)
        {
            image.color = selectedColor;
        }
        public void OnPointerExit(PointerEventData data)
        {
            if (isSelected)
            {
                image.color = selectedColor;
            }
            else
            {
                image.color = unSelectedColor;
            }
        }

        public void Config(string label, int id, InfoWindowManager manager) 
        {
            labelComponent.text = label;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => manager.OpenPanel(id));
        }
        public void Config(string label, int id, WindowManager manager) 
        {
            labelComponent.text = label;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => manager.OpenWindow(id));
        }
    }
}
