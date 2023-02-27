using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemRecibe : MonoBehaviour
{

    string itemNameText = "";
    bool isItemFromInventory;

    Sprite miniature;

    [SerializeField] GameObject content;
    [SerializeField] GameObject item;

    AudioSource audioSource;

    GameObject obj;

    bool eliminate, playerEquip;

    string infoText;

    Sprite infoSprite;

    int indexUi;

    float useDistance;

    bool oneTimeUse;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void SetItemBox(string co, Sprite itemSprite, bool eliminable, GameObject obj, string infoText, Sprite infoSprite, bool playerEquip, int indexUi, float useDistance, bool oneTimeUse)
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
        //print("ventana de añadir item generanda correctamente");
    }

    public void SetItemBoxAndDialog(string co, Sprite itemSprite, bool eliminable, GameObject obj, string infoText, Sprite infoSprite, bool playerEquip, int indexUi, float useDistance, bool oneTimeUse)
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
        //print("ventana de añadir item generanda correctamente");        

    }

    public void AcceptItem()
    {
        GetComponent<Animator>().SetTrigger("hide");

        StartCoroutine(offWindow());

        item.GetComponent<Animator>().SetTrigger("toInventory");
        StartCoroutine(AddItemInventory());

    }

    IEnumerator AddItemInventory()
    {
        yield return new WaitForSeconds(1.2f);
        Inventory i = Inventory.Instance();
        i.AddItem(itemNameText, miniature, eliminate, obj, infoText, infoSprite, playerEquip, indexUi, useDistance, oneTimeUse);
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


}
