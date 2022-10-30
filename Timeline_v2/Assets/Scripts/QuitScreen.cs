using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScreen : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    public bool IsOpen { get; private set; }
    void Start()
    {
        CloseScreen();
    }
    public void OpenScreen(){
        screen.SetActive(true);
        IsOpen=true;
    }
    public void CloseScreen(){
        screen.SetActive(false);
        IsOpen=false;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting..."); 
        Application.Quit();
    }
}
