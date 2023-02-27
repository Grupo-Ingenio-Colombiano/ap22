using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateFields : MonoBehaviour
{

    [SerializeField] InputField[] inputsToValidate;

    public bool CheckIsEmpty()
    {
        if (DebugHelper.IsProjectSetToTest)
        {

            for (int i = 0; i < inputsToValidate.Length; i++)
            {
                if (inputsToValidate[i].text.Equals(""))
                {
                    inputsToValidate[i].text = "1";
                }
            }

            return false;
        }
        else
        {
            for (int i = 0; i < inputsToValidate.Length; i++)
            {
                if (inputsToValidate[i].text.Equals(""))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
