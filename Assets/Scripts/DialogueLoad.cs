using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLoad : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] VIDE_Assign videAssign;
    [SerializeField] UserData userData;

    [SerializeField] int count;
    [SerializeField] int startNode;
    void Start()
    {
        if(userData.load == 1)
        {
            videAssign.interactionCount = count;
            videAssign.overrideStartNode = startNode;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
