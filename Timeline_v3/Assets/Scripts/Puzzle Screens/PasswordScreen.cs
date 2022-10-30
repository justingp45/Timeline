using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class PasswordScreen : PuzzleScreenTemplate
{
    //[SerializeField] private InputField passwordField;
    
    [SerializeField] private string correctPassword;
    //[SerializeField] private UnityEvent correctEvent;
    [SerializeField] private UnityEvent wrongEvent;
    private string passwordSubmit;
    [SerializeField] private string promptText =  "Enter Password...";
    void Start(){
        puzzleContainer.GetComponentInChildren<TMP_InputField>().placeholder.GetComponentInChildren<TMP_Text>().text = promptText;
        CloseScreen();
    }
    public void OnSubmit()
    {
        passwordSubmit=puzzleContainer.GetComponentInChildren<TMP_InputField>().text;
        if (passwordSubmit.Equals(correctPassword)) {Solved(); return;}
        {
            puzzleContainer.GetComponentInChildren<TMP_InputField>().placeholder.GetComponentInChildren<TMP_Text>().text = promptText;
            puzzleContainer.GetComponentInChildren<TMP_InputField>().text = "";
            wrongEvent.Invoke();
        }
        CloseScreen();
    }
    protected override void CheckSolved()
    {

    }
    public void OpenScreen(){
        OpenPuzzle();
    }
    public void CloseScreen(){
        ClosePuzzle();
    }
}
