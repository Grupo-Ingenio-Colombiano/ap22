﻿using DG.Tweening;
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

    [SerializeField]
    UserData userData;




    public string objectName;

    public string textContent;

    public Sprite imgSprite;

    public int spriteInt;

    public GameObject objectAction;

    public int objectActionInt;

    public bool eliminable;

    public string infoText;

    public Sprite infosprite;

    public int infospriteInt;

    public bool equip;

    public int canvasInfo;

    public float useDistance;

    public bool oneTimeUse;


    public int numInventario;

    [SerializeField] ItemRecibe itemRecibe;
    [SerializeField] GameObject buttonInvent;

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
        var sequence = DOTween.Sequence();
        sequence.Append(buttonInvent.transform.DOScale(1.7f, 0.4f));
        sequence.OnComplete(() =>
        {
            buttonInvent.transform.DOScale(1, 1);
        });
        Invoke("SetItemToInventory", 1.5f);
        itemRecibe.numInv = numInventario + 1;
        userData.numInventario = itemRecibe.numInv;
        print("invent " + numInventario);
        itemRecibe.empty[numInventario].SetActive(false);
        PlayerDataManager.Instance.AddProgress(5);
    }

    public void SetItemToInventory()
    {
        PutItemOnInventory(objectName, spriteInt, objectActionInt);
     
    }

    void PutItemOnInventory(string name, int img, int action)
    {
        prizeCanvas.enabled = false;
        inventario.AddItemTest(name, img, eliminable, action, infoText, infospriteInt, equip, 0, useDistance, oneTimeUse);
        gameObject.SetActive(false);
    }

    
}
