

public class MuestreoDataForExcel
{
    public string G3; //Nombres
    public string I5; //ID

    public string J15; // Takt time-Tiempo óptimo TO (min/unidad)	resultado 1 intento	
    public string K15; // Takt time-Tiempo óptimo TO (min/unidad)	resultado 2 intento	
    public string L15; // Takt time-Tiempo óptimo TO (min/unidad)	resultado 3 intento	

    public string J16; //Tiempo de ciclo TC (min/unidad)	resultado 1 intento	
    public string K16; //Tiempo de ciclo TC (min/unidad)	resultado 2 intento	
    public string L16; //Tiempo de ciclo TC (min/unidad)	resultado 3 intento	

    public string J17; //Unidades procesadas UP (unidades) resultado 1 intento
    public string K17; //Unidades procesadas UP (unidades) resultado 2 intento
    public string L17; //Unidades procesadas UP (unidades) resultado 3 intento

    public string J19; //¿Es posible cumplir con la demanda? resultado 1 intento
    public string K19; //¿Es posible cumplir con la demanda? resultado 2 intento
    public string L19; //¿Es posible cumplir con la demanda? resultado 3 intento

    public string J20; // Justificación	1 intento
    public string K20; // Justificación	2 intento
    public string L20; // Justificación	3 intento

    public string J24; //Activación turno 1  resultado 1 intento
    public string K24; //Activación turno 2  resultado 1 intento
    public string L24; //Activación turno 3  resultado 1 intento

    public string J25; //Número de operarios turno 1  resultado 1 intento
    public string K25; //Número de operarios turno 1  resultado 2 intento
    public string L25; //Número de operarios turno 1  resultado 3 intento

    public string J26; //Activación turno 2  resultado 1 intento
    public string K26; //Activación turno 2  resultado 2 intento
    public string L26; //Activación turno 2  resultado 3 intento

    public string J27; //Número de operarios turno 2  resultado 1 intento
    public string K27; //Número de operarios turno 2  resultado 2 intento
    public string L27; //Número de operarios turno 2  resultado 3 intento

    public string J28;  //Activación turno 3  resultado 1 intento
    public string K28;  //Activación turno 3  resultado 2 intento
    public string L28;  //Activación turno 3  resultado 3 intento

    public string J29; //Número de operarios turno 3  resultado 1 intento
    public string K29; //Número de operarios turno 3  resultado 2 intento
    public string L29; //Número de operarios turno 3  resultado 3 intento

    public string J30; // Unidades producidas resultado 1 intento
    public string K30; // Unidades producidas resultado 2 intento
    public string L30; // Unidades producidas resultado 3 intento

    public string J31; // Observaciones de propuesta resultado 1 intento
    public string K31; // Observaciones de propuesta resultado 2 intento
    public string L31; // Observaciones de propuesta resultado 3 intento

    public string B35; // puntos de experiencia

    public string K37; // Trofeo 

    public string I35;
    public string I36;
    public string I37;
    public string I38;

    public MuestreoDataForExcel(string g3, string i5, string j15, string k15, string l15, string j16, string k16, string l16, string j17, string k17, string l17, string j19, string k19, string l19, string j20, string k20, string l20, string j25, string k25, string l25, string j26, string k26, string l26, string j27, string k27, string l27, string j28, string k28, string l28, string j29, string k29, string l29, string j30, string k30, string l30, string j31, string k31, string l31, string j32, string k32, string l32, string b35, string k37, string i35, string i36, string i37, string i38)
    {
        G3 = g3;
        I5 = i5;
        J15 = j15;
        K15 = k15;
        L15 = l15;
        J16 = j16;
        K16 = k16;
        L16 = l16;
        J17 = j17;
        K17 = k17;
        L17 = l17;
        J19 = j19;
        K19 = k19;
        L19 = l19;
        J20 = j20;
        K20 = k20;
        L20 = l20;
        J24 = j25;
        K24 = k25;
        L24 = l25;
        J25 = j26;
        K25 = k26;
        L25 = l26;
        J26 = j27;
        K26 = k27;
        L26 = l27;
        J27 = j28;
        K27 = k28;
        L27 = l28;
        J28 = j29;
        K28 = k29;
        L28 = l29;
        J29 = j30;
        K29 = k30;
        L29 = l30;
        J30 = j31;
        K30 = k31;
        L30 = l31;
        J31 = j32;
        K31 = k32;
        L31 = l32;
        B35 = b35;
        K37 = k37;

        I35 = i35;
        I36 = i36;

        //I37 = i37;

        if (i37 == "20")
        {
            I37 = "30";
        }
        else
        {
            I37 = i37;
        }

        if (i38 == "80")
        {
            I38 = "90";
        } else
        {
            I38 = i38;
        }
    }
}
