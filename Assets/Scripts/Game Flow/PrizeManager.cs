using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeManager : MonoBehaviour
{
    [SerializeField]
    Canvas prizeCanvas;

    [SerializeField]
    Image premio;

    [SerializeField]
    Text contenido;

    [SerializeField]
    Animator anim;

    [SerializeField]
    Inventory inventario;

    [SerializeField]
    Button acept;

    [SerializeField]
    AudioSource sound;   

    public string objectName;

    public string textContent;

    public Sprite imgSprite;

    public GameObject objectAction;

    public bool eliminable;

    public string infoText;

    public Sprite infosprite;

    public bool equip;

    public int canvasInfo;

    public float useDistance;

    public bool oneTimeUse;

    private void OnEnable()
    {
        prizeCanvas.enabled = true;
        premio.sprite = imgSprite;
        contenido.text = textContent;
        anim.SetTrigger("in");
        acept.interactable = true;
        sound.Play();        
    }

    public void SendItemToInventory()
    {
        acept.interactable = false;
        anim.SetTrigger("out");
        Invoke("SetItemToInventory", 1.5f);
        PlayerDataManager.Instance.AddExperience(30);
        PlayerDataManager.Instance.AddProgress(5);
    }

    public void SetItemToInventory()
    {
        PutItemOnInventory(objectName, imgSprite, objectAction);
    }

    void PutItemOnInventory(string name, Sprite img, GameObject action)
    {
        prizeCanvas.enabled = false;
        inventario.AddItem(name, img, eliminable, action, infoText, infosprite, equip, 0, useDistance, oneTimeUse);
        gameObject.SetActive(false);
    }

    
}
