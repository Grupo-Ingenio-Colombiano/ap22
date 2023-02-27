using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualinaManager : MonoBehaviour, ItemActions
{
    GameObject virtualina;

    public void CustomAction()
    {
        var player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;

        virtualina = Instantiate(Resources.Load("masMovimiento"), player.gameObject.transform) as GameObject;

        player.GetComponent<Animator>().speed = 1.4f;

        StartCoroutine(EndVirtualina());
    }

    IEnumerator EndVirtualina()
    {
        yield return new WaitForSeconds(5f);
        Destroy(virtualina);
    }
}
