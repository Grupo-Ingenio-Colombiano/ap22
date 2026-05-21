using System;
using UnityEngine;
using TMPro;

namespace VP.Common.InfoWindow
{
    public class AutoYear : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public string pref;

        private void Start()
        {
            UpdateAndPrint();
        }
        [ContextMenu("UpdateAndPrint")]
        public void UpdateAndPrint()
        {
            text.text = pref + " " + DateTime.Now.Year.ToString();
        }
        [ContextMenu("GetTMproComponent")]
        void GetTMproComponent() { text = GetComponent<TextMeshProUGUI>(); }
    }
}