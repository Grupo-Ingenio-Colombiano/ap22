using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoObject : MonoBehaviour
{

    //[SerializeField] int index;
    [SerializeField] float minDistanceToEnable = 5f;
    [SerializeField] GameObject UIInfo;

    //[SerializeField] int nonOptionalInfoIndex;

    GameObject target;

    bool isOnButton = false;

    Texture2D enabledCursor;
    Texture2D disabledCursor;

    private void Start()
    {

        //UIInfo = GameObject.FindWithTag("Infopanel");
        target = GameObject.FindWithTag("Player");
        print(target.gameObject.name);
        //enabledCursor = GameManager.instance.spriteHandEnabled;//TODO
        //disabledCursor = GameManager.instance.spriteHandDisabled;
    }

    private void Update()
    {
        if (isOnButton)
        {
            if (PlayerIsNextToInfo())
            {
                //Cursor.SetCursor(enabledCursor, Vector2.zero, CursorMode.ForceSoftware);
            }
            else
            {
                //Cursor.SetCursor(disabledCursor, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
    }

    private void OnMouseEnter()
    {
        isOnButton = true;
    }

    private bool PlayerIsNextToInfo()
    {
        target = GameObject.FindWithTag("Player");
        return Vector3.Distance(transform.position, target.transform.position) < minDistanceToEnable;
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !GetComponent<InfoObject>().enabled)
        {
            return;
        }


        if (PlayerIsNextToInfo())
        {
            ShowInfo();

        }
    }

    public void ShowInfo()
    {
        UIInfo.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        isOnButton = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }


}
