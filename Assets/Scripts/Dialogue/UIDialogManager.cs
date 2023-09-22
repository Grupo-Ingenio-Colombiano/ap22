using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VIDE_Data;


public class UIDialogManager : MonoBehaviour
{
    [Header("UI references")]
    [SerializeField]
    GameObject uiContainer;
    [SerializeField] GameObject helpBlocker;
    [SerializeField] GameObject playerTextParent;
    [SerializeField] GameObject scrollPlayerOpt;

    [Header("NPC")]
    [SerializeField]
    TMPro.TextMeshProUGUI npcText;
    [SerializeField] TMPro.TextMeshProUGUI npcName;
    [SerializeField] Image npcImage;
    [SerializeField] Sprite NPCBackgroundSprite;

    [Header("Player")]
    [SerializeField]
    GameObject playerText;
    [SerializeField] TMPro.TextMeshProUGUI playerNameText;
    [SerializeField] Image playerImage;
    [SerializeField] Sprite playerBackgroundSprite;

    [Header("PlayerData")]
    [SerializeField]
    Name playerName;
    [SerializeField] Gender playerGender;
    [SerializeField] Sprite playerSpriteWoman;
    [SerializeField] Sprite playerSpriteMan;
    [SerializeField] Sprite playerSpriteDarkWoman;
    [SerializeField] Sprite playerSpriteDarkMan;
    [SerializeField] PlayerCanMove canMove;

    [SerializeField] UserData userData;

    bool dialoguePaused = false;
    bool animatingText = false;

    private List<GameObject> currentOptions = new List<GameObject>();

    IEnumerator npcTextAnimator;

    private void OnEnable()
    {
        VD.LoadDialogues(); //Load all dialogues to memory so that we dont spend time doing so later

        //GameObject.FindWithTag("Player").GetComponent<PlayerDialogManager>().SetManager();
    }

    //void Start()
    //{
    //    VD.LoadDialogues(); //Load all dialogues to memory so that we dont spend time doing so later
    //}

    //Just so we know when we finished loading all dialogues, then we unsubscribe
    void OnLoadedAction()
    {
        VD.OnLoaded -= OnLoadedAction;
    }

    void OnDisable()
    {
        canMove.CanMove = true;
        //If the script gets destroyed, let's make sure we force-end the dialogue to prevent errors
        EndDialogue(VD.nodeData); //EndDialogue(null);

    }

    #region conversation State
    //This begins the conversation
    public void Begin(VIDE_Assign diagToLoad)
    {
        SetPlayerInConversation();

        npcText.text = "";
        npcName.text = "";

        VD.OnActionNode += ActionHandler;
        VD.OnNodeChange += NodeChangeAction;
        VD.OnEnd += EndDialogue;

        VD.BeginDialogue(diagToLoad); //Begins conversation, will call the first OnNodeChange
        uiContainer.SetActive(true);
        helpBlocker.SetActive(true);
    }

    //PlayerDialogManager.cs calls this one to move forward in the conversation
    public void CallNext()
    {
        //Let's not go forward if text is currently being animated, but let's speed it up.
        if (animatingText) { CutTextAnim(); ; return; }

        if (!dialoguePaused) //Only if
        {
            VD.Next(); //We call the next node and populate nodeData with new data
            return;
        }
    }

    //Unsuscribe from everything, disable UI, and end dialogue
    void EndDialogue(VD.NodeData data)
    {
        try
        {
            VD.OnActionNode -= ActionHandler;
            VD.OnNodeChange -= NodeChangeAction;
            VD.OnEnd -= EndDialogue;
            uiContainer.SetActive(false);
            helpBlocker.SetActive(false);
            VD.EndDialogue();
        }
        catch (System.Exception e)
        {
            print(e);
        }

        SetPlayerOutConversation();
    }
    #endregion

