using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkableCaracterPos : MonoBehaviour
{

    Quaternion initRot;

    void Start()
    {
        initRot = transform.rotation;
    }

    public void SetInitRot()
    {
        transform.rotation = initRot;
    }
}
