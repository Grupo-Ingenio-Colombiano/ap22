using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppVersionDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform.parent);
        GetComponent<TMPro.TextMeshProUGUI>().text = Application.productName + " -" + Application.version;
    }

    
}
