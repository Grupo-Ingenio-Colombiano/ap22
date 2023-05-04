using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //referencia al singleton
    private static Inventory inventario;

    //numero de casillas que tendra en inventario

    static public int casillas_inventario = 12;

    //item seleccionado

    public string seleccionado = "";

    //sonidos

    public AudioClip[] sounds;

    //texto descriptivo
    public Text topName;

    //transforms cuadros top name y buttons

    public Transform topBox;

    public Transform buttonsBox;

    //buttons interactables lista de botones

    public Button usar;

    public Button ver;

    public Button eliminar;

    public Button retirar;

    bool use, see, eliminate;

    public bool[] buttonsState;

    //___________________ listas y arreglos  para el inventario___________________

    public List<Item> inventoryList = new List<Item>();

    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();

    [SerializeField] SpritesManager spritesManager;

    public GameObject[] posiciones;

    InventoryItem inventoryItem;   


    //sprites para actualizar el inventario

    public Sprite vacio;

    [SerializeField] UserData userData;

    //indice     

    public int indice;

    public Text inventario_lleno;

    public GameObject indicador;

    //ventana info

    public GameObject infoWindow;

    public GameObject generalInfo;

    InventoryUseActions useActions;

    [SerializeField] LoadManager loadManager;

    [SerializeField] GameObject[] empty;
    private void Start()
    {
        indice = casillas_inventario + 1;
        useActions = FindObjectOfType(typeof(InventoryUseActions)) as InventoryUseActions;       
        if (userData.isSave != false)
        {
            for (int i = 0; i < userData.inventory.Count; i++)
            {
              
                AddItemTest(userData.inventory[i].itemName, userData.inventory[i].sprite, userData.inventory[i].eliminable, userData.inventory[i].obj,
                            userData.inventory[i].infotext, userData.inventory[i].infoSprite, userData.inventory[i].playerEquip,
                            userData.inventory[i].indexUi, userData.inventory[i].useDistance, userData.inventory[i].useOneTime);
               
            }
           
            Debug.Log(userData.inventory.Count);
        }
     
    }

    public static Inventory Instance()
    {
        inventario = FindObjectOfType(typeof(Inventory)) as Inventory;

        return inventario;
    }

    public void DeleteItem()
    {
        inventoryList.RemoveAt(indice);
        indice = casillas_inventario + 1;
        seleccionado = "";
        posiciones[inventoryList.Count].GetComponent<Image>().sprite = vacio;
        posiciones[inventoryList.Count].GetComponent<Button>().interactable = false;
        posiciones[inventoryList.Count].GetComponent<Image>().color = Color.white;
      
        UpdateInventory();
    }



    public bool AddItem(string name, Sprite img, bool eliminable, GameObject obj, string infoText, Sprite infoSprite, bool playerEquip, int indexUi, float useDistance, bool oneTimeUse)
    {

        if (inventoryList.Count < casillas_inventario)
        {
            var item = new Item { itemName = name, sprite = img, eliminable = eliminable, obj = obj, infotext = infoText, infoSprite = infoSprite, playerEquip = playerEquip, isNowEquiped = false, indexUi = indexUi, useDistance = useDistance, useOneTime = oneTimeUse };

            //data.inventory = item;

            inventoryList.Add(item);
            empty[indexUi].SetActive(false);

            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(sounds[1]);
            }
            UpdateInventory();
            return true;
        }

        else
        {
            print("Inventario lleno");
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(sounds[0]);
            }
            UpdateInventory();
            return false;
        }

    }

    public bool AddItemTest(string name, int img, bool eliminable, int obj, string infoText, int infoSprite, bool playerEquip, int indexUi, float useDistance, bool oneTimeUse)
    {
      
        if (inventoryList.Count < casillas_inventario)
        {
            var data = new InventoryItem
            {
                itemName = name,
                sprite = img,
                eliminable = eliminable,
                obj = obj,
                infotext = infoText,
                infoSprite = infoSprite,
                playerEquip = playerEquip,
                isNowEquiped = false,
                indexUi = indexUi,
                useDistance = useDistance,
                useOneTime = oneTimeUse
            };
            if(userData.inventory.Count <= inventoryList.Count)
            {
                userData.inventory.Add(data);
            }


            switch (img)
            {
                case 0:
                    var item0 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.cronometro,
                        eliminable = eliminable,
                        obj = spritesManager.cronometroObject,
                        infotext = infoText,
                        infoSprite = spritesManager.infoCronometro,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse

                    };
                    empty[0].SetActive(false);
                    inventoryList.Add(item0);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;
                case 1:
                    var item = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.prizeC,
                        eliminable = eliminable,
                        obj = spritesManager.prizeCObject,
                        infotext = infoText,
                        infoSprite = spritesManager.infoPrizeC,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[1].SetActive(false);
                    inventoryList.Add(item);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 2:
                    var item2 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.helmet,
                        eliminable = eliminable,
                        obj = spritesManager.emptyObject,
                        infotext = infoText,
                        infoSprite = spritesManager.emptySprite,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[2].SetActive(false);
                    inventoryList.Add(item2);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 3:
                    var item3 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.boots,
                        eliminable = eliminable,
                        obj = spritesManager.emptyObject,
                        infotext = infoText,
                        infoSprite = spritesManager.emptySprite,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[3].SetActive(false);
                    inventoryList.Add(item3);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 4:
                    var item4 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.mask,
                        eliminable = eliminable,
                        obj = spritesManager.emptyObject,
                        infotext = infoText,
                        infoSprite = spritesManager.emptySprite,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[4].SetActive(false);
                    inventoryList.Add(item4);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 5:
                    var item5 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.gloves,
                        eliminable = eliminable,
                        obj = spritesManager.emptyObject,
                        infotext = infoText,
                        infoSprite = spritesManager.emptySprite,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[5].SetActive(false);
                    inventoryList.Add(item5);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 6:
                    var item6 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.overol,
                        eliminable = eliminable,
                        obj = spritesManager.emptyObject,
                        infotext = infoText,
                        infoSprite = spritesManager.emptySprite,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[6].SetActive(false);
                    inventoryList.Add(item6);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 7:
                    var item7 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.tapaOidos,
                        eliminable = eliminable,
                        obj = spritesManager.emptyObject,
                        infotext = infoText,
                        infoSprite = spritesManager.emptySprite,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[7].SetActive(false);
                    inventoryList.Add(item7);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 8:
                    var item8 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.glass,
                        eliminable = eliminable,
                        obj = spritesManager.emptyObject,
                        infotext = infoText,
                        infoSprite = spritesManager.emptySprite,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[8].SetActive(false);
                    inventoryList.Add(item8);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 9:
                    var item9 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.prizeD,
                        eliminable = eliminable,
                        obj = spritesManager.prizeDObject,
                        infotext = infoText,
                        infoSprite = spritesManager.infoPrizeD,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[9].SetActive(false);
                    inventoryList.Add(item9);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 10:
                    var item10 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.prizeI,
                        eliminable = eliminable,
                        obj = spritesManager.prizeIObject,
                        infotext = infoText,
                        infoSprite = spritesManager.infoPrizeI,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[10].SetActive(false);
                    inventoryList.Add(item10);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;

                case 11:
                    var item11 = new Item
                    {
                        itemName = name,
                        sprite = spritesManager.prizeO,
                        eliminable = eliminable,
                        obj = spritesManager.prizeOObject,
                        infotext = infoText,
                        infoSprite = spritesManager.infoPrizeO,
                        playerEquip = playerEquip,
                        isNowEquiped = false,
                        indexUi = indexUi,
                        useDistance = useDistance,
                        useOneTime = oneTimeUse
                    };
                    empty[11].SetActive(false);
                    inventoryList.Add(item11);

                    if (GetComponent<AudioSource>())
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
                    }
                    UpdateInventory();
                    return true;
                    break;
                default:
                    return true;
                    break;
            }
            if(userData.load <= 1 && name == "Virtualina")
            {
              
                    loadManager.Upload(1);
                
            }
          
        }

        else
        {
            print("Inventario lleno");
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(sounds[0]);
            }
            UpdateInventory();
            return false;
        }

    }




    public void OpenInventory()
    {
        UpdateInventory();
        gameObject.GetComponent<Animator>().SetBool("activo", !(gameObject.GetComponent<Animator>().GetBool("activo")));
        //indicador.GetComponent<Animator>().SetBool("A", !indicador.GetComponent<Animator>().GetBool("A"));

        if (gameObject.GetComponent<Animator>().GetBool("activo"))
        {
            for (int i = 0; i < inventoryList.Count; i++)
            {
                posiciones[i].GetComponent<Image>().color = Color.white;

            }
        }

    }

    public void CloseInventory()
    {
        gameObject.GetComponent<Animator>().SetBool("activo", false);
    }


    public void UpdateInventory()
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            posiciones[i].GetComponent<Image>().sprite = inventoryList[i].sprite;
        }

        for (int i = 0; i < posiciones.Length; i++)
        {

            if (!posiciones[i].GetComponent<Image>().sprite)
            {
                posiciones[i].GetComponent<Button>().interactable = false;
                posiciones[i].GetComponent<Image>().sprite = vacio;
                posiciones[i].GetComponent<Image>().color = Color.white;
            }

            else if (posiciones[i].GetComponent<Image>().sprite && posiciones[i].GetComponent<Image>().sprite != vacio)
            {
                posiciones[i].GetComponent<Button>().interactable = true;
            }

        }

        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (i == indice)
            {
                posiciones[i].GetComponent<Image>().color = Color.yellow;
            }

            else
            {
                posiciones[i].GetComponent<Image>().color = Color.white;
            }
        }


        if (inventoryList.Count >= casillas_inventario)

        {
            inventario_lleno.text = "Lleno";
        }

        else
        {
            inventario_lleno.text = "Inventario";
        }

        if (!gameObject.GetComponent<Animator>().GetBool("activo"))
        {
            indice = 10;
            seleccionado = "";
        }

        if (seleccionado != "")
        {
            CancelInvoke();
        }

        topName.text = seleccionado;


        if (seleccionado.Equals(""))
        {
            buttonsBox.localScale = new Vector3(0, 0, 0);
            topBox.localScale = new Vector3(0, 0, 0);
        }

        else
        {
            buttonsBox.localScale = new Vector3(1, 1, 1);
            topBox.localScale = new Vector3(1, 1, 1);


            if (inventoryList[indice].obj || inventoryList[indice].playerEquip)
            {
                if (inventoryList[indice].playerEquip)
                {
                    if (inventoryList[indice].isNowEquiped)
                    {
                        retirar.gameObject.SetActive(true);
                        usar.gameObject.SetActive(false);
                    }
                    else
                    {
                        retirar.gameObject.SetActive(false);
                        usar.gameObject.SetActive(true);
                        usar.interactable = true;
                    }

                }
                else
                {
                    usar.gameObject.SetActive(true);
                    retirar.gameObject.SetActive(false);
                    usar.interactable = true;
                }

            }

            else
            {
                usar.gameObject.SetActive(true);
                usar.interactable = false;
                retirar.gameObject.SetActive(false);
            }


            if (inventoryList[indice].indexUi == 0)
                ver.interactable = false;
            else
                ver.interactable = true;

            eliminar.interactable = inventoryList[indice].eliminable;

        }
    }

    public void playError()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[0]);
    }

    public void playpress()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[2]);
    }

    public void ResetAlerts()
    {
        useActions.resetAlerts();
    }

    public int FindIndexItem(string name)
    {
        var index = 0;

        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemName.Equals(name))
            {
                index = i;
                
                return index;
            }
        }
        
        return casillas_inventario+1;
    }

}


public class Item
{
    public string itemName;
    public Sprite sprite;
    public bool  eliminable;
    public GameObject obj;
    public string infotext;
    public Sprite infoSprite;
    public bool playerEquip;
    public bool isNowEquiped;
    public int indexUi;
    public float useDistance;
    public bool useOneTime;

}
