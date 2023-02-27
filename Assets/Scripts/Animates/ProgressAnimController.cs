using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressAnimController : MonoBehaviour
{
    [SerializeField]
    Animator anim;    

    public void setAnim(string triger)
    {
        anim.SetTrigger(triger);
    }
        
}
