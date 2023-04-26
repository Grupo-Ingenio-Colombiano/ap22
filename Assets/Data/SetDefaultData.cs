
using UnityEngine;

public class SetDefaultData : MonoBehaviour
{
    [SerializeField] UserData userData;
    void Start()
    {
        userData.practiceName = "Estudio de tiempos";
        if(userData.excelReport.Count == 0)
        {
            var excelPage = new VpSerializableData.ExcelPage();
            userData.excelReport.Add(excelPage);
        }
    }

   
}
