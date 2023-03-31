using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToURL : MonoBehaviour
{
    public string url;
    public string urlWebGL;
    //Buttons to externals URL's
    public void OpenExternalURL()
    {        
        Application.OpenURL(url);

    }
}
