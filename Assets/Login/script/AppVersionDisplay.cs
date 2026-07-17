using TMPro;
using UnityEngine;
public class AppVersionDisplay : MonoBehaviour
{
    TextMeshProUGUI fpsText;
    private float timer = 0f;
    private int frames = 0;
    private float fps = 0f;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform.parent);
        fpsText = GetComponent<TMPro.TextMeshProUGUI>();
        fpsText.text = Application.productName + " -" + Application.version;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        frames++;

        // Cada segundo, calculamos el FPS y lo mostramos en pantalla
        if (timer >= 1f)
        {
            fps = frames / timer;
            fpsText.text = $"{Application.productName} -{Application.version},   {fps:0.} FPS";

            // Reiniciamos el contador
            timer = 0f;
            frames = 0;
        }

    }


}
