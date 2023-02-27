using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BikeWorker1 : MonoBehaviour {

    

    Animator ani;

    public GameObject obj;    

    NavMeshAgent nav;

    public Transform putPoint;

    public Transform getPoint;

    Vector3 initialPos;

    Vector3 finalPos;

    Quaternion initialRot;

    Quaternion finalRot;


    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        ani = GetComponent<Animator>();       

        ani.SetTrigger("walk");

        nav.destination = getPoint.position;

        obj.SetActive(false);

        initialRot = obj.transform.localRotation;

        initialPos = obj.transform.localPosition;

        finalPos= new Vector3(2.2f, 23.8f, -65.4f);

        finalRot = Quaternion.Euler(-16.031f, 13.248f, -15.403f);

    }

   

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "get":
                StartCoroutine(go(putPoint.position, 2f, "get", "carry", obj, true));
                obj.transform.localPosition = initialPos;
                obj.transform.localRotation = initialRot;
                break;

            case "put":
                ani.SetTrigger("carryIdle");
                obj.transform.localPosition = finalPos;
                obj.transform.localRotation = finalRot;
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

    public void install()
    {
        //obj.SetActive(false);
        StartCoroutine(go(getPoint.position, 1f, "deliver", "walk", obj, false));
    }
    
}
