using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       Interact(PlayerMovement.DialogueUI);
    }
    public void Interact(DialogueUI dialogueUI)
    {
        DialogueItemCheck itemCheck = GetComponent<DialogueItemCheck>();
        if (itemCheck != null)
            foreach (DialogueItem itemsToCheck in itemCheck.DialogueItemList)
            {
                if (itemCheck.inventory.HasItem(itemsToCheck.RequiredItem)) 
                    UpdateDialogueObject(itemsToCheck.Dialogue);
            }

        ResponseEvent[][] compResponseEvents = new ResponseEvent[GetComponents<DialogueResponseEvents>().Length][];
        int tempIndex=0;
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            compResponseEvents[tempIndex] = responseEvents.Events;
            tempIndex++;
        }
        dialogueUI.AddResponseEvents(compResponseEvents);
        dialogueUI.ShowDialogue(dialogueObject);
    }
}
