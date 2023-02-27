using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reloj : MonoBehaviour {

    GameObject ap04_code;   
    
    static public int vueltas_dadas=0;
    static public int vueltas_programadas= 0;
    public Animator fondo_reloj;

    // Use this for initialization
    void Start ()
    {
        ap04_code = GameObject.Find("code_ap04");
        
    }
	
	// Update is called once per frame
	void Update () {
                
    }    

    public void ocultar_reloj()
    {
        vueltas_dadas += 1;        
        if (vueltas_dadas == vueltas_programadas)
        {
            fondo_reloj.Play("fondo_reloj", -1, 0f);
            gameObject.SetActive(false);            
            //ap04_code.GetComponent<ap04>().estado_practica();          
           
        }
                   
    }
}
