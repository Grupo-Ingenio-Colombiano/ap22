using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandarDoorControl : MonoBehaviour
{

    Transform inMarker;

    Transform outMarker;

    Transform[] markers;

    bool active = false;

    void Start()
    {
        markers = GetComponentsInChildren<Transform>();

        inMarker = markers[1];

        outMarker = markers[2];

    }


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
                        StartCoroutine(openDoor(0, -75, 1f));
                        StartCoroutine(closeDoor(-75, 0, 1f));
                        active = true;
                        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("openDoor");
                    }

                }
                else if (Physics.Raycast(outMarker.position, outMarker.TransformDirection(Vector3.forward), out hit, 4))
                {
                    if (hit.collider.tag.Equals("Player"))
                    {
                        StartCoroutine(openDoor(0, 75, 1f));
                        StartCoroutine(closeDoor(75, 0, 1f));
                        active = true;
                        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("openDoor");
                    }
                }
            }

        }
    }



    IEnumerator closeDoor(int dataIn, int dataOut, float time)
    {

        yield return new WaitForSeconds(10f);

        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;

            transform.localRotation = Quaternion.AngleAxis(Mathf.Lerp(dataIn, dataOut, t), Vector3.forward);



            yield return null;
        }

        active = false;
    }

    IEnumerator openDoor(int dataIn, int dataOut, float time)
    {
        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;

            transform.localRotation = Quaternion.AngleAxis(Mathf.Lerp(dataIn, dataOut, t), Vector3.forward);

            yield return null;
        }

    }

}
