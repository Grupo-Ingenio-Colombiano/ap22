using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccion_personajes : MonoBehaviour
{
    public static seleccion_personajes instance;

    public GameObject[] personajes;
    public GameObject[] personajesBata;
    public GameObject[] personajesItems;
    public Sprite[] personajesSpriteIcon;
    public Sprite personajeIcon;
    /*public GameObject personaje_sin_bata;
    public GameObject personaje_con_bata_Hombre;
    public GameObject personaje_con_bata_Mujer;*/
    public GameObject personaje;

    public int seleccionado;

    public bool RecorridoLibre;
    public GameObject initCam;

    // Use this for initialization
    public void Awake()
    {
        instance = this;

        seleccionado = 0;

        // Debug.Log("personaje: " + PlayerPrefs.GetInt("Character"));

        seleccionado = PlayerPrefs.GetInt("Character");

        if (RecorridoLibre)
        {
            personaje = Instantiate(personajes[seleccionado], new Vector3(-18, 0, -11), Quaternion.identity);
            initCam.SetActive(true);
        }
        else
        {
            personaje = Instantiate(personajes[seleccionado], new Vector3(0, 0, 0), Quaternion.identity);
        }

        /*if (seleccionado == 0)
        {
            personaje = Instantiate(personajes[seleccionado], new Vector3(0, 0, 0), Quaternion.identity);
            personaje_sin_bata = personajes[0];
            personaje_con_bata = personajes[1];
        }    

        if (seleccionado == 1)
        {
            personaje = Instantiate(personajes[seleccionado], new Vector3(0, 0, 0), Quaternion.identity);
            personaje_sin_bata = personajes[2];
            personaje_con_bata = personajes[3];
        }*/
        if (seleccionado == 0)
        {
            personajeIcon = personajesSpriteIcon[0];
        }
        if (seleccionado == 1)
        {
            personajeIcon = personajesSpriteIcon[1];
        }
        if (seleccionado == 2)
        {
            personajeIcon = personajesSpriteIcon[2];
        }
        if (seleccionado == 3)
        {
            personajeIcon = personajesSpriteIcon[3];
        }
        if (seleccionado == 4)
        {
            personajeIcon = personajesSpriteIcon[4];
        }
    }

}

