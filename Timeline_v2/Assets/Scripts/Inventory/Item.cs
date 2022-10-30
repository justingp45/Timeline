using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    // Name will be used to display the items name on UI's and such
    //private string name;
    [SerializeField] private string itemName;
    // ItemType would be an internal way of identifying the type of item we're working with in the code
    // Maybe this should be turned into an itemID instead? But for now, this is easier to follow
    [SerializeField] private string itemType;
    public string ItemName => itemName;
    public string ItemType => itemType;
    // Initalizing the Item. Its given its type and name.
    public Item(string initType, string initName){
        itemType = initType;
        name = initName;
    }
    public string GetName(){
        return name;
    }
    public string GetItemType(){
        return itemType;
    }
}

