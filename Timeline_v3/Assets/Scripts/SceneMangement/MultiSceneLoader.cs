using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;
public class MultiSceneLoader : MonoBehaviour
{
    //int[] mainFlags;
    public static event Action<SceneName> LoadFlags;
    public static event Action<SceneName> CloseScene;
    private Dictionary<SceneName,string> nameToScene = new Dictionary<SceneName, string>
    {
        { SceneName.Bedroom, "Bedroom" },
        {SceneName.Hallway, "Hallway"},
        {SceneName.Bathroom, "Bathroom"}
    };

    private void Awake()
    {
        //Added for cutscene use
        GlobalReferences.MultiSceneLoader = this;
        
        // Unloads all room scenes first
        foreach (string scene in nameToScene.Values) {
            try
        {
            SceneManager.UnloadSceneAsync(scene);
        }
        catch{}
        }
        // Loads in the Ui scene
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    void Start()
    {
        //Change this to the room you want to work with
        Debug.Log("Here it comes");
        LoadScene(SceneName.Bathroom);
    }

    public void LoadScene(SceneName sceneName){
        Debug.Log("Call to Load Scene");
        // Unloads all room scenes
        foreach (SceneName scenes in nameToScene.Keys) UnloadScene(scenes);

        if (!SceneManager.GetSceneByName(nameToScene[sceneName]).isLoaded)
        {
            Debug.Log("Attempting to load scene: " + sceneName);
            SceneManager.LoadScene(nameToScene[sceneName], LoadSceneMode.Additive);
            LoadFlags?.Invoke(sceneName);
        }   
    } 
    public void UnloadScene(SceneName sceneName)
    {
        if (SceneManager.GetSceneByName(nameToScene[sceneName]).isLoaded)
        {
            Debug.Log("Attempting to unload scene: " + sceneName);
            CloseScene?.Invoke(sceneName);
            SceneManager.UnloadSceneAsync(nameToScene[sceneName]);
        }
    }

    public void LoadScene(int givenScene)
    {
        Debug.Log("index: " + givenScene);

        List<SceneName> keyList = new List<SceneName>(nameToScene.Keys);

        Debug.Log(keyList[givenScene]);

        LoadScene(keyList[givenScene]);
    }
}
public enum SceneName{
    Bedroom,
    UI,
    Hallway,
    Bathroom,
    None
    }