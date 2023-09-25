using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json;
using DG.Tweening;
using UnityEngine.Networking;

namespace Vp_Packages
{
    public class VpTesting : MonoBehaviour
    {
        [SerializeField] private string testingWord;
        public static bool hasBeenOpened;
        public static System.Action OnTestingActivated;
        private void Start()
        {
            StartCoroutine(VpNetServices.GetExcelData("VpTestKey", (x, y, z, w) => ProcessJson(y, x)));
        }
        private void ProcessJson(string json, bool status)
        {
            if (!status)
            {
                Debug.Log("La descarga del Json ha fallado");
            }
            else
            {
                CheatContainer data = JsonConvert.DeserializeObject<CheatContainer>(json);
                testingWord = data.data[0][0];

                TMP_InputField[] inputFieldsTMPro = GameObject.FindObjectsOfType<TMP_InputField>(true);
                InputField[] inputFieldsLegacy = GameObject.FindObjectsOfType<InputField>(true);
                foreach (var input in inputFieldsTMPro)
                {
                    input.onValueChanged.AddListener(CheckIfCodeEntered);
                    CheckIfCodeEntered(input.text);
                }
                foreach (var input in inputFieldsLegacy)
                {
                    input.onValueChanged.AddListener(CheckIfCodeEntered);
                    CheckIfCodeEntered(input.text);
                }
            }
        }

        private void CheckIfCodeEntered(string content)
        {
            if (content == testingWord)
            {
                if (!hasBeenOpened)
                {
                    hasBeenOpened = true;
                    VpNewNotice.SetNotice("CODIGO INGRESADO", "Ha activado el modo de testeo, uselo con moderacion");
                    Instantiate(Resources.Load<GameObject>("VpTesting/TestingCanvas"));
                    OnTestingActivated?.Invoke();
                }
            }


        }
        private class CheatContainer
        {
            public List<List<string>> data = new List<List<string>>();
        }
    }
}
