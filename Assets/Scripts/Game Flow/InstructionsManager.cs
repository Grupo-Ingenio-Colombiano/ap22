using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{

    [SerializeField]
    GameObject instructionsBlock;

    [SerializeField]
    GameObject plantBossStart;

    [SerializeField]
    GameObject[] instructions;

    public Canvas canvasInstructions;

    int lastIndex = 0;

    int instructionState = 0;

    private void OnEnable()
    {
        canvasInstructions.enabled = true;
        evaluateState();
    }

    public void evaluateState()
    {
        instructionState += 1;
        lastIndex = instructionState;
        UnactiveInstructions(instructionState);
    }


    void UnactiveInstructions(int i)
    {
        foreach (var item in instructions)
        {
            item.SetActive(false);
        }

        if (instructionState < instructions.Length)
        {
            instructions[i].gameObject.SetActive(true);
        }
        else
        {
            EndInstructions();
        }
    }

    void validation()
    {
        foreach (var item in instructions)
        {
            item.SetActive(false);
        }
        instructions[0].gameObject.SetActive(true);
    }

    public void Skip()
    {
        evaluateState();
    }

    public void SkipAll()
    {
        validation();
    }

    public void EndInstructions()
    {
        instructionState = 0;
        canvasInstructions.enabled = false;
        instructionsBlock.SetActive(false);
        //plantBossStart.SetActive(true); //THIS!!!
        gameObject.SetActive(false);

    }

    public void ContinueInstructions()
    {
        foreach (var item in instructions)
        {
            item.SetActive(false);
        }

        if (instructionState < instructions.Length)
        {
            instructions[lastIndex].gameObject.SetActive(true);
        }
        else
        {
            EndInstructions();
        }
    }
}
