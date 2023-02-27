using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelsManager : MonoBehaviour
{

    public Slider progressBar;

    //public Color colorLogo, colorBackground;

    Color colorBackground = Color.white;

    Color colorLogo = Color.black;

    public Image logo, background;

    public GameObject canvas, backgroundLoadScene;

    float animationSpeed = 0.7f;

    //public string[] levels


    public void Start()
    {
        canvas.SetActive(false);
        LoadLevel("Introduccion");

        AudioListener.volume = 0;
    }

    public void LoadLevel(string level)
    {
        canvas.SetActive(true);
        StartCoroutine(LoadLevelSring(level));
    }


    IEnumerator LoadLevelSring(string level)
    {

        progressBar.gameObject.SetActive(false);

        float initialOpacity = 0;

        while (initialOpacity < 1)
        {
            initialOpacity += (animationSpeed * Time.deltaTime);

            colorLogo.a = initialOpacity;
            logo.color = colorLogo;

            colorBackground.a = initialOpacity;
            background.color = colorBackground;

            yield return null;
        }

        colorLogo.a = 1;
        colorBackground.a = 1;

        colorBackground.a = initialOpacity;
        background.color = colorBackground;

        progressBar.gameObject.SetActive(true);

        progressBar.value = 0;


        AsyncOperation load;
        load = SceneManager.LoadSceneAsync(level);

        while (!load.isDone)
        {
            progressBar.value = load.progress;
            yield return null;
        }


        yield return new WaitForSeconds(1f); // END LOAD

        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);

        AudioListener.volume = 1;

        backgroundLoadScene.SetActive(false);

        progressBar.gameObject.SetActive(false);

        while (initialOpacity > 0)
        {
            initialOpacity -= (animationSpeed * Time.deltaTime);

            colorLogo.a = initialOpacity;
            logo.color = colorLogo;

            colorBackground.a = initialOpacity;
            background.color = colorBackground;

            yield return null;
        }



        canvas.SetActive(false);
    }


}
