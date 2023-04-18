using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UserData userData;
    [SerializeField] GameObject dialogSST;

    [SerializeField]
    VIDE_Assign videJefe;

    // Update is called once per frame

    private void Start()
    {
        if(userData.isSave == true)
        {
            if(userData.load >= 1)
            {
                videJefe.overrideStartNode = 10;
            }
        }
    }

    public void SetIndicatorLoad()
    {
        if(userData.load == 1)
        {
            dialogSST.SetActive(true);
        }
    }
}
