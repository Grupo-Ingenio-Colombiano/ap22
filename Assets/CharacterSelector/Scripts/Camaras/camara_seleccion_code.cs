using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class camara_seleccion_code : MonoBehaviour
{
    public Animator male;
    public Animator female;
    public Collider female_collider;
    public Collider male_collider;
    public GameObject btn_volver_male;
    public GameObject btn_volver_female;
    public GameObject btn_seleccion_male;
    public GameObject btn_seleccion_female;
    public GameObject texto_male;
    public GameObject texto_female;
    AsyncOperation carga_nivel;

    //transiciones

    public GameObject trancision_in;
    public GameObject trancision_out;

    [SerializeField] Gender pGender;

    //carga
    AsyncOperation carga;
    public Slider barra;

    IEnumerator sliderdecarga()
    {
        carga = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!carga.isDone)
        {
            barra.value = carga.progress;
            yield return null;
        }
    }


    private void Awake()
    {
        trancision_in.SetActive(true);
        trancision_out.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        btn_volver_male.SetActive(false);
        btn_volver_female.SetActive(false);
        btn_seleccion_male.SetActive(false);
        btn_seleccion_female.SetActive(false);
        texto_male.SetActive(false);
        texto_female.SetActive(false);
    }

    public void apagar_female()
    {
        female.SetBool("mouse_down", false);
        female_collider.enabled = false;
        btn_volver_female.SetActive(true);
        btn_seleccion_female.SetActive(true);
        texto_female.SetActive(true);

    }

    public void encender_female()
    {
        female_collider.enabled = true;
        btn_volver_female.SetActive(false);
        btn_seleccion_female.SetActive(false);
        texto_female.SetActive(false);
    }

    public void apagar_male()
    {
        male_collider.enabled = false;
        male.SetBool("mouse_down", false);
        btn_volver_male.SetActive(true);
        btn_seleccion_male.SetActive(true);
        texto_male.SetActive(true);
    }

    public void encender_male()
    {
        male_collider.enabled = true;
        btn_volver_male.SetActive(false);
        btn_seleccion_male.SetActive(false);
        texto_male.SetActive(false);
    }

    public void volver_male()
    {
        gameObject.GetComponent<Animator>().SetBool("male", false);
        male_collider.enabled = true;

    }

    public void volver_female()
    {

        gameObject.GetComponent<Animator>().SetBool("female", false);
        female_collider.enabled = true;
    }

    public void seleccionar_male()
    {
        btn_volver_male.SetActive(false);
        male.SetBool("seleccion", true);
        pGender.playerIsMan = true;
        Invoke("activar_trancision", 3f);

        btn_seleccion_male.SetActive(false);

    }

    public void seleccionar_female()
    {
        btn_volver_female.SetActive(false);
        female.SetBool("seleccion", true);
        pGender.playerIsMan = false;

        Invoke("activar_trancision", 3f);

        btn_seleccion_female.SetActive(false);
    }



    void cargar()
    {
        StartCoroutine(sliderdecarga());
    }

    void activar_trancision()
    {
        trancision_out.SetActive(true);
        Invoke("cargar", 2f);
    }
}
