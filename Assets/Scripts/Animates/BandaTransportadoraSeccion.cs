using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandaTransportadoraSeccion : MonoBehaviour
{

    float speed = 0.005f;

    bool move = true;

    Quaternion rotIni;

    Vector3 posIni;

    Vector3 posFinal;

    Vector3 posFinalRotate;

    Vector3 posIniSinRot;

    GameObject bicicleta;

    BikeWorker1 worker;

    [SerializeField]
    GameObject bike;

    private void Start()
    {
        rotIni = Quaternion.Euler(0, 0, 0);

        posIni = new Vector3(0, 0.7185f, -9.52f);

        posIniSinRot = new Vector3(0, 0.532f, -9.57f);

        posFinalRotate = new Vector3(0, 0.532f, 9.57f);

        worker = FindObjectOfType(typeof(BikeWorker1)) as BikeWorker1;
    }



    private void FixedUpdate()
    {
        if (move)
        {
            transform.position += (transform.forward * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("ControlPointWay"))
        {
            move = false;
            posFinal = transform.localPosition;
            StartCoroutine(AnimateEnd(1f));

        }

        //print("trigger");
    }

    IEnumerator AnimateEnd(float time)
    {
        float t = 0;

        //Destroy(bicicleta);
        //bike.SetActive(false);

        while (t < 1)
        {
            t += time * Time.deltaTime;

            transform.localRotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(90, 0, 0), t);

            transform.localPosition = Vector3.Lerp(posFinal, posFinalRotate, t);

            yield return null;

        }

        StartCoroutine(AnimateStart(1f));

    }

    IEnumerator AnimateStart(float time)
    {
        float t = 0;

        worker.install();
        while (t < 1)
        {
            t += time * Time.deltaTime;

            transform.localRotation = Quaternion.Slerp(Quaternion.Euler(-90, 0, 0), Quaternion.Euler(0, 0, 0), t);

            transform.localPosition = Vector3.Lerp(posIniSinRot, posIni, t);

            yield return null;
        }

        move = true;

        //bicicleta = Instantiate(Resources.Load("Bicicleta partes"), transform, true) as GameObject;
        bike.SetActive(true);


    }



}
