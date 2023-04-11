using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemAndDialog : MonoBehaviour
{

   
    ItemRecibe recibeManager;    

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

    float distance;

    [SerializeField] int ord;

    

    void Start()
    {
        render = GetComponent<Renderer>();
        recibeManager = FindObjectOfType(typeof(ItemRecibe)) as ItemRecibe;      

    }


   

    public void setItem()
    {

        if (!GameObject.FindWithTag("received").GetComponent<Canvas>().enabled)
        {            
                if (Inventory.Instance().inventoryList.Count < Inventory.casillas_inventario)
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    recibeManager.SetItemBoxAndDialog(objectName, objectImage, eliminable, objectToAction, infoText, infoImage, playerEquip, otherUi, useDistance, oneTimeUse, ord);
                    
                }

                else
                    Inventory.Instance().playError();
        }        
    }

    

   
}
