using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;
public class RoomSceneFlags : MonoBehaviour
{
    //One per scene

    // UDictionary breaks the inspection when UnityEvents are involved :(
    //[SerializeField] UDictionary<SceneFlag[], int> UIList = new UDictionary<SceneFlag[], int>();
    [SerializeField] SceneName sceneItsIn;
    [SerializeField] SceneFlag[] FlagEventsList;
    [HideInInspector] int[] FlagListInt;
    public static event Action<int,SceneName> GiveFlagListLength;
    public static event Action<int[],SceneName> SendFlags;

    // This is a genuinely, truely, stupid fix. But its the only fix I can think of.
    // UnityEvents doesn't allow for events that need 2 or more parameters in the inspector. 
    // It also doesn't deal with enums so kindly, which really sucks
    // So what do we have to do? We have to create a monobehavior script
    // To attach to whatever is trying to call this event
    // So it can reference the attached object to send to here
    // Its confusing makes absolutely no sense
    // But it works.
    // Its probably the only simple solution we have to it.
    // Don't worry, I hate it.
    public void ChangeFlagName(FlagNamesForStupidEvents flagName)
    {
        ChangeFlag(flagName.changeFlag.flagNames, flagName.changeFlag.flagNum);
    }

    private void Awake(){
        CreateEmptyFlagList();
        MasterFlagManager.GiveFlagList += ReceiveFlags;
        MasterFlagManager.AskForFlagLength += SendFlagLength;
        MultiSceneLoader.CloseScene += SendFlagList;
     }
    private void Start(){
        RefreshAllFlags();
    }
    public void RefreshAllFlags()
    {
        Debug.Log(FlagEventsList.Length);
        Debug.Log(FlagListInt.Length);
        for (int i = 0; i < FlagEventsList.Length; i++)  {
            FlagEventsList[i].ActivateFlagEvent( FlagListInt[i] );}
    }
    
    public void ChangeFlag(FlagNames givenFlag, int newFlag)
    {
        for (int i = 0; i < FlagEventsList.Length; i++)
        {
            if (FlagEventsList[i].nickName.Equals(givenFlag))  { 
                FlagListInt[i] = newFlag; 
                FlagEventsList[i].ActivateFlagEvent(newFlag); 
                Debug.Log("Flag Successfully change, Flag changed: "+ givenFlag );
                return; 
                }
        }
        Debug.Log("Warning, a flag was called that doesn't exist. Flag called: " + givenFlag);
    }
    public void ReceiveFlags(int[] givenFlags,SceneName givenScene)
    {
        Debug.Log(givenScene);
        if (!givenScene.Equals(sceneItsIn)) return;
        FlagListInt = givenFlags;
        RefreshAllFlags();
    }
    public void SendFlagLength(){
        GiveFlagListLength?.Invoke(FlagEventsList.Length, sceneItsIn);
        CreateEmptyFlagList();
    }
    public void SendFlagList(SceneName givenScene)
    {
        if (sceneItsIn.Equals(givenScene) && FlagListInt.Length > 0)  SendFlags?.Invoke(FlagListInt,sceneItsIn);
    }
    private void CreateEmptyFlagList()
    {
        FlagListInt = new int[FlagEventsList.Length];
        for (int i = 0; i < FlagEventsList.Length; i++)
        {
            FlagListInt[i] = 0;
        }
    }
    // Under construction
    // For when a flag that is outside of the room's flag list needs to be changed
    // Use with extreme caution. Can be easily overwritten if the scene that the flag is in is already opened.
    // Might need to make a quick reference list for masterFlagManager that also has a list of FlagNames representing each flag
    // Perhaps convert it to a dictionary?
    public void DeepChangeFlags(FlagNames givenFlag, int newFlag){

    }
}

