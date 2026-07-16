using UnityEngine;

public class DialogClueTrigger : MonoBehaviour
{
    public void ShowHelp(string content)
    {
        HelpManager.Instance().SetHelp(content);
    }
}
