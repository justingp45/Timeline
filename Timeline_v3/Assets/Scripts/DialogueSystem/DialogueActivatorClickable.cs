using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueActivatorClickable : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    
    void Start(){
        //GetComponent<Image>().color=new Color(1f,1f,1f,0f);
        foreach (Image temp in GetComponentsInChildren<Image>())
        {
         temp.color=new Color(1f,1f,1f,0f);   
        }
        
    }
    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    public void Interact(PlayerMovement PlayerMovement)
    {
        //messy af code i am so sorry
    }
    public void Interact(DialogueUI dialogueUI)
    {
        if (TryGetComponent(out DialogueResponseEvents responseEvents) && responseEvents.DialogueObject==dialogueObject)
        {
            dialogueUI.AddResponseEvents(responseEvents.Events);
        }
        dialogueUI.ShowDialogue(dialogueObject);
    }
    public void Interact(RoomSceneManager mainUI)
    {
        CheckforItem();
        ResponseEvent[][] temp = CompileResponseEvents();
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
