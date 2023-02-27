using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SadEscene : MonoBehaviour
{    

    [SerializeField]
    GameObject notification;

    [SerializeField]
    Camera cam;

    [SerializeField]
    Canvas failCanvas;

    [SerializeField]
    Canvas mainCanvas;

    [SerializeField]
    Canvas plotCanvas;

    [SerializeField]
    Canvas notesCanvas;

    [SerializeField]
    Canvas historicalCanvas;

    [SerializeField]
    Canvas inventory;

    [SerializeField]
    Canvas talkCanvas;

    [SerializeField]
    Image transition;

    [SerializeField]
    Image logoTransition;

    [SerializeField]
    PlayerCanMove move;

    [SerializeField]
    TextMeshProUGUI mesaggeTmpro;
    
    string mesaggeString;


    GameObject player;

    Color color = Color.white;

    private void OnEnable()
    {
        color.a = 0;
        transition.color = color;
        logoTransition.color = color;
        notification.SetActive(false);
        failCanvas.enabled = true;
        StartCoroutine(AnimTransition());
        player = GameObject.FindWithTag("Player");
        move.CanMove = false;
    }

    public void SetMesagge(string t)
    {
        mesaggeTmpro.text = t;
    }

    IEnumerator AnimTransition()
    {
        for (float i = 0; i < 1; i+= 0.02f)
        {
            color.a = i;
            transition.color = color;
            logoTransition.color = color;
            yield return null;
        }

        mainCanvas.enabled = false;
        inventory.enabled = false;
        notesCanvas.enabled = false;
        plotCanvas.enabled = false;
        talkCanvas.enabled = false;
        historicalCanvas.enabled = false;
        cam.enabled = true;
        player.GetComponent<Animator>().SetTrigger("sad");
        player.transform.LookAt(cam.transform);
        player.transform.position = new Vector3(92, 0, -73);
        notification.SetActive(true);

        yield return new WaitForSecondsRealtime(1);

        for (float i = 1; i > 0; i -= 0.02f)
        {
            color.a = i;
            transition.color = color;
            logoTransition.color = color;
            yield return null;
        }

        transition.gameObject.SetActive(false);
        SoundManager.Instance().PlayFail();
        
    }

    public void Reload()
    {
        var thisLevel = SceneManager.GetActiveScene().name;
        print("Nivel actual" + thisLevel);
        if (FindObjectOfType(typeof(LoadLevelsManager)))
        {
           var levels =  FindObjectOfType(typeof(LoadLevelsManager)) as LoadLevelsManager;
            levels.LoadLevel(thisLevel);
        }
        
        
    }
}
