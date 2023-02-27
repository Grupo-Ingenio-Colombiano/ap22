using UnityEngine;
using UnityEngine.UI;


public class TalkManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerDialogManager.OnTalkAvailable += HandleTalkAvailable;
        PlayerDialogManager.OnTalkNotAvailable += HandleTalkNotAvailable;
    }

    public void HandleTalkAvailable()
    {
        gameObject.GetComponent<Button>().interactable = true;
    }

    public void HandleTalkNotAvailable()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    private void OnDisable()
    {
        PlayerDialogManager.OnTalkAvailable -= HandleTalkAvailable;
        PlayerDialogManager.OnTalkNotAvailable -= HandleTalkNotAvailable;

    }
}
