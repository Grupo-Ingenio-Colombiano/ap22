using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog1ISSGT : MonoBehaviour
{

    public CapsuleCollider col1;

    public SphereCollider col2;

    public Vector3 playerPosition;

    GameObject player;

    

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        col1.enabled = true;
        col2.enabled = true;
        IndicatorManager.instance().SetDestiny(new Vector3(41,0,-20.3f));
    }

    public void SetPlayerPosition()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = playerPosition;
    }
    
}
