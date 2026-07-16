using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemRecibe : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField] private GetItemAndDialog[] itemsToGive;
    [SerializeField] private Sprite allItemsSprite;
    string itemNameText = "";
    bool isItemFromInventory;

    Sprite miniature;
    [SerializeField] int miniatureInt;

    [SerializeField] GameObject content;
    [SerializeField] GameObject item;

    [SerializeField] UserData data;

    AudioSource audioSource;

    GameObject obj;
    [SerializeField] int objInt;
    [SerializeField] Button button;
    public GameObject[] empty;
    bool eliminate, playerEquip;

    public int numInv = 0;

    string infoText;

    Sprite infoSprite;
    [SerializeField] int infoSpriteInt;

    int indexUi;

    float useDistance;

    bool oneTimeUse;

    [SerializeField] GameObject buttonInvent; private bool getAllInventoryItems = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (data.load >= 1)
        {
            for (int i = 0; i < data.numInventario; i++)
            {
                empty[i].SetActive(false);
            }
        }
    }

    [ContextMenu("Get All Items")]
    public void GetAllItems()
    {
        SetItemBoxForAllItems();
        //StartCoroutine("AddAllItemsItemInventory");
    }

    public void SetItemBoxForAllItems()
    {
        //print("generando ventana de añadir item");        
        audioSource.Play();
        gameObject.GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().SetTrigger("show");
        item.GetComponent<Animator>().SetTrigger("create");
        content.GetComponent<Text>().text = "Elementos de seguridad.";
        item.GetComponent<Image>().sprite = allItemsSprite;
        getAllInventoryItems = true;
    }

    IEnumerator AddAllItemsItemInventory()
    {
        yield return new WaitForSeconds(1.2f);
        Inventory inventory = Inventory.Instance();
        for (int i = 0; i < itemsToGive.Length; i++)
        {
            inventory.AddItemTest(itemsToGive[i].objectName,
            itemsToGive[i].ord,
            itemsToGive[i].eliminable,
            itemsToGive[i].ord, itemsToGive[i].infoText,
            itemsToGive[i].ord,
            itemsToGive[i].playerEquip,
            itemsToGive[i].otherUi,
            itemsToGive[i].useDistance,
            itemsToGive[i].oneTimeUse);


            empty[i].SetActive(false);
        }
        button.enabled = true;
        item.SetActive(true);
        inventory.UpdateInventory();
    }


    public void SetItemBox(string co, Sprite itemSprite, bool eliminable, GameObject obj, string infoText, Sprite infoSprite, bool playerEquip, int indexUi, float useDistance, bool oneTimeUse, int orden)
    {
        //print("generando ventana de añadir item");        
        audioSource.Play();
        gameObject.GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().SetTrigger("show");
        item.GetComponent<Animator>().SetTrigger("create");
        itemNameText = co;
        miniature = itemSprite;
        content.GetComponent<Text>().text = itemNameText;
        item.GetComponent<Image>().sprite = itemSprite;
        this.obj = obj;
        this.infoText = infoText;
        this.infoSprite = infoSprite;
        this.playerEquip = playerEquip;
        this.indexUi = indexUi;
        this.useDistance = useDistance;
        this.oneTimeUse = oneTimeUse;
        eliminate = eliminable;


        this.miniatureInt = orden;
        this.objInt = orden;
        this.infoSpriteInt = orden;
        //print("ventana de añadir item generanda correctamente");
    }

    public void SetItemBoxAndDialog(string co, Sprite itemSprite, bool eliminable, GameObject obj, string infoText, Sprite infoSprite, bool playerEquip, int indexUi, float useDistance, bool oneTimeUse, int orden)
    {
        //print("generando ventana de añadir item");        
        audioSource.Play();
        gameObject.GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().SetTrigger("show");
        item.GetComponent<Animator>().SetTrigger("create");
        itemNameText = co;
        miniature = itemSprite;
        content.GetComponent<Text>().text = itemNameText;
        item.GetComponent<Image>().sprite = itemSprite;
        this.obj = obj;
        this.infoText = infoText;
        this.infoSprite = infoSprite;
        this.playerEquip = playerEquip;
        this.indexUi = indexUi;
        this.useDistance = useDistance;
        this.oneTimeUse = oneTimeUse;
        eliminate = eliminable;

        this.miniatureInt = orden;
        this.objInt = orden;
        this.infoSpriteInt = orden;


        //print("ventana de añadir item generanda correctamente");        

    }

    public void AcceptItem()
    {
        GetComponent<Animator>().SetTrigger("hide");
        var sequence = DOTween.Sequence();


        StartCoroutine(offWindow());
        empty[numInv].SetActive(false);
        print(numInv + " inventario");
        item.SetActive(false);
        sequence.Append(buttonInvent.transform.DOScale(1.7f, 0.4f));
        sequence.OnComplete(() =>
        {
            buttonInvent.transform.DOScale(1, 1);
        });

        if (!getAllInventoryItems)
        {
            StartCoroutine(AddItemInventory());
        }
        else
        {
            StartCoroutine(AddAllItemsItemInventory());
        }
        button.enabled = false;

        numInv++;
        data.numInventario = numInv;
    }

    IEnumerator AddItemInventory()
    {

        yield return new WaitForSeconds(1.2f);
        Inventory i = Inventory.Instance();

        i.AddItemTest(itemNameText, miniatureInt, eliminate, objInt, infoText, infoSpriteInt, playerEquip, indexUi, useDistance, oneTimeUse);
        button.enabled = true;
        item.SetActive(true);
    }

    IEnumerator offWindow()
    {
        yield return new WaitForSeconds(1.3f);
        gameObject.GetComponent<Canvas>().enabled = false;

        if (GameObject.FindWithTag("TextContainer"))
        {
            var dialogManager = FindObjectOfType(typeof(UIDialogManager)) as UIDialogManager;
            dialogManager.CallNext();


        }


    }

    public void OnBeforeSerialize()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && miniature != null && infoSprite != null)
        {
            spriteRenderer.sprite = miniature;
            spriteRenderer2.sprite = infoSprite;
        }

    }

    public void OnAfterDeserialize()
    {
        //throw new System.NotImplementedException();
    }
}
