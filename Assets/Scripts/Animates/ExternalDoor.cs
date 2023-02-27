using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalDoor : MonoBehaviour
{

    public Transform posOpen;

    public Transform posClose;

    bool opening = false;

    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    IEnumerator AnimatePosition(Vector3 dataIn, Vector3 dataOut, float time, Transform animateObject, bool close)
    {
        float t = 0;

        aud.Play();

        while (t < 1)
        {
            t += time * Time.deltaTime;

            animateObject.localPosition = Vector3.Lerp(dataIn, dataOut, t);
            yield return null;
        }

        yield return new WaitForSeconds(5);

        if (close)
        {
            StartCoroutine(AnimatePosition(posOpen.localPosition, posClose.localPosition, .1f, transform, false));
        }

        else
        {
            opening = false;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !opening)
        {
            StartCoroutine(AnimatePosition(posClose.localPosition, posOpen.localPosition, .1f, transform, true));

            opening = true;
        }

    }


}

