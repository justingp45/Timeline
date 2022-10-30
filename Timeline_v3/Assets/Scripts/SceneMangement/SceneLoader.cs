using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // OBSOLETE PLEASE LOOK AT ROOMSCENEFLAGS INSTEAD 
    // Plop this into a scene loader manager, only one per room scene, don't add to main or UI
    GameObject[] itemFlags;
    private void Awake(){
        //MultiSceneLoader.LoadFlags += LoadFlags;
    }
    private void LoadFlags(int[] flags){
        //I'm still waiting to learn how the flags/saving works
    }
}
