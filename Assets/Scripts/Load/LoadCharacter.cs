using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UserData userData;

    // Update is called once per frame
   
    public void SetIndicatorLoad()
    {
        if(userData.load == 1)
        {
            IndicatorManager.instance().SetDestiny(new Vector3(41, 0, -20.3f));
        }
    }
}
