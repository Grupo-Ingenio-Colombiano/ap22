using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInSelector : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] UserData userData;

    private void Awake()
    {
        if (int.TryParse(userData.PlayerSelected, out int result))
        {
            PlayerEnabled(result);
            Debug.Log("Seleccionando personaje " +  result);
        }
        else
        {
            Debug.Log("El valor almacenado en User Data no es un número");
        }
    }
    void PlayerEnabled(int index)
    {
        foreach (var item in players)
        {
            item.SetActive(false);
        }

        players[index].SetActive(true);
    }
}
