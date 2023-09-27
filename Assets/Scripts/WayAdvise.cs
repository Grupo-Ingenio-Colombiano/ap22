using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayAdvise : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI timeText;
    bool onWay = true;
    bool message;
    public GameObject panelWay;

    public GameObject panelTimer;
    public float timer = 5;

    [SerializeField] PlayerExperience experience;
    [SerializeField] BoxCollider firstLimit;
    [SerializeField] GameObject box;
    private void Start()
    {
         
    }
    private void FixedUpdate()
    {
        if (!onWay)
        {
            timer -= Time.deltaTime;

            timeText.text = timer.ToString("F2");

            if (timer <= 3.5f && timer > 2)
            {
                timeText.color = Color.yellow;
            }
            else if (timer <= 2f)
            {
                timeText.color = Color.red;
            }

            if (timer <= 0)
            {
                timer = 0;


                onWay = true;
                panelTimer.SetActive(false);
                //panelWay.SetActive(true);
                VpNewNotice.SetNotice("Tránsito peatonal prohibido","Usted transitó por una zona prohibida para peatones, se le descontarán 25 puntos de experiencia. Por favor regrese al camino peatonal",NoticeCallback);
            }
        }
    }   

    void NoticeCallback(Button button)
    {
        button.onClick.RemoveAllListeners();
        
        button.onClick.AddListener( () => 
        {            
            experience.AddExperience(-25);
             
        });
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Limit")
        {
         

            panelTimer.SetActive(true);

            timer = 5;
            timeText.color = Color.black;

            onWay = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Limit")
        {
            Debug.Log("Alerta salgase de esta zona");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Limit")
        {
            onWay = true;

            panelTimer.SetActive(false);
            panelWay.SetActive(false);
        }
    }
}
