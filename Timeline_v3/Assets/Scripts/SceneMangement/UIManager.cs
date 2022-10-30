using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UIManager : MonoBehaviour
{
    public static event Action<bool,UIName> AreUIOpen;
    public static event Action<ResponseEvent> SendResponsEventsToScene;
    public static event Action<UIName> GetInventory;
    [SerializeField] private UDictionary<UIName, GameObject> UIList = new UDictionary<UIName, GameObject>();

   private void Awake(){
       UICaller.ShowDialogue += ShowDialogue;
       RoomSceneManager.ShowDialogue += ShowDialogue;
       UICaller.OpenUIMenu += OpenUI;
       UICaller.CloseUIMenu += CloseUI;
       UICaller.InventoryMainToUI += RecieveInventory;
   }
   // Called from UICaller, sends Dialogue data over from the main scene to the UI scene so it can be given to DialogueUI
    private void ShowDialogue(DialogueObject givenDialogue, ResponseEvent[][] givenResponseEvents)
    {
        UIList[UIName.Dialogue].GetComponent<DialogueUI>().ShowDialogue(givenDialogue);
        UIList[UIName.Dialogue].GetComponent<DialogueUI>().AddResponseEvents(givenResponseEvents);
        Refresh_UI_Open_State();
    }
    // Calls to UICaller and requests for the Inventory object
    public void CallInventory(UIName requestedUI)
    {
        GetInventory?.Invoke(requestedUI);
    }
    //Recieves the inventory and the UIName of the UI that requested the Inventory so it can be given to the correct UI
    private void RecieveInventory(UIName requestedUI, Inventory givenInventory)
    {
        if (requestedUI.Equals(UIName.Inventory)) UIList[requestedUI].GetComponent<InventoryUI>().UpdateInventory(givenInventory);
        if (requestedUI.Equals(UIName.Dialogue))  UIList[requestedUI].GetComponent<ResponseHandler>().UpdateInventory(givenInventory);
    }
    //Called from either UICaller or UI's themselves, opens/closes the specified UI's
    public void OpenUI (UIName givenUI)
    {
        UIList[givenUI].GetComponent<UITemplate>().OpenUI();
        Refresh_UI_Open_State ();
    }
    public void CloseUI (UIName givenUI)
    {
        UIList[givenUI].GetComponent<UITemplate>().CloseUI();
        Refresh_UI_Open_State ();
    }


    // Sends Response Events to Responses Event Invoke to be invoked in the main scene instead of UI scene
    public void SendResponseEvents(ResponseEvent givenEvents)
    {
        SendResponsEventsToScene?.Invoke(givenEvents);
    }
    // Checks through the UI's to see if any UI's are open. Aftwards, updates UICaller on the current status.
    public void Refresh_UI_Open_State ()
    {
        // IF YOU'RE GETTING A NULLREFERENCE POINT INTO HERE, ADD AND REMOVE SOMETHING FROM THE UILIST DICTIONARY
        // For some reason, the dictionary can bug out and be misaligned when adding new entries so you need the dictionary to realize its broken and fix itself
        foreach (UIName temp in UIList.Keys)
        {
            if (UIList[temp].GetComponent<UITemplate>().IsOpen) { Update_AreUIOpen(true,temp); return; }
        }
        Update_AreUIOpen(false,UIName.None);
    }
    // Updates UICaller of statuses of UI's
    private void Update_AreUIOpen(bool givenBool,UIName openedUI){
        AreUIOpen?.Invoke(givenBool,openedUI);
    }

}

public enum UIName
{
    Dialogue,
    Pause,
    Options,
    Map,
    Inventory,
    Quit,
    None
}