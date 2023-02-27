using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMenuControl : MonoBehaviour
{
    [SerializeField]
    RectTransform panelTest;

    [SerializeField]
    GameObject OpenBtn, closeBtn;

    private void Awake()
    {
        closeBtn.SetActive(false);

        if (Debug.isDebugBuild)
        {
            OpenBtn.SetActive(true);
        }
    }

    public void Open()
    {
        //StartCoroutine(OpenAnimation());
        panelTest.gameObject.SetActive(true);
        OpenBtn.SetActive(false);
        closeBtn.SetActive(true);
    }

    public void Close()
    {
        //StartCoroutine(CloseAnimation());
        panelTest.gameObject.SetActive(false);
        closeBtn.SetActive(false);
        OpenBtn.SetActive(true);
    }

    IEnumerator OpenAnimation()
    {
        var i = 0f;
        while (i <= 1)
        {
            panelTest.localScale = new Vector3(i, 1, 1);
            i += 0.1f;
            yield return null;
        }
        panelTest.localScale = new Vector3(1, 1, 1);
        closeBtn.SetActive(true);
    }

    IEnumerator CloseAnimation()
    {
        var i = 1f;
        while (i > 0)
        {
            panelTest.localScale = new Vector3(i, 1, 1);
            i -= 0.1f;
            yield return null;
        }
        panelTest.localScale = new Vector3(0, 1, 1);
        OpenBtn.SetActive(true);
    }

}
