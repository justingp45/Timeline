using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RoomSceneManager : MonoBehaviour
{
    // One per scene room
    public static event Action<DialogueObject, ResponseEvent[][]> ShowDialogue;
    public static event Action<Item> AddItemToInventory;
    public static event Action<Item> RemoveItemToInventory;
    public static event Action<bool> ChangePlaytoK177;
    public void CallShowDialogue(DialogueObject givenDialogue,ResponseEvent[][] givenResponseEvents)
    {
        ShowDialogue?.Invoke(givenDialogue,givenResponseEvents);
    }
    public void CallShowDialogue(DialogueObject givenDialogue)
    {
        ShowDialogue?.Invoke(givenDialogue, null);
    }
    public void CallAddItem(Item givenItem) 
    {
        AddItemToInventory?.Invoke(givenItem);
    }
    public void CallRemoveItem(Item givenItem)
    {
        RemoveItemToInventory?.Invoke(givenItem);
    }
    public void CallChangePlayer(bool givenBool)
    {
        ChangePlaytoK177?.Invoke(givenBool);
        Debug.Log("AGGA");
    }
    
}
