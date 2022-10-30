using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConsentCutscene : MonoBehaviour
{
    [SerializeField] DialogueUI dialogueUI;
    [SerializeField] InfoEnter infoEnter;
    [SerializeField] GameObject dialogueStuff;
    [SerializeField] InfoRemember rememberInfo;
    [SerializeField] DialogueObject failedAge;
    [SerializeField] DialogueObject goodAge;
    [SerializeField] UnityEvent endingEvents;
    [SerializeField] LoadBar loadBar;
    [SerializeField] GameObject whiteScreen;
    public bool failedConsent = false;
    public bool hasEnded = false;
    private string currentState="default";
    public void HasEnded()
    {
        hasEnded = true;
    }
    public void enterInfo()
    {
        infoEnter.OpenScreen();
        currentState="info";
        dialogueUI.ForceStay();
    }
    public void hasFailed()
    {
        failedConsent=true;
    }
    void Start()
    {
        loadBar.startBar();
        currentState="load";
        
    }
    void Update()
    {
        
        if (whiteScreen.activeSelf) StartCoroutine(waitOneStep());
        if (currentState.Equals("load") && loadBar.isDone)  
        {
            dialogueStuff.GetComponentInChildren<DialogueActivator>().Interact(dialogueUI);
            currentState="default";
            loadBar.closeBar();
        }
        //if (Input.GetKeyDown(KeyCode.Tab)) hasEnded=true;
        if (currentState.Equals("default") && !dialogueUI.IsOpen)
        {
            
            if (failedConsent) { Debug.Log("Quitting..."); Application.Quit();}
            else{
                // This is such a stupid fix for this problem
                // Problem -> Events won't trigger for dialogue deeper than the inital one given to activator, fix?
                // Change the dialogue in the activator, wait till the dialogue ends, and start the dialogue again
                // Its clunky af but it works
                if (!hasEnded)
                {
                    dialogueStuff.GetComponentInChildren<DialogueActivator>().Interact(dialogueUI);
                    
                }
                else{
                    currentState="done";
                    endingEvents.Invoke();}
            }
        }
        if (currentState.Equals("playNext")) {
            if (!failedConsent) dialogueUI.ShowDialogue(goodAge);
            else dialogueUI.ShowDialogue(failedAge);
            currentState="default";
        }
        if (currentState.Equals("info") && !infoEnter.IsOpen) 
        {
            //int age;
            int.TryParse(infoEnter.infoStringList[infoEnter.infoStringList.Count-1], out int age);
            currentState="default";
            dialogueUI.ForceContiue();
            if (age < 13) {
                failedConsent = true;
                //dialogueUI.ShowDialogue(failedAge);
                //return;
            }
            currentState="playNext";
            rememberInfo.playerName=infoEnter.infoStringList[0];
            //dialogueStuff.GetComponentInChildren<DialogueActivator>().UpdateDialogueObject(goodAge);
            //dialogueUI.ShowDialogue(goodAge);
        }
    }
    private IEnumerator waitOneStep()
    {
        yield return null;
        yield return null;
        whiteScreen.SetActive(false);
    }
}
