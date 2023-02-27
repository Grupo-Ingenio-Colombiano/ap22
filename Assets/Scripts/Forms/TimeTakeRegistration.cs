using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTakeRegistration : MonoBehaviour
{

    [SerializeField] ValidateFields validator;
    [SerializeField] GameObject emptyMessage;

    public void Calculate() //calculos 
    {
        bool[] areCorrectAnswers = { true, true, true, true, true, true };



        //areCorrectAnswers[0] = DataChecker.IsDataCorrect(tOptimoIngresado, tiempoOptimo, 0.1f, "Tiempo optimo");
        //areCorrectAnswers[1] = DataChecker.IsDataCorrect(tCicloIngresado, tiempoCiclo, 0.1f, "tiempo Ciclo");
        //areCorrectAnswers[2] = DataChecker.IsDataCorrect(uProducidasIngresado, unidadesProducidas, 1f, "unidades Producidas");





    }

    public void Submit()
    {
        if (!validator.CheckIsEmpty())
        {
            Calculate();
        }
        else
        {
            emptyMessage.SetActive(true);
        }
    }
}
