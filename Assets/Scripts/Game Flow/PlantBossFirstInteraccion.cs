using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBossFirstInteraccion : MonoBehaviour
{
    public CapsuleCollider col1;

    public SphereCollider col2;    

    public Vector3 playerPosition;       


    private void OnEnable()
    {
        IndicatorManager.instance().SetDestiny(new Vector3(39.35f, 3.33f, -7.08f));        

        col1.enabled = true;
        col2.enabled = true;

        //SetPlayerPosition();

        HelpManager.Instance().SetHelp("Busque al jefe de planta en las oficinas administrativas y hable con él.");
    }


    public void SetPlayerPosition()
    {

        var player = GameObject.FindWithTag("Player");
        player.transform.position = playerPosition;
    }

    public void DisablePlayer()
    {
        col1.enabled = false;
        col2.enabled = false;
    }

    
}
