using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeParts : MonoBehaviour {


    [SerializeField]
    GameObject biela1;

    [SerializeField]
    GameObject biela2;

    [SerializeField]
    GameObject cables;

    [SerializeField]
    GameObject cadena;

    [SerializeField]
    GameObject cambio1;

    [SerializeField]
    GameObject cambio2;

    [SerializeField]
    GameObject desviador;

    [SerializeField]
    GameObject ejeCentral;

    [SerializeField]
    GameObject ejeHorquilla;

    [SerializeField]
    GameObject ejePedales;

    [SerializeField]
    GameObject freno1;

    [SerializeField]
    GameObject freno2;

    [SerializeField]
    GameObject Horquilla;

    [SerializeField]
    GameObject ManetaFreno1;

    [SerializeField]
    GameObject ManetaFreno2;

    [SerializeField]
    GameObject Manubrio;

    [SerializeField]
    GameObject pinones;

    [SerializeField]
    GameObject plato;

    [SerializeField]
    GameObject rueda1;

    [SerializeField]
    GameObject rueda2;

    [SerializeField]
    GameObject sillin;

    [SerializeField]
    GameObject tuboSillin;

    [SerializeField]
    GameObject pedales;

    [SerializeField]
    GameObject ruedaEmpaque;

    [SerializeField]
    GameObject protecciones;

    // Use this for initialization
    void Start ()
    {
        TurnElements(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TurnElements(bool value)
    {
        biela1.SetActive(value);
        biela2.SetActive(value);
        cables.SetActive(value);
        cadena.SetActive(value);
        cambio1.SetActive(value);
        cambio2.SetActive(value);
        desviador.SetActive(value);
        ejeCentral.SetActive(value);
        ejeHorquilla.SetActive(value);
        ejePedales.SetActive(value);
        freno1.SetActive(value);
        freno2.SetActive(value);
        Horquilla.SetActive(value);
        ManetaFreno1.SetActive(value);
        ManetaFreno2.SetActive(value);
        Manubrio.SetActive(value);
        pinones.SetActive(value);
        plato.SetActive(value);
        rueda1.SetActive(value);
        rueda2.SetActive(value);
        sillin.SetActive(value);
        tuboSillin.SetActive(value);
        pedales.SetActive(value);
        ruedaEmpaque.SetActive(value);
        protecciones.SetActive(value);
    }


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(activateElement(other));

        if (other.tag.Equals("character"))
        {
            other.GetComponent<GeneralWorker>().Install();
        }        
    }

    IEnumerator activateElement(Collider other)
    {
        yield return new WaitForSeconds(0.5f);

        bool value = true;

        switch (other.name)
        {
            case "colocarProtecciones":
                protecciones.SetActive(value);
                break;

            case "colocarHorquilla":
                Horquilla.SetActive(value);
                break;

            case "colocarManubrioCana":
                Manubrio.SetActive(value);
                ejeHorquilla.SetActive(value);
                break;

            case "colocarLLanta1":
                rueda1.SetActive(value);
                break;

            case "colocarVielasYPlatos":
                biela1.SetActive(value);
                biela2.SetActive(value);
                plato.SetActive(value);
                break;

            case "colocarFrenos":
                freno1.SetActive(value);
                freno2.SetActive(value);
                break;

            case "colocarManetasCables":
                ManetaFreno1.SetActive(value);
                ManetaFreno2.SetActive(value);
                cables.SetActive(value);
                break;

            case "colocarLLanta2":
                rueda2.SetActive(value);
                break;

            case "colocarCadena":
                cadena.SetActive(value);
                break;

            case "colocarCambiosCables":
                cambio1.SetActive(value);
                cambio2.SetActive(value);
                break;

            case "colocarSillinPedalesRueda":
                sillin.SetActive(value);
                pedales.SetActive(value);
                ruedaEmpaque.SetActive(value);
                rueda1.SetActive(false);
                break;

        }

    }

    public void DisableParts()  
    {
        TurnElements(false);
    }
}
