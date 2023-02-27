using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneralWorker : MonoBehaviour {

    Animator ani;

    public GameObject[] obj;    

    public Transform putPoint;

    public Transform getPoint;

    float animationSpeed = 0.5f; 

    
    void Start()
    {
        ani = GetComponent<Animator>();

        ani.SetTrigger("idle");       

        setObj(true);        
    }   

    private void OnTriggerEnter(Collider other)
    {        

        switch (other.name)
        {
            case "posGet":                
                break;

            case "posPut":
                ani.SetTrigger("idle");                
                break;
        }        
    }


    public void Install()
    {
        StartCoroutine(go(getPoint, putPoint, 2f, animationSpeed));             
    }

    IEnumerator go(Transform posGet, Transform posPut, float WorkTime, float speed)
    {
        ani.SetTrigger("get");

        yield return new WaitForSeconds(WorkTime);

        ani.SetTrigger("walk");          

        setObj(false);

        float t = 0;

        float incremento = speed * Time.deltaTime;

        Vector3 posI = transform.localPosition;

        Quaternion rotI = transform.localRotation;

        while (t < 1)
        {
            t += (incremento*6);            

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

        ani.SetTrigger("get");

        yield return new WaitForSeconds(WorkTime);

        setObj(true);

        ani.SetTrigger("walk");

        t = 0;

        incremento = speed * Time.deltaTime;

        posI = transform.localPosition;

        rotI = transform.localRotation;

        while (t < 1)
        {
            t += (incremento*6);            

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

        ani.SetTrigger("idle");
    }   

    void setObj(bool estate)
    {
        
        foreach (GameObject i in obj)
        {
            i.SetActive(estate);
        }
    }   
}
