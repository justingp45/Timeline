using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueItemCheck : MonoBehaviour
{
    
    [SerializeField] private DialogueItem[] dialogueItemList;
    public DialogueItem[] DialogueItemList => dialogueItemList;
    [SerializeField] protected internal Inventory inventory;
}
[System.Serializable]
public class DialogueItem
{
    // Perhaps we can have a prioriy variable that determines which dialogue overwrites what if theres multiple dialogueItems
    // that are true. For instance, if theres a check if the player has a screwdriver, but also a check if the player has a note,
    // we should say which dialogue gets priority.
    // Also make the requireditem an item list, just in case the player needs multiple items for the dialogue to change
    [SerializeField] private Item requiredItem;
    [SerializeField] private DialogueObject dialogue;
    public Item RequiredItem => requiredItem;
    public DialogueObject Dialogue => dialogue;
}
