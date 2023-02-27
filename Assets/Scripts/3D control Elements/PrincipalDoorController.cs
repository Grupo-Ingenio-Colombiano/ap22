using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalDoorController : MonoBehaviour
{
    [SerializeField]

    BoxCollider doorColider;

    public void EnabledDoorColider()
    {
        doorColider.enabled = true;
    }
}
