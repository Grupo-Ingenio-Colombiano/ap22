using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
namespace Vp_Packages
{
    public class TestingPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform panel;
        [SerializeField] private Button openButton, closeButton;

        [Header("Fps Settings")]
        [SerializeField] private Slider fpsSlider;
        [SerializeField] private TextMeshProUGUI fpsText;
        [SerializeField] private Button resetFps;

        [Header("Time Settings")]
        [SerializeField] private Slider timeSlider;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private Button resetTime;

        private bool isOpened;
        // Start is called before the first frame update
        void Start()
        {
            openButton.onClick.AddListener(OpenClose);
            closeButton.onClick.AddListener(OpenClose);


            fpsSlider.value = 60;
            fpsSlider.onValueChanged.AddListener(UpdateFps);
            resetFps.onClick.AddListener(delegate { fpsSlider.value = 60; });

            Time.timeScale = 1;
            timeSlider.onValueChanged.AddListener(UpdateTime);
            resetTime.onClick.AddListener(delegate { timeSlider.value = 1; });
        }


        private void OpenClose()
        {
            if (!isOpened)
            {
                panel.gameObject.SetActive(true);
                panel.DOAnchorPos3DX(0, 0.3f);
            }
            else
            {
                panel.DOAnchorPos3DX(-800, 0.5f).OnComplete(() => panel.gameObject.SetActive(false));
            }
            isOpened = !isOpened;
        }

        private void UpdateFps(float value)
        {
            Application.targetFrameRate = (int)value;
            fpsText.text = "FPS: " + value.ToString();
        }
        private void UpdateTime(float value)
        {
            string truncatedValue = value.ToString("F2", new System.Globalization.CultureInfo("es-CO"));
            float truncatedNumber = float.Parse(truncatedValue, new System.Globalization.CultureInfo("es-CO"));
            Time.timeScale = truncatedNumber;
            timeText.text = "Time: " + truncatedNumber + "x";
        }
    }
}