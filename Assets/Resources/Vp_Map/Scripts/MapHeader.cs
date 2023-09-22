using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapHeader : MonoBehaviour
{
    [SerializeField] private Button mapButton;
    // Start is called before the first frame update
    void Awake()
    {
        mapButton.onClick.AddListener(delegate{GameObject.FindObjectOfType<Map>(true).gameObject.SetActive(true);});
    }
}
