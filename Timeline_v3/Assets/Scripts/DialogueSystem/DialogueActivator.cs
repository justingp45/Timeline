using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    } 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement PlayerMovement))
        {
            PlayerMovement.Interactable = this;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement PlayerMovement))
        {
            if(PlayerMovement.Interactable is DialogueActivator dialogueActivator && (bool)dialogueActivator ==this)
            {
                if (PlayerMovement.Interactable.Equals(this))
                    PlayerMovement.Interactable = null;
            }
        }
    }
    public void Interact(PlayerMovement PlayerMovement)
    {
       Interact(PlayerMovement.mainUI);
    }
    public void Interact(DialogueUI dialogueUI)
    {
        CheckforItem();
        ResponseEvent[][] temp = CompileResponseEvents();
        dialogueUI.AddResponseEvents(temp);
        dialogueUI.ShowDialogue(dialogueObject);
    }
    public void Interact(UICaller mainUI)
    {
        CheckforItem();
        ResponseEvent[][] temp = CompileResponseEvents();
        //mainUI.AddResponseEvents(compResponseEvents);
        mainUI.CallShowDialogue(dialogueObject, temp);
    }
    private void CheckforItem()
    {
        // Checks to see if the inventory has an item that is required. If it does, it updates the dialogue object
        DialogueItemCheck itemCheck = GetComponent<DialogueItemCheck>();
        if (itemCheck != null)
            foreach (DialogueItem itemsToCheck in itemCheck.DialogueItemList)
            {
                if (itemCheck.inventory.HasItem(itemsToCheck.RequiredItem)) 
                    UpdateDialogueObject(itemsToCheck.Dialogue);
            }
    }
    private ResponseEvent[][] CompileResponseEvents()
    {
        ResponseEvent[][] compResponseEvents = new ResponseEvent[GetComponents<DialogueResponseEvents>().Length][];
        int tempIndex=0;
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            compResponseEvents[tempIndex] = responseEvents.Events;
            tempIndex++;
        }
        return compResponseEvents;
    }
}
