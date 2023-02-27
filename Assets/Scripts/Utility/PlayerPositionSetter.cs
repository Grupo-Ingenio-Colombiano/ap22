using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionSetter : MonoBehaviour
{

    [SerializeField] Vector2 settingPos;

    public void SetPlayerPosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.gameObject.transform.SetPositionAndRotation(new Vector3(settingPos.x, 1.1f, settingPos.y), Quaternion.identity);
    }
}
