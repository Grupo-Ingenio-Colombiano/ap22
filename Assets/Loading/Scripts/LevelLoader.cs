using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    static public int sceneToload;

    private void Start()
    {
        LoadLevel(sceneToload);
    }

    public void LoadLevel(int sceneBuildIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneBuildIndex));
    }
    IEnumerator LoadAsynchronously(int sceneBuildIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneBuildIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = Mathf.RoundToInt(progress * 100f).ToString() + "% Cargando...";
            yield return null;
        }
    }
}
