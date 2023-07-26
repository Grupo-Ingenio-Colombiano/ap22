using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SetCultureInfo : MonoBehaviour
{
    private void Awake()
    {
        CultureInfo.CurrentCulture = new CultureInfo("es-CO");
    }
    // Start is called before the first frame update
    void Start()
    {

        var culture = CultureInfo.CurrentCulture;

        Debug.Log("Active culture is: " + culture);
    }
}
