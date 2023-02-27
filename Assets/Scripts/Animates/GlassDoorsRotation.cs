using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorsRotation : MonoBehaviour
{

    public Transform inMarker;

    public Transform outMarker;

    public Transform LeftDoor;

    public Transform RightDoor;

    bool active = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //print("in");
            if (!active)
            {
                RaycastHit hit;
                if (Physics.Raycast(inMarker.position, inMarker.TransformDirection(Vector3.forward), out hit, 4))
                {
                    if (hit.collider.tag.Equals("Player"))
                    {
                        StartCoroutine(animateRotation(0, -120, 1f, LeftDoor));
                        StartCoroutine(animateRotation(0, 120, 1f, RightDoor));
                        StartCoroutine(CloseDoorsIn(1f));
                        active = true;
                        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("openDoor");
                    }

                }
                else if (Physics.Raycast(outMarker.position, outMarker.TransformDirection(Vector3.forward), out hit, 4))
                {
                    if (hit.collider.tag.Equals("Player"))
                    {
                        StartCoroutine(animateRotation(0, 120, 1f, LeftDoor));
                        StartCoroutine(animateRotation(0, -120, 1f, RightDoor));
                        StartCoroutine(CloseDoorsOut(1f));
                        active = true;
                        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("openDoor");
                    }
                }
            }

        }
    }



    IEnumerator animateRotation(int dataIn, int dataOut, float time, Transform door)
    {

        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;

            door.localRotation = Quaternion.AngleAxis(Mathf.Lerp(dataIn, dataOut, t), Vector3.forward);



            yield return null;
        }

    }

    IEnumerator CloseDoorsIn(float time)
    {

        yield return new WaitForSeconds(10f);


        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;

            LeftDoor.localRotation = Quaternion.AngleAxis(Mathf.Lerp(-120f, 0, t), Vector3.forward);
            RightDoor.localRotation = Quaternion.AngleAxis(Mathf.Lerp(120f, 0, t), Vector3.forward);


            yield return null;
        }

        active = false;
    }

    IEnumerator CloseDoorsOut(float time)
    {

        yield return new WaitForSeconds(10f);


        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;

            LeftDoor.localRotation = Quaternion.AngleAxis(Mathf.Lerp(120f, 0, t), Vector3.forward);
            RightDoor.localRotation = Quaternion.AngleAxis(Mathf.Lerp(-120f, 0, t), Vector3.forward);


            yield return null;
        }

        active = false;
    }



}
