using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUseActions : MonoBehaviour {

    public Inventory inventario;
    Transform player;

    //mensajes de alerta

    public GameObject badAlert;
    public GameObject goodAlert;

    //botones usar

    public GameObject btnUsar;
    public GameObject btnRetirar;

    [SerializeField] UserData userData;
    [SerializeField] InventorySpace inventorySpace;

    string nombre;

    void Start()
    {        
        player = GameObject.FindWithTag("Player").transform;

   
    }

  
        public void StartAction()
    {
        print("Por que el indice es " + inventario.indice);
        var obj = inventario.inventoryList[inventario.indice].obj;
      
        if (!inventario.inventoryList[inventario.indice].isNowEquiped && inventario.inventoryList[inventario.indice].playerEquip && !obj)
        {
            btnUsar.SetActive(false);            
            btnRetirar.SetActive(true);            
        }
        else
        {
            btnUsar.SetActive(true);
            btnUsar.GetComponent<Button>().interactable = true;
            btnRetirar.SetActive(false);            
        }

        if (inventario.inventoryList[inventario.indice].playerEquip && !obj)
        {
            player.gameObject.GetComponent<CharacterAppearanceManager>().SetItem(inventario.seleccionado);
            if (inventario.inventoryList[inventario.indice].isNowEquiped)
                GoodAlert("Ha equipado " + inventario.seleccionado);
            else
                GoodAlert("Ha retirado " + inventario.seleccionado);
            //inventario.DeleteItem();
        }


        //caso unico para montacargas________________________________

        else if (inventario.inventoryList[inventario.indice].playerEquip && obj)
        {           

            if (!inventario.inventoryList[inventario.indice].isNowEquiped)
            {                
                var distance = (player.position - obj.transform.position).magnitude;

                if (obj.GetComponent<ItemActions>() != null)
                {
                    if (inventario.inventoryList[inventario.indice].useDistance == 0)
                    {
                        btnUsar.SetActive(false);
                        btnRetirar.SetActive(true);
                        inventario.inventoryList[inventario.indice].isNowEquiped = true;
                        GoodAlert("Ha utilizado " + inventario.seleccionado);
                        obj.GetComponent<ItemActions>().CustomAction();
                    }
                    else
                    {

                        if (distance < inventario.inventoryList[inventario.indice].useDistance)
                        {
                            btnUsar.SetActive(false);
                            btnRetirar.SetActive(true);
                            inventario.inventoryList[inventario.indice].isNowEquiped = true;
                            GoodAlert("Ha utilizado " + inventario.seleccionado);
                            obj.GetComponent<ItemActions>().CustomAction();
                        }

                        else
                        {
                            BadAlert("No puede usar " + inventario.seleccionado + " aquí");
                        }
                    }                    
                }
                else
                    BadAlert("No hay ItemActions");
            }

            else
            {
                GoodAlert("Ha retirado " + inventario.seleccionado);
                obj.GetComponent<ItemActions>().CustomAction();
                inventario.inventoryList[inventario.indice].isNowEquiped = false;
                btnUsar.SetActive(true);
                btnUsar.GetComponent<Button>().interactable = true;
                btnRetirar.SetActive(false);
            }                
            
        }
        //___________________________________________________________

        else
        {
            if (obj)
            {
                var distance = (player.position - obj.transform.position).magnitude;

                if (obj.GetComponent<ItemActions>() != null)
                {
                    if (inventario.inventoryList[inventario.indice].useDistance == 0)
                    {
                        obj.GetComponent<ItemActions>().CustomAction();
                        GoodAlert("Ha utilizado " + inventario.seleccionado);
                        if (inventario.inventoryList[inventario.indice].useOneTime)
                        {
                            inventario.DeleteItem();
                        }
                    }

                    else
                    {
                        if (distance < inventario.inventoryList[inventario.indice].useDistance)
                        {
                            obj.GetComponent<ItemActions>().CustomAction();
                            GoodAlert("Ha utilizado " + inventario.seleccionado);
                            if (inventario.inventoryList[inventario.indice].useOneTime)
                            {
                                inventario.DeleteItem();
                            }                            
                        }

                        else
                            BadAlert("No puede usar " + inventario.seleccionado + " aquí");
                    }
                    
                }
                else
                    BadAlert("No hay ItemActions");
            }
            else
                BadAlert("No hay objeto asociado");
        }

        

    }  

    void BadAlert(string text)
    {
        badAlert.GetComponentInChildren<Text>().text = text;
        badAlert.GetComponent<AudioSource>().Play();
        badAlert.GetComponent<Animator>().SetTrigger("set");      
        
    }

    void GoodAlert(string text)
    {
        goodAlert.GetComponentInChildren<Text>().text = text;
        goodAlert.GetComponent<AudioSource>().Play();
        goodAlert.GetComponent<Animator>().SetTrigger("set");
    }

    public void resetAlerts()
    {        
        goodAlert.GetComponent<Animator>().SetTrigger("deafult");
        badAlert.GetComponent<Animator>().SetTrigger("deafult");
    }

}
