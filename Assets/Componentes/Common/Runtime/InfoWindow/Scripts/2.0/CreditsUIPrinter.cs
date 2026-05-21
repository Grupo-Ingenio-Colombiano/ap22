using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
namespace VP.Common.InfoWindow
{
    [System.Serializable]
    public class DepartmentInfo
    {
        public string displayName;
        public Department departmentType;
        public string[] departmentMembers;
        public int row;
    }

    public enum Department
    {
        Coordinador,
        Contenido_e_investigacion,
        Diagramacion_e_ilustracion,
        Diseno_3D,
        Desarollo_y_Programacion,
        Diseno_UX
    }

    public class CreditsUIPrinter : MonoBehaviour
    {

        [SerializeField] private AppInfo appInfo;
        [SerializeField] private Transform leftRow, rightRow;
        [SerializeField] private GameObject titleTextPrefab, nameTextPrefab;

        private List<DepartmentInfo> leftRowDepartments;
        private List<DepartmentInfo> rightRowDepartments;

        void Awake()
        {
            if (appInfo == null)
            {
                Debug.LogError("Debe asignar un appinfo con los datos en CreditsUIPrinter ubicado en una de las hojas del form");
            }
            else
            {
                leftRowDepartments = new List<DepartmentInfo>();
                rightRowDepartments = new List<DepartmentInfo>();

                if (appInfo.coordinador.row == 0) leftRowDepartments.Add(appInfo.coordinador); else rightRowDepartments.Add(appInfo.coordinador);
                if (appInfo.contenido_e_investigacion.row == 0) leftRowDepartments.Add(appInfo.contenido_e_investigacion); else rightRowDepartments.Add(appInfo.contenido_e_investigacion);
                if (appInfo.diagramacion_e_ilustracion.row == 0) leftRowDepartments.Add(appInfo.diagramacion_e_ilustracion); else rightRowDepartments.Add(appInfo.diagramacion_e_ilustracion);
                if (appInfo.diseno_3D.row == 0) leftRowDepartments.Add(appInfo.diseno_3D); else rightRowDepartments.Add(appInfo.diseno_3D);
                if (appInfo.desarollo_y_Programacion.row == 0) leftRowDepartments.Add(appInfo.desarollo_y_Programacion); else rightRowDepartments.Add(appInfo.desarollo_y_Programacion);
                if (appInfo.diseno_UX.row == 0) leftRowDepartments.Add(appInfo.diseno_UX); else rightRowDepartments.Add(appInfo.diseno_UX);

                SetUpCredits(leftRowDepartments, leftRow);
                SetUpCredits(rightRowDepartments, rightRow);
            }
        }

        private void SetUpCredits(List<DepartmentInfo> departmentInfos, Transform row)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < departmentInfos.Count; i++)
            {
                TextMeshProUGUI titleText = Instantiate(titleTextPrefab, row).GetComponent<TextMeshProUGUI>();
                titleText.gameObject.SetActive(true);

                titleText.text = departmentInfos[i].displayName;

                for (int j = 0; j < departmentInfos[i].departmentMembers.Length; j++)
                {
                    TextMeshProUGUI nameText = Instantiate(nameTextPrefab, row).GetComponent<TextMeshProUGUI>();
                    nameText.gameObject.SetActive(true);

                    nameText.text = departmentInfos[i].departmentMembers[j];
                }
            }
        }
    }
}
