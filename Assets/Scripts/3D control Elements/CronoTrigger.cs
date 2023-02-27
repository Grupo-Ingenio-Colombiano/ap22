using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronoTrigger : MonoBehaviour, ItemActions
{
    [SerializeField]
    GameObject cronometer;

    [SerializeField]
    GameObject[] posWatch;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    static CronoTrigger crono = new CronoTrigger();

    static public CronoTrigger instance()
    {
        crono = FindObjectOfType(typeof(CronoTrigger)) as CronoTrigger;
        return crono;
    }

    public void CustomAction()
    {
        cronometer.SetActive(true);
        player.transform.LookAt(gameObject.transform);

        if (QuestTiming.Instance)
        {
            player.transform.position = posWatch[QuestTiming.Instance.CurrentOperationData.Index-1].transform.position;
        }
        
    }

    public void SetPosition(Vector3 pos)
    {
        gameObject.transform.position = pos;
        
            
    }
}
