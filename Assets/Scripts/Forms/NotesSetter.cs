using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesSetter : MonoBehaviour
{
    [SerializeField] SamplingNotes notes;

    public void OnMouseDown()
    {
        notes.EnableProducedUnits();
        QuestSampling.Instance.SwapOperator();
    }

}
