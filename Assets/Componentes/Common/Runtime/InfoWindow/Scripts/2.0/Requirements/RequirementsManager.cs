using TMPro;
using UnityEngine;


namespace VP.Common.InfoWindow
{
    public class RequirementsManager : MonoBehaviour
    {
        public bool testMobile;
        
        [SerializeField] private Transform content;
        public GameObject div_prefab;

        private void Start()
        {
            BuildCreditsData();
            Instantiate(div_prefab, content);
            BuildRequirementsData();
        }

        #region BuildCreditsData

        [Header("BuildCreditsData")]
        [SerializeField] private CreditsData creditsData;
        [SerializeField] private Transform creditsRow1, creditsRow2;
        [SerializeField] private GameObject prefab_PrinterCredit;

        public void BuildCreditsData()
        {
            //Header
            TextMeshProUGUI title = Instantiate(prefab_Title, content).GetComponentInChildren<TextMeshProUGUI>();
            title.text = "Créditos";

            title.transform.SetAsFirstSibling();

            int splitColumn = 3;
            //data

            for (int i = 0; i< creditsData.departments.Count;i++)
            {
                PrinterComponentCredits printer = Instantiate(prefab_PrinterCredit, i < splitColumn ? creditsRow1 : creditsRow2).GetComponent<PrinterComponentCredits>();
                printer.Print(creditsData.departments[i]);
            }

        }

        #endregion

        #region BuildRequirementsData

        [Header("BuildRequirementsData")]
        [SerializeField] private RequirementsData dataPC;
        [SerializeField] private RequirementsData dataMobile;


        [SerializeField] private GameObject prefab_Title;
        [SerializeField] private GameObject prefab_PrinterComponentRequire;
        [SerializeField] private GameObject prefab_HeaderRecomendado;
        [SerializeField] private GameObject prefab_HeaderMinimo;

        [SerializeField] private bool minimumColumn = true;
        [SerializeField] private bool recomendedColumn = false;
        public void BuildRequirementsData()
        {
            //Header
            TextMeshProUGUI title = Instantiate(prefab_Title, content).GetComponentInChildren<TextMeshProUGUI>();
            if (recomendedColumn) { Instantiate(prefab_HeaderRecomendado, content); }
            else { Instantiate(prefab_HeaderMinimo, content); }

            //ComponentRequire

            if (VP.WEBGL.Plugins.BrowserDeviceInfo.Device.isMobile || testMobile)
            {

                title.text = dataMobile.header;

                foreach (var item in dataMobile.components)
                {
                    PrinterComponentRequire printer = Instantiate(prefab_PrinterComponentRequire, content).GetComponent<PrinterComponentRequire>();
                    printer.Print(item, minimumColumn, recomendedColumn);
                }
            }
            else
            {
                title.text = dataPC.header;

                foreach (var item in dataPC.components)
                {
                    PrinterComponentRequire printer = Instantiate(prefab_PrinterComponentRequire, content).GetComponent<PrinterComponentRequire>();
                    printer.Print(item, minimumColumn, recomendedColumn);
                }
            }
        }

        #endregion

    }
}