using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UserData userData;
    [SerializeField] GameObject dialogSST;

    // Update is called once per frame
   
    public void SetIndicatorLoad()
    {
        if(userData.load == 1)
        {
            dialogSST.SetActive(true);
        }
    }
}
