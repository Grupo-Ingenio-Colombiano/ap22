using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverEvent : MonoBehaviour
{

    private void OnMouseEnter()
    {
        //print(gameObject.name);
        Activate();
    }

    private void OnMouseExit()
    {
        Deactivate();
    }

    //private void OnMouseDown()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        Deactivate();

    //        if (GetComponent<InfoDataObject>())
    //        {
    //            GetComponent<InfoDataObject>().ShowInfo();
    //        }
    //        //else
    //        //{
    //        //    //print("nope " + gameObject.name);
    //        //}
    //    }

    //}

    private MeshRenderer[] meshRenderers;

    private Color outlineColor = Color.yellow;


    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();

        Deactivate();
    }

    public void Activate()
    {
        try
        {
            foreach (MeshRenderer i in meshRenderers)
            {
                i.material.color = outlineColor;
            }
        }
        catch (System.Exception e)
        {
            //print(gameObject.name);
        }

    }

    public void Deactivate()
    {
        try
        {
            foreach (MeshRenderer i in meshRenderers)
            {
                i.material.color = Color.white;
            }
        }
        catch (System.Exception e)
        {
            //print(gameObject.name);
        }
    }

}
