using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentPaint1 : MonoBehaviour
{

    public Transform posRecoje;

    public Transform posDejaMarco;

    public Transform posDejaHorquilla;

    Animator ani;

    public GameObject horquilla;

    public GameObject marco;

    NavMeshAgent nav;

    Color azulCycla;



    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        ani = GetComponent<Animator>();

        azulCycla = new Color32(78, 181, 218, 255);

        horquilla.SetActive(false);

        marco.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "pos1":
                ani.SetTrigger("get");
                StartCoroutine(go(posRecoje.position, 2f, "get", "walk"));
                horquilla.SetActive(false);
                marco.SetActive(false);
                break;

            case "pos2":
                ani.SetTrigger("get");
                StartCoroutine(go(posRecoje.position, 2f, "get", "walk"));
                horquilla.SetActive(false);
                marco.SetActive(false);
                break;

            case "pos3":
                ani.SetTrigger("idle");
                break;

            case "gancho":                
                if (other.GetComponent<RailMove>().switchObject.Equals(0))
                {
                    StartCoroutine(go(posDejaMarco.position, 2f, "get", "carry", marco, true));
                }
                else
                {
                    StartCoroutine(go(posDejaHorquilla.position, 2f, "get", "carry", horquilla, true));
                }

                break;

        }
    }



    IEnumerator go(Vector3 pos, float time, string ani1, string ani2, GameObject obj, bool value)
    {
        ani.SetTrigger(ani1);

        yield return new WaitForSeconds(time);

        nav.destination = pos;

        ani.SetTrigger(ani2);

        obj.SetActive(value);
    }

    IEnumerator go(Vector3 pos, float time, string ani1, string ani2)
    {
        ani.SetTrigger(ani1);

        yield return new WaitForSeconds(time);

        nav.destination = pos;

        ani.SetTrigger(ani2);


    }



}

