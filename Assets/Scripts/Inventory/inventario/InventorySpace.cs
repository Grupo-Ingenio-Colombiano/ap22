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

    void Start ()
    {
        inventario = Inventory.Instance();
        nombre = gameObject.name;        
        indice = getnumber(name);
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

        //print(inventario.indice);
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
