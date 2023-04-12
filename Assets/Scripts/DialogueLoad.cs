using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLoad : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] VIDE_Assign videAssign;
    [SerializeField] UserData userData;
    void Start()
    {
        if(userData.load == 1)
        {
            videAssign.interactionCount = 2;
            videAssign.overrideStartNode = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
