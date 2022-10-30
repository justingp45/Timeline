using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MasterFlagManager : MonoBehaviour
{
    //ONLY ONE IN THE MAIN SCENE, DO NOT ADD TO OTHER SCENES
    public static event Action<int[],SceneName> GiveFlagList;
    public static event Action AskForFlagLength;
    public Dictionary<SceneName,int> SceneFlagLengths;
    //All import flags right here
    public List<int> masterFlagList;
    private void Awake()
    {
        // Later on we can have a better way of automating the length of the flaglist but this is what we have to deal with with now
        // Assume the player goes through the rooms in its proper order
        SceneFlagLengths = new Dictionary<SceneName, int>()
        {
            {SceneName.Bedroom,-1},
            {SceneName.Hallway,-1},
            {SceneName.Bathroom,-1}
        };
        RoomSceneFlags.GiveFlagListLength += RecieveFlagLength;
        RoomSceneFlags.SendFlags += Recieve_New_Flags_From_Scene;
        MultiSceneLoader.LoadFlags += Give_Flags_To_Loaded_Scene;
    }

    public void Give_Flags_To_Loaded_Scene (SceneName givenScene)
    {
        if (SceneFlagLengths[givenScene].Equals(-1)) AskForFlagLength?.Invoke();
        // Tries to give flags to roomScene, however, if the masterFlagList is empty, it will abort this action
        // The reason we are doing it like this is in case we have an instance that we have a completed masterFlagList
        // But this is the first time MasterFlag is interacting with RoomScene, most likely due to saving and restarting 
        try
        {
            int temp = CountLength(givenScene);
            //int[] temper = new int[SceneFlagLengths[givenScene]-temp];
            int[] temper = new int[SceneFlagLengths[givenScene]];
            //Debug.Log("bruh: "+SceneFlagLengths);
            for (int i = 0; i<temper.Length; i++)
            {
                temper[i] = masterFlagList[temp+i];
            }
            //GiveFlagList?.Invoke(temper);
            StartCoroutine(waitForSceneLoad(temper,givenScene));
            Debug.Log(givenScene);
            Debug.Log(temper.Length);
            //foreach (int i in temper) Debug.Log(i);
        }
        catch { }
    }
    // This is so stupid but basically we have wait a single tic for the roomsceneflags to properly execute the flags
    // Idk why, but doing it with no wait doesn't execute them properly, and having it wait inside of roomSceneFlag doesn't work either
    IEnumerator waitForSceneLoad(int[] temper,SceneName givenScene)
   {
        yield return null;
        GiveFlagList?.Invoke(temper,givenScene);
    }
    public void RecieveFlagLength (int givenLength, SceneName sceneItsIn)
    {
        Debug.Log(givenLength);
        SceneFlagLengths[sceneItsIn] = givenLength;
        for (int i = 0; i < givenLength; i++)  masterFlagList.Add(0);   
    }
    public void Recieve_New_Flags_From_Scene (int[] givenFlags, SceneName sceneItsFrom)
    {
        if (SceneFlagLengths[sceneItsFrom].Equals(-1)) return;
        int temp=CountLength(sceneItsFrom);
        foreach (int tempp in givenFlags)
        {
            masterFlagList[temp] = tempp;
            temp++;
        }
    }
    private int CountLength(SceneName sceneItsFrom)
    {
        int temp=0; 
        List<SceneName> keys = new List<SceneName>(SceneFlagLengths.Keys);
        for (int i=0;i<SceneFlagLengths.Keys.Count;i++)
        { 
            if (keys[i].Equals(sceneItsFrom)) break;
            if (!SceneFlagLengths[ keys[i] ].Equals(-1)) temp += SceneFlagLengths[ keys[i] ];
        }
        
        return temp;
    }
}
