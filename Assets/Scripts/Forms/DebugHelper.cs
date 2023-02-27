using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHelper : MonoBehaviour
{
    public static bool IsProjectSetToTest = false;


    public void ToogleDebugMode()
    {
        IsProjectSetToTest = !IsProjectSetToTest;
    }

    public static void Printdata(string message)
    {

        if (IsProjectSetToTest)
        {
            print(message);
        }

    }
}


public class Rounder
{
    public static float RounToPlaces(float x, int decimalPlaces)
    {
        var exp = Mathf.Pow(10, decimalPlaces);
        return Mathf.Round(x * exp) / exp;
    }
}

public class DataChecker
{

    public static bool IsDataCorrect(float inputValue, float correctValue, float tolerance, string debugMessage)
    {
        if (!(inputValue >= correctValue - tolerance && inputValue <= correctValue + tolerance))
        {
            //DebugHelper.Printdata(debugMessage + " incorrecto" + ", entrada: " + inputValue + ", valor correcto" + correctValue);
            return false;
        }
        else
        {
            //DebugHelper.Printdata(debugMessage + " incorrecto" + ", entrada: " + inputValue + ", valor correcto" + correctValue);
            return true;
        }
    }
}