using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectToInventory : MonoBehaviour {


    ItemRecibe recibeManager;

    public bool clickable;

    public string objectName;

    public Sprite objectImage;        

    public bool eliminable, playerEquip;

    public GameObject objectToAction;

    public Sprite infoImage;

    public string infoText;

    public int otherUi;

    public float useDistance;

    public bool oneTimeUse;

    Renderer render;

    Texture2D hand;

    Texture2D offHand;

    [SerializeField] int ord;

    float distance;

    void Start ()
    {
        render = GetComponent<Renderer>();
        recibeManager = FindObjectOfType(typeof(ItemRecibe)) as ItemRecibe;

        hand = Resources.Load("cursorTextures/mano_2") as Texture2D;

        offHand = Resources.Load("cursorTextures/mano_off") as Texture2D;

    }        


    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && clickable)
        {
            if (GameObject.FindWithTag("Player"))
            {
                distance = (gameObject.transform.position - GameObject.FindWithTag("Player").transform.position).magnitude;
            }

            if (distance < 2)
                Cursor.SetCursor(hand, Vector2.zero, CursorMode.ForceSoftware);
            else
                Cursor.SetCursor(offHand, Vector2.zero, CursorMode.ForceSoftware);

            render.material.color = Color.yellow;
        }

        
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && clickable)
        {
            setItem();            
        }
    }

    public void setItem()
    {        

        if (!GameObject.FindWithTag("received").GetComponent<Canvas>().enabled && clickable)
        {            
            if (distance < 2)
            {
                if (Inventory.Instance().inventoryList.Count < Inventory.casillas_inventario)
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    recibeManager.SetItemBox(objectName, objectImage, eliminable, objectToAction, infoText, infoImage, playerEquip, otherUi, useDistance, oneTimeUse, ord);                    
                    Destroy(gameObject);
                }

                else
                    Inventory.Instance().playError();

            }
           
        }

        else if (!clickable)
        {
            if (Inventory.Instance().inventoryList.Count < Inventory.casillas_inventario)
            {                
                recibeManager.SetItemBox(objectName, objectImage, eliminable, objectToAction, infoText, infoImage, playerEquip, otherUi, useDistance, oneTimeUse, ord);                
            }

            else
                Inventory.Instance().playError();
        }
    }

    public void setItem(string objAction)
    {
        var obj = GameObject.Find(objAction);

        if (!GameObject.FindWithTag("received").GetComponent<Canvas>().enabled && clickable)
        {
            if (distance < 2)
            {
                if (Inventory.Instance().inventoryList.Count < Inventory.casillas_inventario)
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    recibeManager.SetItemBox(objectName, objectImage, eliminable, objectToAction, infoText, infoImage, playerEquip, otherUi, useDistance, oneTimeUse, ord);
                    Destroy(gameObject);
                }

                else
                    Inventory.Instance().playError();

            }

        }

        else if (!clickable)
        {
            if (Inventory.Instance().inventoryList.Count < Inventory.casillas_inventario)
            {
                recibeManager.SetItemBox(objectName, objectImage, eliminable, obj, infoText, infoImage, playerEquip, otherUi, useDistance, oneTimeUse, ord);
            }

            else
                Inventory.Instance().playError();
        }
    }

    private void OnMouseExit()
    {
        if (clickable)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            render.material.color = Color.white;
        }
        
    }

    private void OnDestroy()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }


}
