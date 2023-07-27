using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputFieldParser : MonoBehaviour
{
    public InputField field;

    private void Awake() 
    {
        field = GetComponent<InputField>();
        field.onValueChanged.AddListener(delegate{ChangeDotsForCommas();});    
    }

    public void ChangeDotsForCommas()
    {
        if(field.text.Contains("."))
        {
            Debug.Log("Contains Dot");
            field.text = field.text.Replace(".",",");
        }
    }
}
