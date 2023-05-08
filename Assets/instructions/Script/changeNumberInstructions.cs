using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeNumberInstructions : StateMachineBehaviour
{

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetInteger("animar", 0);
    }
}
