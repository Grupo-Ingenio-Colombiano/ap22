using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpace : MonoBehaviour {


    Inventory inventario;
    string nombre;    
    Text descripcion;
    public int usos = 0;
    static public int usos_totales= 0;
    int indice;
    [SerializeField] InventoryUseActions inventoryUseActions;
    [SerializeField] UserData userData;
    void Start ()
    {
        inventario = Inventory.Instance();
        nombre = gameObject.name;        
        indice = getnumber(name);

        if(userData.load >= 2)
        {

            EquipLoad();
        }
    }	

    public void seleccionar_objeto()
    {
        inventario.UpdateInventory();

        for (int i = 0; i < inventario.inventoryList.Count; i++)
        {
            if (nombre == "item_" + i.ToString())
            {
                inventario.seleccionado = inventario.inventoryList[i].itemName;
                inventario.indice = i; 
            }
          
        }
     
        inventario.UpdateInventory();
    }
   public void EquipLoad()
    {
        inventario.UpdateInventory();

        for (int i = 0; i < inventario.inventoryList.Count; i++)
        {
            if (nombre == "item_" + i.ToString())
            {
                inventario.seleccionado = inventario.inventoryList[i].itemName;
                inventario.indice = i;
                if (userData.load >= 2 && inventario.inventoryList[inventario.indice].playerEquip && inventario.inventoryList[inventario.indice].itemName != "Camiseta")
                {
                    inventoryUseActions.StartAction();
                }
            }

        }

        inventario.UpdateInventory();
    }
  
    int getnumber(string s)
    {
        int i;
        foreach (char c in s)
        {
            if (int.TryParse(c.ToString(), out  i))
            {
                return i;
            }
        }

        return 10;
    }    

}
