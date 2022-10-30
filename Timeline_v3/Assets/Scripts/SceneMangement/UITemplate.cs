using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UITemplate : MonoBehaviour
{
    //Attach this script to any UIManaging object
    //Use OpenUI to properly open a UI DO NOT CALL OpenUIInternal. calling it instead of OpenUI will not refresh the UI state

    public void OpenUI()
    {
        IsOpen=true;
        uIManager.Refresh_UI_Open_State();
        OpenUIInternal();
    }
    protected abstract void OpenUIInternal();

    public void CloseUI(){
        IsOpen = false;
        uIManager.Refresh_UI_Open_State();
        CloseUIInternal();
    }
    protected abstract void CloseUIInternal();

    public bool IsOpen { get ; protected set; } 
    protected UIManager uIManager;

       protected virtual void Awake(){
           uIManager = GetComponentInParent<UIManager>();
            IsOpen=false;
       }
}
