using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VP.Common.InfoWindow
{
    public class ButtonColorHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image buttonImage;
        [SerializeField] private Color selectedColor, unSelectedColor;

        private bool isSelected;

        public void SetSelectedColor()
        {
            isSelected = true;
            buttonImage.color = selectedColor;
        }
        public void SetUnSelectedColor()
        {
            isSelected = false;
            buttonImage.color = unSelectedColor;
        }

        public void OnPointerEnter(PointerEventData data)
        {
            buttonImage.color = selectedColor;
        }
        public void OnPointerExit(PointerEventData data)
        {
            if (isSelected)
            {
                buttonImage.color = selectedColor;
            }
            else
            {
                buttonImage.color = unSelectedColor;
            }
        }
    }
}
