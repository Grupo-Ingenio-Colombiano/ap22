using UnityEngine;

[CreateAssetMenu]
public class Name : ScriptableObject
{
    public string AssignedName;

    private void OnEnable()
    {
        AssignedName = "Invitado";
    }
}
