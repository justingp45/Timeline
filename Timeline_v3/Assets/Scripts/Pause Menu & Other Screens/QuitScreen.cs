using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScreen : UITemplate
{
    [SerializeField] private GameObject screen;
    void Start()
    {
        CloseUI();
    }
    protected override void OpenUIInternal(){
        screen.SetActive(true);
    }
    protected override void CloseUIInternal(){
        screen.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting..."); 
        Application.Quit();
    }
}
