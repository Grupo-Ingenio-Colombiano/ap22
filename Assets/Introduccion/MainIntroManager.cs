using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainIntroManager : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;

    public void GotToSeleccion()
    {
        var levels = FindObjectOfType(typeof(LoadLevelsManager)) as LoadLevelsManager;

        levels.LoadLevel(sceneNameToLoad);

    }
}
