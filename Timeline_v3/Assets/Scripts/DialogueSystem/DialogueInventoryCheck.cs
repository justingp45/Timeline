using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// MARK FOR DELETION
public class DialogueInventoryCheck : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private DialogueObject dialgoueChange;
    [SerializeField] private Item checkItem;
    private bool hasChecked = false;
    public void hasItem()
    {
        Debug.Log(hasChecked);
        if (hasChecked) return;
        if (inventory.HasItem(checkItem)) 
        {
            Debug.Log("detected item");
            GetComponentInChildren<DialogueActivatorClickable>().UpdateDialogueObject(dialgoueChange);
            hasChecked = true;
        }
    }
}
