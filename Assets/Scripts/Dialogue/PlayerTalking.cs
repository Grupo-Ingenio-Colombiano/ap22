using UnityEngine;

[CreateAssetMenu]
public class PlayerTalking : ScriptableObject
{
    public bool CanTalk = true;

    private void OnEnable()
    {
        CanTalk = true;
    }

}
