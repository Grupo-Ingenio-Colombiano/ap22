using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBoxWorker : MonoBehaviour {

    Animator ani;    

    public GameObject Bike;    

    public Transform putPoint;

    public Transform getPoint;    

    float animationSpeed = 0.5f;

    bool activeRutine = false;

    Stapler stapler;
    
    void Start()
    {        
        ani = GetComponent<Animator>();

        ani.SetTrigger("idle");

        Bike.SetActive(false);

        stapler = FindObjectOfType(typeof(Stapler)) as Stapler;
        
    }  

    private void OnTriggerEnter(Collider other)
    {       
        
        switch (other.name)
        {
                case "Bicicleta partes":                
                StartCoroutine(go(getPoint, putPoint, 2f,  animationSpeed, other.gameObject));                
                break;
        }        
    }    



    IEnumerator go(Transform posGet, Transform posPut, float WorkTime, float speed, GameObject bike)
    {
        ani.SetTrigger("get");

        yield return new WaitForSeconds(WorkTime);

        bike.GetComponent<BikeParts>().DisableParts();
        bike.gameObject.SetActive(false);

        ani.SetTrigger("carryWalk");

        Bike.SetActive(true);

        float t = 0;

        float incremento = speed * Time.deltaTime;

        Vector3 posI = transform.localPosition;

        Quaternion rotI = transform.localRotation;

        while (t < 1)
        {
            t += (incremento*4);

            //transform.localPosition = Vector3.Lerp(posI, posPut.localPosition, t);

            transform.localRotation = Quaternion.Slerp(rotI, posPut.localRotation, t);

            yield return null;
        }

        t = 0;

        incremento = speed * Time.deltaTime;

        posI = transform.localPosition;

        rotI = transform.localRotation;

        while (t < 1)
        {
            t += incremento;

            transform.localPosition = Vector3.Lerp(posI, posPut.localPosition, t);

            transform.localRotation = Quaternion.Slerp(rotI, posPut.localRotation, t);

            yield return null;
        }

        ani.SetTrigger("bikePut");

        yield return new WaitForSeconds(WorkTime/2);

        Bike.SetActive(false);

        yield return new WaitForSeconds(WorkTime/2);

        stapler.GoStapler();

        ani.SetTrigger("walk");

        t = 0;

        incremento = speed * Time.deltaTime;

        posI = transform.localPosition;

        rotI = transform.localRotation;

        while (t < 1)
        {
            t += (incremento*4);

            //transform.localPosition = Vector3.Lerp(posI, posGet.localPosition, t);

            transform.localRotation = Quaternion.Slerp(rotI, posGet.localRotation, t);

            yield return null;
        }

        t = 0;

        incremento = speed * Time.deltaTime;

        posI = transform.localPosition;

        rotI = transform.localRotation;

        while (t < 1)
        {
            t += incremento;

            transform.localPosition = Vector3.Lerp(posI, posGet.localPosition, t);

            transform.localRotation = Quaternion.Slerp(rotI, posGet.localRotation, t);

            yield return null;
        }

        ani.SetTrigger("idle");
    }   
}
