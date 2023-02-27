using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormClicControl : MonoBehaviour
{

    Texture2D hand;

    Texture2D offHand;

    float distance;

    [SerializeField]
    Collider col;

    [SerializeField]
    InputField input;

    private void OnEnable()
    {

        hand = Resources.Load("cursorTextures/mano_2") as Texture2D;

        offHand = Resources.Load("cursorTextures/mano_off") as Texture2D;
    }
    private void OnMouseOver()
    {
        if (GameObject.FindWithTag("Player"))
        {
            distance = (gameObject.transform.position - GameObject.FindWithTag("Player").transform.position).magnitude;
            
        }

        if (distance < 4 && distance > 1.9f)
            Cursor.SetCursor(hand, Vector2.zero, CursorMode.ForceSoftware);
        else
            Cursor.SetCursor(offHand, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseDown()
    {
        if (distance < 4 && distance > 1.9f)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);

            GameObject.FindWithTag("Player").SetActive(false);

            FollowCameraController.instance.SetCameraFollow(gameObject, 40, false);

            col.enabled = false;

            input.interactable = true;
        }            
    }
}
