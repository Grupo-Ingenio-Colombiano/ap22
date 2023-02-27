using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerClues : ScriptableObject
{
    public int clues;
    public int initialClues;

    public event Action<int> OnCluesChanged = delegate { };

    private void OnEnable()
    {
        ResetClues();
    }

    public void ResetClues()
    {
        clues = initialClues;
    }

    public void AddClues(int n)
    {
        clues += n;

        if (clues < 0)
        {
            clues = 0;
        }

        if (OnCluesChanged != null)
        {
            OnCluesChanged(clues);
        }
    }

    public void LoadClues(int n)
    {
        clues = n;

        if (OnCluesChanged != null)
        {
            OnCluesChanged(clues);
        }
    }
}
