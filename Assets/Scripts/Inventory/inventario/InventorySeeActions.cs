using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySeeActions : MonoBehaviour {

    public Inventory inventario;

    public GameObject infoWindow;    

    public Text title;

    public Text content;

    public Image infoImage;

    public GameObject inventoryChild;    

    public GameObject[] indexUi;

    [SerializeField] PlayerCanMove movementControl;


    public void setInfo()
    {
        infoWindow.SetActive(true);
        inventario.playpress();
        inventoryChild.SetActive(false);
        movementControl.CanMove = false;

        if (inventario.inventoryList[inventario.indice].indexUi == 1)
        {
            indexUi[1].SetActive(true);            
            infoImage.sprite = inventario.inventoryList[inventario.indice].infoSprite;
            title.text = inventario.inventoryList[inventario.indice].itemName;
            content.text = inventario.inventoryList[inventario.indice].infotext;           
                
        }

        else if(inventario.inventoryList[inventario.indice].indexUi > 1)
        {
            indexUi[1].SetActive(false);
            indexUi[inventario.inventoryList[inventario.indice].indexUi].SetActive(true);
        }        

    }

    public void RestoreInventory()
    {
        indexUi[inventario.inventoryList[inventario.indice].indexUi].SetActive(false);
        inventario.playpress();
        infoWindow.SetActive(false);
        inventoryChild.SetActive(true);
        inventario.ResetAlerts();
        movementControl.CanMove = true;
    }
	
	
}
