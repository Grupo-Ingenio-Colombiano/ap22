using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace VP.Common.InfoWindow
{
    public class InfoWindowDataSetter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI contentText;

        [SerializeField] private UIInfoWindowData uIInfoWindowData;
        [SerializeField] private ScrollRect scrollRect;

        void Awake()
        {
            contentText.text = uIInfoWindowData.content;

            scrollRect.horizontal = uIInfoWindowData.allowHorizontalScroll;
            scrollRect.vertical = uIInfoWindowData.allowVerticalScroll;
        }
    }
}
