using TMPro;
using UnityEngine;

namespace VP.Common.InfoWindow
{
    public class PrinterComponentCredits : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI labelText;
        public void Print(CreditsData.Department department)
        {
            labelText.text = "<b>" + department.name+":</b>     ";

            if (department.members.Count <= 0)
                return;

            labelText.text += department.members[0];

            if (department.members.Count <= 1)
                return;

            for (int i = 1; i < department.members.Count; i++)
            {
                labelText.text += ", " + department.members[i];
            }
        }
    }
}