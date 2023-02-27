using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stapler : MonoBehaviour {

    Animator ani;

    public GameObject staple;

    public GameObject openCarryBox;

    public GameObject closeCarryBox;

    public GameObject floorBox;

    public Transform putPoint;

    public Transform putBox;

    public Transform getBox;

    public Transform waitPoint;

    public float T = 1.5f;

    public Animator box;


    void Start()
    {
        ani = GetComponent<Animator>();

        ani.SetTrigger("idle");

        closeCarryBox.SetActive(false);

        openCarryBox.SetActive(false);
    }   



    IEnumerator go(Transform posGet, Transform posPut, float WorkTime, float speed)
    {
         
        
        float t = 0;

        float incremento = speed * Time.deltaTime;

        Vector3 posI = transform.localPosition;

        Quaternion rotI = transform.localRotation;       

        box.SetTrigger("close");

        ani.SetTrigger("make");

        yield return new WaitForSeconds(WorkTime);

        ani.SetTrigger("staple");

        yield return new WaitForSeconds(WorkTime);

        ani.SetTrigger("pickUp");        

        yield return new WaitForSeconds(WorkTime);

        floorBox.SetActive(false);

        ani.SetTrigger("carryWalk");

        closeCarryBox.SetActive(true);

        t = 0;

        incremento = speed * Time.deltaTime;

        posI = transform.localPosition;

        rotI = transform.localRotation;

        while (t < 1)
        {
            t += incremento;

            transform.localPosition = Vector3.Lerp(posI, putBox.localPosition, t);

            transform.localRotation = Quaternion.Slerp(rotI, putBox.localRotation, t);

            yield return null;
        }        

        ani.SetTrigger("bikePut");

        yield return new WaitForSeconds(WorkTime);

        closeCarryBox.SetActive(false);

        ani.SetTrigger("walk");

        t = 0;

        incremento = speed * Time.deltaTime;

        posI = transform.localPosition;

        rotI = transform.localRotation;

        while (t < 1)
        {
            t += incremento;

            transform.localPosition = Vector3.Lerp(posI, getBox.localPosition, t);

            transform.localRotation = Quaternion.Slerp(rotI, getBox.localRotation, t);

            yield return null;
        }

        ani.SetTrigger("make");

        yield return new WaitForSeconds(WorkTime/2);

        openCarryBox.SetActive(true);        

        ani.SetTrigger("carryWalk");        

        t = 0;

        incremento = speed * Time.deltaTime;

        posI = transform.localPosition;

        rotI = transform.localRotation;

        while (t < 1)
        {
            t += incremento;

            transform.localPosition = Vector3.Lerp(posI, putPoint.localPosition, t);

            transform.localRotation = Quaternion.Slerp(rotI, putPoint.localRotation, t);

            yield return null;
        }

        ani.SetTrigger("bikePut");

        yield return new WaitForSeconds(WorkTime/2);

        ani.SetTrigger("pickUp");

        yield return new WaitForSeconds(WorkTime/2);

        openCarryBox.SetActive(false);

        floorBox.SetActive(true);

        box.SetTrigger("open");            

        ani.SetTrigger("idle");

        
    }

    public void GoStapler()
    {
        StartCoroutine(go(waitPoint, putPoint, .8f, T));
    }
}
