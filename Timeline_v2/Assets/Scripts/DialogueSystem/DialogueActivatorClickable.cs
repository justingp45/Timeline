using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueActivatorClickable : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    //[SerializeField] private DialogueUI dialogueUI;
    //private bool clickable = true;
    
    void Start(){
        GetComponent<Image>().color=new Color(1f,1f,1f,0f);
        //GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse());
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
}
