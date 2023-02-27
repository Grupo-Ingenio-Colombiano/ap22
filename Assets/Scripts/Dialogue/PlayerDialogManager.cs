using System;
using UnityEngine;
using VIDE_Data;


public class PlayerDialogManager : MonoBehaviour
{
    private const float PLAYER_OFFSET = 0.8f;

    UIDialogManager diagUI;

    public static PlayerDialogManager Instance;

    public static Action OnTalkAvailable = delegate { };
    public static Action OnTalkNotAvailable = delegate { };


    [SerializeField] float distanceToTalk = 10f;
    [SerializeField] bool talkWithKeyboardEnabled;
    [SerializeField] PlayerTalking playerTalking;


    LayerMask layerToTalk;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        layerToTalk = 1 << 9;
    }

    private void OnEnable()
    {
        SetManager();
    }

    public void SetManager()
    {
        if (GameObject.FindWithTag("DialogManager"))
        {
            diagUI = GameObject.FindWithTag("DialogManager").GetComponent<UIDialogManager>();
        }
        else
        {
            if (Debug.isDebugBuild)
            {
                Debug.LogWarning("No se ha encontrado interfaz de dialogos, asegurese de colocar una en la escena");
            }
        }
    }

    void Update()
    {
        RaycastHit talkHit;

        if (Physics.Raycast(transform.position + new Vector3(0, PLAYER_OFFSET, 0), transform.forward, out talkHit, distanceToTalk, layerToTalk) && !IsPlayerMoving() && playerTalking.CanTalk)
        //if (Physics.Raycast(transform.position + new Vector3(0, PLAYER_OFFSET, 0), transform.forward, out talkHit, distanceToTalk, talkableLayer) && !IsPlayerMoving() && playerTalking.CanTalk)
        {
            //print("raycast");
            if (talkHit.collider.GetComponent<VIDE_Assign>() != null)
            {
                //print("vide");
                OnTalkAvailable();
            }
            else
            {
                //print("no vide");               
                OnTalkNotAvailable();
            }
        }
        else
        {
            OnTalkNotAvailable();
        }

        if (talkWithKeyboardEnabled)
        {
            if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.Return))
            {
                TryInteract();
            }
        }
    }

    //Casts a ray to see if we hit an NPC and, if so, we interact
    public void TryInteract()
    {
        RaycastHit rHit;

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out rHit, distanceToTalk, layerToTalk) && !IsPlayerMoving())
        {

            VIDE_Assign assigned;
            if (rHit.collider.GetComponent<VIDE_Assign>() != null)
            {
                assigned = rHit.collider.GetComponent<VIDE_Assign>();
                //print(rHit.collider.gameObject.name);
                rHit.collider.gameObject.transform.LookAt(new Vector3(transform.position.x, rHit.collider.gameObject.transform.position.y, transform.position.z));
                rHit.collider.gameObject.GetComponentInChildren<InteractionIndicator>().SetIndicatorAnim(false);
                rHit.collider.gameObject.GetComponentInChildren<InteractionIndicator>().TriggerIdle();
            }
            else
            {
                return;
            }

            if (!VD.isActive)
            {
                diagUI.Begin(assigned);
            }
            else
            {
                diagUI.CallNext();
            }

        }
    }

    public static bool IsPlayerMoving()
    {
        return Input.GetAxis("Horizontal") > Mathf.Epsilon || Input.GetAxis("Vertical") > Mathf.Epsilon || Input.GetAxis("Horizontal") < -Mathf.Epsilon || Input.GetAxis("Vertical") < -Mathf.Epsilon;
    }

}