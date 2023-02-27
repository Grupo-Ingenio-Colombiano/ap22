using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMove : MonoBehaviour
{

    Transform[] wayPoints;

    GameObject gancho;

    GameObject rail;

    MeshRenderer[] renderers;

    int actualPoint;

    public float speed = 5f;

    public GameObject marco;

    public GameObject horquilla;

    public int switchObject = 0;

    Color azulCycla;

    // Use this for initialization
    void Start()
    {
        gancho = gameObject;

        renderers = GetComponentsInChildren<MeshRenderer>();

        azulCycla = new Color32(78, 181, 218, 255);

        rail = GameObject.FindWithTag("railWayPoints");

        wayPoints = rail.GetComponentsInChildren<Transform>();        

        actualPoint = 1;

        StartCoroutine(animateNextPoint(gancho, actualPoint + 1, speed));
        

        marco.SetActive(false);

        horquilla.SetActive(false);
        
    }

    


    IEnumerator animateNextPoint(GameObject g, int nextPoint, float time)
    {        
        Quaternion q = g.transform.rotation;
        Vector3 v = g.transform.position;
        Vector3 d = v - wayPoints[nextPoint].transform.position;
        float distance = d.magnitude;

        float t = 0;
        while (t < 1)
        {
            t += (time * Time.deltaTime) / distance ;
            g.transform.position = Vector3.Lerp(v, wayPoints[nextPoint].transform.position, t);
            g.transform.rotation = Quaternion.Slerp(q, wayPoints[nextPoint].rotation, t);
            yield return null;           
                        
        }        

        if (nextPoint >= wayPoints.Length-1)
        {
            StartCoroutine(animateNextPoint(gancho,  1, speed));
        }

        else
        {
            StartCoroutine(animateNextPoint(gancho, nextPoint + 1, speed));
        }        

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "putElement":

                setColor(Color.gray);

                if (switchObject.Equals(0))
                {
                    marco.SetActive(true);
                }
                else
                {
                    horquilla.SetActive(true);
                }                
                break;

            case "quitElement":
                marco.SetActive(false);
                horquilla.SetActive(false);
                break;

            case "paintWhite":
                setColor(Color.white);
                break;

            case "paintBlue":
                setColor(Color.blue);
                break;

            case "paintDry":
                setColor(azulCycla);
                break;

            case "validateObject":
                if (switchObject.Equals(0))
                {
                    switchObject = 1;
                }

                else
                {
                    switchObject = 0;
                }
                break;

               
        }
    }


    void setColor(Color col)
    {
        /*foreach (MeshRenderer i in renderers)
        {
            i.material.color = col;
        }*/

        for (int i = 0; i < renderers.Length; i++)
        {
            if (!i.Equals(0))            
                renderers[i].material.color = col;
        }

    }



}
