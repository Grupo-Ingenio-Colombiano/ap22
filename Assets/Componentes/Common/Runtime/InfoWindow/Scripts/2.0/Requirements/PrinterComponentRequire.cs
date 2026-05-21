using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VP.Common.InfoWindow
{
    public class PrinterComponentRequire : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI minimumText;
        [SerializeField] private TextMeshProUGUI recommendedText;

        [SerializeField] private Button butonWarning;
        [SerializeField] private GameObject nota;
        [SerializeField] private TextMeshProUGUI notaText;

        public void Print(RequirementsData.Component component, bool showMinimumText, bool showRecommendedText)
        {
            nameText.text = component.name;

            if (showMinimumText && showRecommendedText)
            {
                minimumText.text = component.minimum;
                recommendedText.text = component.recommended;
            }
            else if (showMinimumText)
            {
                minimumText.text = component.minimum;

                minimumText.rectTransform.anchorMin = new Vector2(0.2f, 0f);
                minimumText.rectTransform.anchorMax = new Vector2(1f, 1f);
                minimumText.rectTransform.rect.Set(0f, 0f, 0f, 0f);

                recommendedText.gameObject.SetActive(false);
            }
            else if (showRecommendedText)
            {
                recommendedText.text = component.recommended;

                recommendedText.rectTransform.anchorMin = new Vector2(0.2f, 0f);
                recommendedText.rectTransform.anchorMax = new Vector2(1f, 1f);
                recommendedText.rectTransform.rect.Set(0f, 0f, 0f, 0f);

                minimumText.gameObject.SetActive(false);
            }
            
            nota.SetActive(false);
            if (component.warningNotes != "")
            {
                notaText.text = component.warningNotes;
                nameText.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
                nameText.GetComponent<RectTransform>().anchorMax = new Vector2(0.165f, 1f);
                nameText.GetComponent<RectTransform>().rect.Set(0f, 0f, 0f, 0f);

                butonWarning.gameObject.SetActive(true);
                butonWarning.onClick.RemoveAllListeners();
                butonWarning.onClick.AddListener(SetActiveWarningNote);
            }
            else
            {
                butonWarning.gameObject.SetActive(false);
            }

            //[Todo][David Baquero] hace falta calcular el alto de la caja en textos grandes
        }

        void SetActiveWarningNote()
        {
            nota.SetActive(nota.activeSelf ? false : true);
        }
    }
}