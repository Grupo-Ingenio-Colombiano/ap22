using UnityEngine;

public class PlayerInSelector : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] UserData userData;
    private void Awake()
    {
        int result = int.Parse(userData.PlayerSelected);
        players[result].SetActive(true);
    }
}
