using UnityEngine;
using VIDE_Data;

public class OptionDialog : MonoBehaviour
{
    public int index;

    public void OnSelectOption()
    {
        VD.nodeData.commentIndex = index;
    }
}