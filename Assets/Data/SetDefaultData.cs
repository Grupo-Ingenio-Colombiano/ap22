
using UnityEngine;

public class SetDefaultData : MonoBehaviour
{
    [SerializeField] UserData userData;
    void Start()
    {
        ExcelPage();
    }
    public void ExcelPage()
    {
        userData.practiceName = "Estudio de tiempos";
        userData.excelReport.Clear();
        if (userData.excelReport.Count == 0)
        {
            var excelPage = new VpSerializableData.ExcelPage();
            userData.excelReport.Add(excelPage);

        }
    }

   
}
