using UnityEngine;

public class MainCanvas : MonoBehaviour
{

    [SerializeField] GameObject menu;

    public void OpenMenu()
    {
        menu.SetActive(true);

    }

}

