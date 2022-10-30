using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class DialogueUI : UITemplate
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject characterDialogueBox;
    [SerializeField] private TMP_Text defaultText;
    private TMP_Text textLabel;

   // public bool IsOpen { get {return IsOpen;} private set{IsOpen = value;  uIT.isOpen = value;} }

    [SerializeField] private GameObject specialDialogueBox;
    private ResponseHandler responseHandler;
    private TypewriterEffect typewritterEffect;
    public bool specialBox=false;
    private bool forceContinue = false;
    private bool forceStay = false;
    //[SerializeField] InfoRemember infoGet;
    //[SerializeField] SoundManager soundManager;
    private CharacterTalking currentTalking; 
    private UITemplate uIT;

    //Added for cutscene use
    private bool firstRun = true;
    private bool hasNextDialogue = false;
    public event Action OnDialogueEnd;

    public void ForceContiue()
    {
        forceContinue = true;
    }
    public void ForceStay()
    {
        forceStay = true;
    }
    protected override void OpenUIInternal()
    {
        Debug.Log("Don't open DialogueUI like this >:( Use ShowDialogue!"); return;
    }

    protected override void Awake()
    {
        base.Awake();

        GlobalReferences.Dialogueui = this;
    }

    private void Start()
    {
        textLabel=defaultText;
        typewritterEffect=GetComponent<TypewriterEffect>();
        responseHandler=GetComponent<ResponseHandler>();
        CloseUI();
    }
    public void nextSpecial(){
        specialBox = true;
    }
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        if (specialBox) {
            ShowSpecialDialogue(dialogueObject);
            return;
        }
        IsOpen = true; 
        dialogueBox.SetActive(true);
        textLabel.text=string.Empty;
        textLabel=defaultText;
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    public void ShowSpecialDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true; 
        dialogueBox.SetActive(true);
        textLabel.text=string.Empty;
        specialDialogueBox.SetActive(true);
        textLabel=specialDialogueBox.GetComponentInChildren<TMP_Text>();
        specialBox=true;
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    private void SetSpecialDialogue()
    {
        specialDialogueBox.SetActive(true);
        textLabel = specialDialogueBox.GetComponentInChildren<TMP_Text>();
        specialBox=true;
    }
    // When a dialogue box with a character that has expressions is being shown, it runs this code so the
    // Specical character dialogue box is shown
    private void SetCharacterBox(DialogueTextData givenData){
        characterDialogueBox.GetComponentInChildren<ExpressionDialogueSprite>().changeExpression(givenData.CharSpeaking, givenData.CharExprssion);
         characterDialogueBox.SetActive(true);
         textLabel = characterDialogueBox.GetComponentInChildren<TMP_Text>();
    }
    // Might remove this code
    private string checkForInfo(string dialogue){
        // Checks to find % % 
        int firstIndex=-1;
        int secondIndex=-1;
        for (int i = 0; i < dialogue.Length; i++)
        {
            if (System.String.Equals(dialogue[i],'%'))
            {
                if (firstIndex!=-1) {
                    secondIndex = i;
                    break;
                }
                else firstIndex = i; 
            }
        }
        if (secondIndex==-1) return dialogue;
        // Unsure how to make a better way of injecting the players name into the code
        if (dialogue.Substring(firstIndex + 1,secondIndex-firstIndex-1 ).Equals("PlayerName"))
        {
            //dialogue=dialogue.Substring(0,firstIndex) + infoGet.playerName + dialogue.Substring(secondIndex+1,dialogue.Length-secondIndex-1);
        }
        else if (dialogue.Substring(firstIndex+1,2).Equals("SE"))
        {
            //soundManager.PlaySound(int.Parse(dialogue.Substring(firstIndex + 3, secondIndex-firstIndex-3)));
            dialogue=dialogue.Substring(0,firstIndex) + dialogue.Substring(secondIndex+1,dialogue.Length-secondIndex-1);
        }
        return dialogue;
    }
    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }
    public void AddResponseEvents(ResponseEvent[][] responseEvents)
    {
        responseHandler.AddResponseEventsList(responseEvents);
    }

    public IEnumerator InTheLoop(DialogueObject dialogueObject)
    {
        ShowDialogue(dialogueObject);
        StepThroughDialogue(dialogueObject);
        yield return null;
    }
    private IEnumerator StepThroughDialogue(DialogueObject givenDialogueObject)
    {
        DialogueObject dialogueObject =givenDialogueObject;
        for (int i = 0; i < dialogueObject.DialogueData.Length; i++)
        {
            DialogueTextData dialogueStuff = dialogueObject.DialogueData[i];
            // Assume all dialogue is default dialogue until proven otherwise
            // All of this is setting things up to default
            textLabel.text = string.Empty;
            currentTalking = dialogueStuff.CharSpeaking;
            if (characterDialogueBox != null)  characterDialogueBox.SetActive(false);
            textLabel = defaultText;
            //if (dialogueObject.IsSpecialDialogue) SetSpecialDialogue();
            //else if (dialogueStuff.CharSpeaking == CharacterTalking.Leo) SetCharacterBox(dialogueStuff);
            if (!dialogueStuff.CharSpeaking.Equals(CharacterTalking.None)) SetCharacterBox(dialogueStuff);
            string dialogue = dialogueStuff.DialogueText;
            // This runs the typing effect on the screen
            yield return RunTypingEffect(dialogue);
            textLabel.text = dialogue;
            if (i == dialogueObject.Dialogue.Length-1 && (dialogueObject.HasResponses && responseHandler.CheckValidResponses(dialogueObject.Responses))) break;
            yield return null;
            // Might clean this up
            if (!forceContinue)
            {
                if (forceStay)
                {
                    // If we are forcing the dialogue to stay on screen, we have to wait till forceContinue is set to true
                    yield return new WaitUntil(() => forceContinue);
                    forceStay = false;
                }
                else yield return new WaitUntil(() => forceContinue||Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0));
            }
            forceContinue = false;
        }
        if (dialogueObject.HasResponses)
        {
            SendResponses(dialogueObject);
        }
        else
        {
            //Added for cutscene use
            hasNextDialogue = dialogueObject.HasNextDialogue;

            CloseUI();
        }
        if (specialBox) specialDialogueBox.SetActive(false);
        specialBox = false;
        if (dialogueObject.HasNextDialogue) ShowDialogue(dialogueObject.NextDialgoue);  
    }
    private void SendResponses(DialogueObject dialogueObject){
//DTag
        Response[] responses = dialogueObject.Responses;
        foreach (Response response in responses)
        {
            response.DTag = dialogueObject.name;
        }
        responseHandler.ShowResponses(responses);
    }
    private IEnumerator RunTypingEffect(string dialogue)
    {   
        typewritterEffect.Run(dialogue, textLabel, currentTalking);
        while (typewritterEffect.IsRunning){
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                typewritterEffect.Stop();
            }
        }
    }
    protected override void CloseUIInternal(){
        IsOpen = false;
        if (characterDialogueBox!=null)  characterDialogueBox.SetActive(false);
        dialogueBox.SetActive(false);
        defaultText.text=string.Empty;
        textLabel.text=string.Empty;
        if (characterDialogueBox!=null)  characterDialogueBox.GetComponentInChildren<TMP_Text>().text=string.Empty;

        //Added for cutscene use
        if (firstRun)
            firstRun = false;
        else
        {
            if(!hasNextDialogue)
                OnDialogueEnd?.Invoke();
        }
    }
}
