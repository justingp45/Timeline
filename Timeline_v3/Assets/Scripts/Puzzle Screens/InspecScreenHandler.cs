using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
public class InspecScreenHandler : MonoBehaviour
{   
    //ONly deals with the inspection screens in its own scene
    //One per scene (if sceen has an inspection screen)
    public static event Action<bool> UpdateScreenStatus;
    [SerializeField] GameObject[] screens;
    [SerializeField] private TransitionScreen transitionScreen;
    [SerializeField] string[] inspecScreenList;
    [SerializeField] GameObject overworld;
    public bool IsOpen { get; private set; }
    void Start()
    {
        //changeScreen(0);
        //IsOpen=false;
        exitScreen();
    }
    public void changeScreen(int index){
        UpdateScreenStatus?.Invoke(true);
        for (int i=0; i<screens.Length; i++) screens[i].SetActive(false);
            screens[index].SetActive(true);
        //this is genuinely the worst fix to this stupid damn problem but honestly i am in rage rn
        Debug.Log("FF");
        transitionScreen.StopAllCoroutines();
        transitionScreen.halfTransitionItself();
        IsOpen=false;
        screens[index].GetComponent<ClickableObjectHandler>().clearButtonStatus();
    }
    public void exitScreen()
    {
        for (int i=0; i<screens.Length; i++) screens[i].SetActive(false);
        overworld.SetActive(true);
        UpdateScreenStatus?.Invoke(false);
    }
    public void transChangeScreen(int index)
    {
        transitionScreen.fullTransitionItself((index));
        IsOpen=true;
    }
    //prob not gonna be used anymore
    public void changeScene(int index)
    {
        //Debug.Log(inspecScreenList.Length);
        SceneManager.LoadScene(inspecScreenList[index]);
    }
    public void transChangeScene(int index)
    {
        transitionScreen.sceneTransition(index);
        IsOpen=true;
    }

}
