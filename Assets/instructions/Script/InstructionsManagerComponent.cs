using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class InstructionsManagerComponent : MonoBehaviour
{
    public int LevelLoad;

     [TextArea][SerializeField]
     string defaultText;

    [TextArea]
    public string[] instructions;

    public Sprite[] images;

    int estados = 0;

    float distance;
    static public int actualInstruction = 0;

    public TMPro.TextMeshProUGUI texto;
    public TMPro.TextMeshProUGUI text_boton;
    public GameObject btn_cambio;
    public GameObject btn_cambio2;
    public GameObject btn_ingresar;
    public GameObject ImageInstructions;
    public GameObject screen1;
    public GameObject mainUi;
    public GameObject omitir;
    Color color_texto;
    float tiempo = 0f;
    public Animator camara;
    public Animator personaje;
    public GameObject navigation;
    float rotacion = 50;
    Vector3 vectorrot;

    public GameObject nextButton;
    public GameObject backButton;

    static public List<GameObject> pointsPos = new List<GameObject>();

    public GameObject sh;

    bool saltar = false;
    bool correr = false;
    bool caminar = false;
    bool girar = false;
    CultureInfo c;



    AsyncOperation carga;
    public Slider barra;


    IEnumerator sliderdecarga()
    {
        carga = SceneManager.LoadSceneAsync(LevelLoad);

        while (!carga.isDone)
        {
            barra.value = carga.progress;
            yield return null;
        }
    }

    private void Awake()
    {
        //screen1.SetActive(true);
        mainUi.SetActive(true);
    }

    void Start()
    {
        texto.text = defaultText;
        color_texto = Color.white;
        color_texto.a = 0;
        //userData.lastScene = SceneManager.GetActiveScene().buildIndex;
    }


    void Update()
    {

        ImageInstructions.GetComponent<Image>().sprite = images[actualInstruction];

        if (actualInstruction == 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }
        if (actualInstruction == instructions.Length - 1)
        {
            nextButton.SetActive(false);
            btn_cambio2.GetComponent<Animator>().SetBool("animate", true);
        }
        else
        {
            nextButton.SetActive(true);
            btn_cambio2.GetComponent<Animator>().SetBool("animate", false);
        }


        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && caminar)
        {

            personaje.SetInteger("animar", 2);
        }

        else if (((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && caminar))
        {
            personaje.SetInteger("animar", 1);
        }


        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && caminar)
        {
            personaje.SetInteger("animar", 6);
        }

        else if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && caminar)
        {
            personaje.SetInteger("animar", 1);
        }


        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && correr)
        {
            personaje.SetInteger("animar", 3);
        }

        else if ((Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) && correr)
        {
            personaje.SetInteger("animar", 1);
        }



        if (girar)
        {
            float h = Input.GetAxis("Horizontal");
            vectorrot = new Vector3(0, h, 0);
            personaje.gameObject.transform.Rotate(vectorrot * rotacion * Time.deltaTime);
        }



        if (Input.GetKeyDown(KeyCode.Space) && saltar)
        {
            personaje.SetInteger("animar", 5);
        }

        else if (Input.GetKeyUp(KeyCode.Space) && saltar)
        {
            personaje.SetInteger("animar", 1);
        }


    }

    IEnumerator dialogos(string[] actual)
    {
        foreach (string frase in actual)
        {
            StartCoroutine("opacidad_texto_mas");
            texto.text = frase;
            yield return new WaitForSeconds(3f);
            if (frase != actual[actual.Length - 1])
            {
                StartCoroutine("opacidad_texto_menos");
            }
            else
            {
                // btn_cambio.SetActive(true);

            }

            yield return new WaitForSeconds(1.3f);

        }
    }

    IEnumerator opacidad_texto_mas()
    {
        color_texto.a = 0;
        for (int i = 0; i < 20; i++)
        {
            color_texto.a += 0.05f;

            texto.color = color_texto;

            yield return new WaitForSeconds(0.05f);
        }


    }

    IEnumerator textTransition(string txt)
    {
        texto.text = txt;

        color_texto.a = 0;

        for (int i = 0; i < 20; i++)
        {
            color_texto.a += 0.05f;

            texto.color = color_texto;

            yield return new WaitForSeconds(0.05f);
        }

    }

    IEnumerator opacidad_texto_menos()
    {
        color_texto.a = 1F;
        for (int i = 0; i < 20; i++)
        {
            color_texto.a -= 0.05f;

            texto.color = color_texto;

            yield return new WaitForSeconds(0.05f);
        }
    }


    public void repetir_dialogo()
    {
        estados -= 1;
    }

    public void mostrar(GameObject objeto)
    {
        objeto.SetActive(true);
    }

    public void ocultar(GameObject objeto)
    {
        objeto.SetActive(false);
    }



    void cambio_color(Material mat)
    {
        tiempo = Mathf.PingPong(Time.time, 0.8f);
        mat.color = Color.Lerp(Color.gray, Color.yellow, tiempo);
    }

    void cargar()
    {
        StartCoroutine(sliderdecarga());
    }

    public void startNavigation()
    {
        btn_cambio.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(textTransition(defaultText));

    }

    public void entendido1()
    {
        navigation.SetActive(true);
        btn_cambio.SetActive(false);
        camara.SetInteger("animar", 1);
        StartCoroutine(textTransition(instructions[0]));
        activatePoints();
        Invoke("playAnim", 1f);
    }

    public void evalInstruction(int pos)
    {
        StartCoroutine(textTransition(instructions[pos]));
        personaje.SetInteger("animar", 7);
        ImageInstructions.GetComponent<Animation>().Play();
    }

    public void Next()
    {
        if (actualInstruction != instructions.Length - 1)
        {
            StartCoroutine(textTransition(instructions[actualInstruction + 1]));
            actualInstruction += 1;
            personaje.SetInteger("animar", 7);
            ImageInstructions.GetComponent<Animation>().Play("imageInstructions");
        }

    }

    public void Back()
    {
        if (actualInstruction != 0)
        {
            StartCoroutine(textTransition(instructions[actualInstruction - 1]));
            actualInstruction -= 1;
            personaje.SetInteger("animar", 7);
            ImageInstructions.GetComponent<Animation>().Play("imageInstructions");
        }

    }

    void activatePoints()
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            GameObject.Find("UI/dialogo/navigation/short/point" + i).SetActive(true);

            pointsPos.Add(GameObject.Find("UI/dialogo/navigation/short/point" + i));
        }

        sh.GetComponent<HorizontalLayoutGroup>().spacing = -(520 / instructions.Length);

    }

    public void loadLevels()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        LevelLoader.sceneToload = activeScene + 1;
        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
    }

    public void finishOrPass()
    {
        if (navigation.activeInHierarchy)
        {
            ImageInstructions.GetComponent<Animation>().Play("imageInstructionsrev");
        }
        StartCoroutine(textTransition("Ahora puede ingresar a la práctica\nGracias por utilizar virtual Plant, una alternativa diferente para aprender haciendo"));
        btn_cambio2.SetActive(false);
        btn_cambio.SetActive(false);
        btn_ingresar.SetActive(true);
        navigation.SetActive(false);
        omitir.SetActive(false);

    }

    void playAnim()
    {
        ImageInstructions.GetComponent<Animation>().Play();
    }


}
