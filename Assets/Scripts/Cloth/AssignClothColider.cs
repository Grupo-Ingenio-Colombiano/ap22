using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignClothColider : MonoBehaviour
{

    Cloth[] cortinas;
    CapsuleCollider[] col;

    // Use this for initialization
    void Start()
    {


        if (GameObject.FindWithTag("Player"))
        {
            col = GameObject.FindWithTag("Player").GetComponents<CapsuleCollider>();
            cortinas = GetComponentsInChildren<Cloth>();
            //print("cortinas asignadas");

            foreach (Cloth c in cortinas)
            {
                c.capsuleColliders = col;

            }
        }

        else
        {
            Debug.LogError("se requiere un player en la escena");
        }
    }

}
