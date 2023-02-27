using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorControl : MonoBehaviour {

    public Transform leftDoor;

    public Transform rightDoor;

    

    bool active = false;

    public Vector3 closePositionDoorLeft;

    public Vector3 openPositionDoorLeft;

    public Vector3 closePositionDoorRight;

    public Vector3 openPositionDoorRight;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StartCoroutine(AnimatePosition(closePositionDoorLeft, openPositionDoorLeft, 1, leftDoor));
            StartCoroutine(AnimatePosition(closePositionDoorRight, openPositionDoorRight, 1, rightDoor));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StartCoroutine(AnimatePosition( openPositionDoorLeft, closePositionDoorLeft, 1, leftDoor));
            StartCoroutine(AnimatePosition( openPositionDoorRight, closePositionDoorRight, 1, rightDoor));
        }
    }
    

    IEnumerator AnimatePosition(Vector3 dataIn, Vector3 dataOut, float time, Transform animateObject)
    {
        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;

            animateObject.localPosition = Vector3.Lerp(dataIn,dataOut,t);
            //animateObject.transform.localPosition = new Vector3(animateObject.transform.localPosition.x, animateObject.transform.localPosition.y, Mathf.Lerp(dataIn, dataOut, t));

            yield return null;
        }

    }

}
