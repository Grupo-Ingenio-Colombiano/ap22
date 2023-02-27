using System.Collections;
using System.Collections.Generic;

public sealed class HelpData
{
    private static readonly HelpData instance = new HelpData();

    public string[] Data = {
        "Sume la cantidad de días que tiene cada mes. Desde Junio a Diciembre",
        "Multiplique 8 horas por 3 turnos al día",
        "Multiplique los días de funcionamiento al año por las horas trabajadas anuales",
        "Multiplique la capacidad de producción total de etanol por el consumo de caña por litro de etanol. Luego divida este valor por las horas de trabajo anuales y finalmente multipliquelo por las horas de trabajo al día",
        "Multiplique la capacidad máxima del tren por su factor de seguridad",

        "Multiplique la capacidad de carga operativa del tren cañero por la cantidad de trenes de la compañía",
        "Divida el consumo diario de caña por la cantidad de caña que transporta la flota en un día",
        "Multiplique: la cantidad de vehículos, el número de viajes y la distancia de campo de caña a la planta, tenga en cuenta la distancia tanto para la ida como para regreso",
        "Divida el recorrido total de trenes cañeros al día por el rendimiento del vehículo",
        "Multiplique el consumo de combustible por el factor de emisión",

        "Multiplique las emisiones de CO2 de trenes cañeros en un día por los días de funcionamiento de la planta en el año",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Sume los dos consumos del proceso de recepción (báscula y muestreo)",
        "Multiplique el consumo de energía por el porcentaje de consumo",

        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Sume los consumos del proceso de molienda (mesa de alimentación, motor, grúa, cuchillas, bandas y electroimán)",

        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Sume los consumos del proceso de transporte y almacenamiento (bandas y filtros banda)",
        "Divida el recorrido total sobre el rendimiento del vehículo",//[25]

        "Multiplique el factor de emisión por el consumo",
        "Multiplique los días de funcionamiento por las emisiones de CO2 al día",
        "Sume las emisiones anuales de CO2 hechas por los trenes cañeros y por la mini retrocargadora",
        "Multiplique el factor de emisión por el consumo",
        "Multiplique el factor de emisión por el consumo",//[30]

        "Sume los consumos del proceso de secado de bagazo (bandas y secador rotatorio)",
        "Se debe restar el consumo de combustible menos lo que se ahorra de combustible por utilizar el bagazo. Este valor, se debe multiplicar por el factor de emisión para obtener las emisiones anuales. Lo que se ahorra en combustible es el porcentaje de ahorro por el consumo de combustible",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Sume los consumos del proceso de clarificación (agitadores y filtros banda de lodos)",

        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Multiplique el consumo de energía por el porcentaje de consumo",
        "Sume todos los consumos eléctricos y multiplique este valor por el número de horas trabajadas anuales",

        "Multiplique el consumo de energía en el año por el factor de emisión",
        "Sume las tres emisiones obtenidas",

    };

    private HelpData() { }

    public static HelpData Instance
    {
        get
        {
            return instance;
        }
    }
}