    //Input player choices and update highlight
    void Update()
    {
        //Lets just store the Node Data variable for the sake of fewer words
        //var data = VD.nodeData;

        if (VD.isActive) //Only if
        {

            var data = VD.nodeData;
            //Scroll through Player dialogue options
            if (!data.pausedAction && data.isPlayer)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (data.commentIndex < currentOptions.Count - 1)
                        data.commentIndex++;
                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (data.commentIndex > 0)
                        data.commentIndex--;
                }

                SetOptionColors(data);
            }
        }

    }

    private void SetOptionColors(VD.NodeData data)
    {
        //Color the Player options and the selected one
        for (int i = 0; i < currentOptions.Count; i++)
        {
            currentOptions[i].GetComponentInChildren<Text>().color = Color.white;

            currentOptions[i].transform.GetChild(0).GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);

            if (i == data.commentIndex)
            {
                currentOptions[i].GetComponentInChildren<Text>().color = new Color32(0x3D, 0xB4, 0x49, 0xff);
                currentOptions[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0x00, 0x10, 0x14, 0xc0);

            }
        }
    }

    #region SetConversationNode

    //We listen to OnNodeChange to update our UI with each new nodeData
    //This should happen right after calling VD.Next()
    void NodeChangeAction(VD.NodeData data)
    {
        ResetConversationUI();

        //Look for dynamic text change in extraData
        PostCheckExtraVariables(data);

        if (data.isPlayer)
        {
            SetPlayerNode(data);
        }
        else
        {
            SetNPCNode(data);
        }
    }

    private void SetNPCNode(VD.NodeData data)
    {
        SetNPCNodeSprite(data);
        npcTextAnimator = AnimateText(data);
        StartCoroutine(npcTextAnimator);
        SetNPCNameText(data);
        npcText.transform.parent.gameObject.SetActive(true);
        uiContainer.GetComponent<Image>().sprite = NPCBackgroundSprite;
    }

    private void SetNPCNameText(VD.NodeData data)
    {
        //If it has a tag, show it, otherwise show the dialogueName
        if (data.tag.Length > 0)
        {
            npcName.text = data.tag;
        }
        else
        {
            npcName.text = VD.assigned.alias;
        }
    }

    private void SetNPCNodeSprite(VD.NodeData data)
    { //Set node sprite if there's any, otherwise try to use default sprite
        if (data.sprite != null)
        {
            //For NPC sprite, we'll first check if there's any "sprite" key
            //Such key is being used to apply the sprite only when at a certain comment index             
            if (data.extraVars.ContainsKey("sprite"))
            {
                if (data.commentIndex == (int)data.extraVars["sprite"])
                {
                    npcImage.sprite = data.sprite;
                }
                else
                {
                    npcImage.sprite = VD.assigned.defaultNPCSprite; //If not there yet, set default dialogue sprite
                }
            }
            else
            {
                npcImage.sprite = data.sprite;
            }

        }
        else if (VD.assigned.defaultNPCSprite != null)
        {
            npcImage.sprite = VD.assigned.defaultNPCSprite;
        }
    }

    private void SetPlayerNode(VD.NodeData data)
    {
        SetPlayerNodeSprite(data);

        SetOptions(data.comments);

        playerText.transform.parent.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(scrollPlayerOpt.gameObject, null);

        playerTextParent.SetActive(true);

        uiContainer.GetComponent<Image>().sprite = playerBackgroundSprite;

        playerNameText.text = playerName.AssignedName;

    }

    private void SetPlayerNodeSprite(VD.NodeData data)
    {
        if (data.sprite != null)
        {
            playerImage.sprite = data.sprite;
        }
        else if (VD.assigned.defaultPlayerSprite != null)
        {
            playerImage.sprite = VD.assigned.defaultPlayerSprite;
        }

        if (userData.PlayerSelected == "1")
        {
            playerImage.sprite = playerSpriteWoman;
        }
        if (userData.PlayerSelected == "0")
        {
            playerImage.sprite = playerSpriteMan;
        }
        if (userData.PlayerSelected == "2")
        {
            playerImage.sprite = playerSpriteDarkMan;
        }
        if (userData.PlayerSelected == "3")
        {
            playerImage.sprite = playerSpriteDarkWoman;
        }
    }

    private void ResetConversationUI()
    {
        npcText.text = "";
        npcText.transform.parent.gameObject.SetActive(false);

        playerText.transform.parent.gameObject.SetActive(false);
        //playerTextParent.SetActive(false);
        playerImage.sprite = null;
        npcImage.sprite = null;
    }

    //Check to see if there's Extra Variables and if so, we do stuff
    void PostCheckExtraVariables(VD.NodeData data)
    {
        //Don't conduct extra variable actions if we are waiting on a paused action
        if (data.pausedAction) return;


        //Replaces [PLAYER_NAME] and [NAME]
        if (data.extraVars.ContainsKey("nameLookUp"))
        {
            NameLookUp(data);
        }


        return;
    }

    //This uses the returned string[] from nodeData.comments to create the UIs for each comment
    //This is for demo only, you shouldn´t instantiate/destroy so constantly
    public void SetOptions(string[] opts)
    {
        //Destroy the current options
        foreach (GameObject op in currentOptions)
        {
            Destroy(op.gameObject);
        }
        //Clean the list
        currentOptions = new List<GameObject>();
        //Create the options
        for (int i = 0; i < opts.Length; i++)
        {
            playerText.gameObject.GetComponent<OptionDialog>().index = i;   
            GameObject newOp = Instantiate(playerText.gameObject, playerText.transform.position, Quaternion.identity);
            newOp.SetActive(true);
            newOp.transform.SetParent(playerText.transform.parent, true);

            newOp.GetComponent<RectTransform>().anchoredPosition = new Vector2(222, -40f - (40 * i));
            //newOp.transform.position = playerText.transform.position;
            newOp.GetComponentInChildren<UnityEngine.UI.Text>().text = opts[i];
            currentOptions.Add(newOp);
            newOp.transform.localScale = Vector3.one;
        }
    }

    //This will replace any "[***]" with the name of the gameobject holding the VIDE_Assign
    void NameLookUp(VD.NodeData data)
    {
        if (data.comments[data.commentIndex].Contains("[NAME]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[NAME]", VD.assigned.gameObject.name);
        }

        if (data.comments[data.commentIndex].Contains("[PLAYER_NAME]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[PLAYER_NAME]", playerName.AssignedName);
        }

        ReplaceQuestData(data);

    }

    private static void ReplaceQuestData(VD.NodeData data)
    {

        if (data.comments[data.commentIndex].Contains("[H_OPERATION]"))
        {    
                data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[H_OPERATION]", QuestHistorical.Instance.CurrentOperationData.operationName);
        }

        if (data.comments[data.commentIndex].Contains("[S_OPERATION]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[S_OPERATION]", QuestSampling.Instance.CurrentOperationData.operationName);
        }

        if (data.comments[data.commentIndex].Contains("[H_UNITS]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[H_UNITS]", QuestHistorical.Instance.CurrentOperationData.requiredUnits.ToString());

       }

        if (data.comments[data.commentIndex].Contains("[S_UNITS]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[S_UNITS]", QuestSampling.Instance.CurrentOperationData.requiredUnits.ToString());
        }

        if (data.comments[data.commentIndex].Contains("[KPERCENTAGE]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[KPERCENTAGE]", QuestSampling.Instance.CurrentOperationData.K.ToString());
        }

        if (data.comments[data.commentIndex].Contains("[OPERATION_TIME]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[OPERATION_TIME]", (QuestSampling.Instance.CurrentOperationData.numMinutosMuestreo / 60f).ToString());
        }

        if (data.comments[data.commentIndex].Contains("[C_OPERATION]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[C_OPERATION]", QuestTiming.Instance.CurrentOperationData.operationName);
        }

        if (data.comments[data.commentIndex].Contains("[C_UNITS]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[C_UNITS]", QuestTiming.Instance.CurrentOperationData.requiredUnits.ToString());
        }

        if (data.comments[data.commentIndex].Contains("[K]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[K]", QuestTiming.Instance.CurrentOperationData.K.ToString());
        }

        if (data.comments[data.commentIndex].Contains("[UP]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[UP]", FormResultsManager.Instance.unidadesProdPosiblesIngresadas.ToString());
        }

        if (data.comments[data.commentIndex].Contains("[YES/NO]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[YES/NO]", FormResultsManager.Instance.canAcomplishDailyGoal.ToString());
        }

        if (data.comments[data.commentIndex].Contains("[TIME]"))
        {
            data.comments[data.commentIndex] = data.comments[data.commentIndex].Replace("[TIME]", FormResultsManager.Instance.TCTTComparison.ToString());
        }

    }

    #endregion

    #region AnimateText
    public IEnumerator AnimateText(VD.NodeData data)
    {
        animatingText = true;
        string text = data.comments[data.commentIndex];

        if (!data.isPlayer)
        {
            StringBuilder builder = new StringBuilder();
            int charIndex = 0;
            while (npcText.text != text)
            {
                try
                {
                    builder.Append(text[charIndex]);
                    charIndex++;
                    npcText.text = builder.ToString();
                }
                catch (System.Exception e)
                {
                    print(e);
                }

                yield return new WaitForSeconds(0.002f); //0.02f
            }
        }
        try
        {
            npcText.text = data.comments[data.commentIndex];
            animatingText = false;
        }
        catch (System.Exception e)
        {
            print(e);
        }
    }

    void CutTextAnim()
    {
        StopCoroutine(npcTextAnimator);
        npcText.text = VD.nodeData.comments[VD.nodeData.commentIndex]; //Now just copy full text		
        animatingText = false;
    }
    #endregion AnimateText

    #region playerState

    private void SetPlayerInConversation()
    {
        canMove.CanMove = false;

        //print("test");
        if (Camera.main.GetComponentInParent<FollowCameraController>().IsThirdPerson)
        {
            Camera.main.GetComponentInParent<FollowCameraController>().ToggleCamera();
        }



    }

    private void SetPlayerOutConversation()
    {
        canMove.CanMove = true;

        try
        {
            if (Camera.main.GetComponentInParent<FollowCameraController>().IsThirdPerson == false)
            {
                Camera.main.GetComponentInParent<FollowCameraController>().ToggleCamera();
            }
        }
        catch (Exception e)
        {

        }

    }

    #endregion

    //as Action Nodes have predefined actions that allow you to easily modify the start point in the VIDE Editor.
    public void SetOverrideStartNode(int newNode)
    {
        if (VD.isActive)
        {
            VD.assigned.overrideStartNode = newNode;
        }
    }

    //as Action Nodes have predefined actions that allow you to easily modify go to another node
    public void GoToNode(int newNode)
    {
        if (VD.isActive)
        {
            VD.SetNode(newNode);
        }
    }

    //Another way to handle Action Nodes is to listen to the OnActionNode event, which sends the ID of the action node
    void ActionHandler(int actionNodeID)
    {
        //print("ACTION TRIGGERED: " + actionNodeID.ToString());
    }

    public void Talk()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerDialogManager>().TryInteract();
    }

}