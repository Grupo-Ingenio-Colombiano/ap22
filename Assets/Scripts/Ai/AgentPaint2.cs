using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentPaint2 : MonoBehaviour {

    public Transform posDeja;

    public Transform posRecojeMarco;

    public Transform posRecojeHorquilla;

    Animator ani;

    public GameObject horquilla;

    public GameObject marco;

    NavMeshAgent nav;

    Color azulCycla;

    int horquillaCount = 0;

    int marcoCount = 0;

    bool goMarco = true;

    bool goHorquilla = false;

    Vector3 initialPosMarco;

    Vector3 initialPosHorquilla;

    Vector3 finalPosMarco;

    Vector3 finalPosHorquilla;

    Quaternion initialRotMarco;

    Quaternion initialRotHorquilla;

    Quaternion finalRotMarco;

    Quaternion finalRotHorquilla;

    bool inAction = false;
        

    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        ani = GetComponent<Animator>();

        azulCycla = new Color32(78, 181, 218, 255);

        horquilla.SetActive(false);

        marco.SetActive(false);

        ani.SetTrigger("walk");

        nav.destination = posRecojeMarco.position;

        initialPosMarco = marco.transform.localPosition;

        initialRotHorquilla = horquilla.transform.localRotation;

        initialRotMarco = marco.transform.localRotation;

        initialPosHorquilla = horquilla.transform.localPosition;

        finalPosHorquilla = new Vector3(4.5f, -22.9f, -35.2f);

        finalRotHorquilla = Quaternion.Euler(113.905f, -5.083984f, 22.06799f);

        finalPosMarco  = new Vector3(45.6f, 16.9f, -25.6f);

        finalRotMarco = Quaternion.Euler(162.294f, 77.061f, 177.373f);        

    }

   

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "pos5":
                if (!inAction)
                {
                    inAction = true;
                    ani.SetTrigger("get");
                    StartCoroutine(go(posDeja.position, 2f, "get", "carry", marco, true));
                    marcoCount += 1;
                    
                    if (marcoCount > 10)
                    {
                        marcoCount = 0;
                        goMarco = false;
                        goHorquilla = true;
                    }
                }
                
                
                break;

            case "pos6":              

                if (!inAction)
                {
                    inAction = true;
                    ani.SetTrigger("get");
                    StartCoroutine(go(posDeja.position, 2f, "get", "carry", horquilla, true));
                    horquillaCount += 1;
                    
                    if (horquillaCount > 10)
                    {
                        horquillaCount = 0;
                        goMarco = true;
                        goHorquilla = false;
                    }

                }

                break;

            case "pos4":
                inAction = false;
                ani.SetTrigger("carryIdle");
                horquilla.transform.localPosition = finalPosHorquilla;
                horquilla.transform.localRotation = finalRotHorquilla;
                marco.transform.localPosition = finalPosMarco;
                marco.transform.localRotation = finalRotMarco;
                break;

            case "gancho":
                if (goMarco)
                {
                    StartCoroutine(go(posRecojeMarco.position,2f,"get","walk",marco,horquilla ,false));
                }
                else if (goHorquilla)
                {
                    StartCoroutine(go(posRecojeHorquilla.position, 2f, "get", "walk", horquilla, marco, false));
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

        horquilla.transform.localPosition = initialPosHorquilla;
        horquilla.transform.localRotation = initialRotHorquilla;
        marco.transform.localPosition = initialPosMarco;
        marco.transform.localRotation = initialRotMarco;
    }

    IEnumerator go(Vector3 pos, float time, string ani1, string ani2, GameObject obj1, GameObject obj2, bool value)
    {
        ani.SetTrigger(ani1);

        yield return new WaitForSeconds(time);

        nav.destination = pos;

        ani.SetTrigger(ani2);

        obj1.SetActive(value);

        obj2.SetActive(value);
    }

    IEnumerator go(Vector3 pos, float time, string ani1, string ani2)
    {
        ani.SetTrigger(ani1);

        yield return new WaitForSeconds(time);

        nav.destination = pos;

        ani.SetTrigger(ani2);


    }

    IEnumerator go(Vector3 pos, string ani1)
    {
        yield return null;

        nav.destination = pos;

        ani.SetTrigger(ani1);


    }

    IEnumerator makeAndIdle(string ani1, string ani2, float time)
    {
        ani.SetTrigger(ani1);

        yield return new WaitForSeconds(time);        

        ani.SetTrigger(ani2);

    }
}
