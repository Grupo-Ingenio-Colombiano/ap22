using UnityEngine;
using System.Collections;

public class Mapa : MonoBehaviour {

	public GameObject mapa;
	public GameObject boton_mapa;
	static public bool verificacion;
	GameObject[]  player;

    GameObject[] Ui;
    int switch_1=1;
    public GameObject indicador_accion_mapa;

    public Animator anim;


	
	void Start () {
        
        verificacion = false;
        Ui = GameObject.FindGameObjectsWithTag("UI");
	
	}

    public void openMap()
    {
        anim.SetBool("A", true);
        UiOff();
    }

    public void closeMap()
    {
        anim.SetBool("A", false);
        UiOn();
    }



    public void activar_mapa()
	{
        //indicador_accion_mapa.SetActive(false);
        switch (switch_1)
		{

		case 1:
			mapa.SetActive (true);
			boton_mapa.SetActive(true);
			switch_1=2;
			break;


		case 2:
			mapa.SetActive (false);
			boton_mapa.SetActive(false);
			switch_1=1;
                if (verificacion)
                {
                    //code.GetComponent<ap04>().estado_practica();
                    verificacion = false;
                }
			break;

		}
	}

    void UiOff()
    {
        foreach (GameObject i in Ui)
        {
            i.GetComponent<Canvas>().enabled = false;
        }
    }

    void UiOn()
    {
        foreach (GameObject i in Ui)
        {
            i.GetComponent<Canvas>().enabled = true;
        }
    }


}
