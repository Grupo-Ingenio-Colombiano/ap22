using UnityEngine;

[CreateAssetMenu]
public class PlayerCanMove : ScriptableObject
{
    public bool CanMove = true;

    private void OnEnable()
    {
        CanMove = true;
    }
}
