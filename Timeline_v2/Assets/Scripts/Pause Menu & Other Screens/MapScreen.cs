using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScreen : MonoBehaviour
{
    [SerializeField] GameObject mapScreen;
    [SerializeField] GameObject backButton;
    public bool IsOpen { get; private set; }

    void Start()
    {
        CloseScreen();
    }
    public void OpenScreen(){
        mapScreen.SetActive(true);
        IsOpen = true;
        
    }
    public void FirstOpen(DialogueObject dialogue){
            OpenScreen();
            backButton.SetActive(false);
            GetComponentInChildren<DialogueUI>().ShowDialogue(dialogue);
            StartCoroutine(WaitBackButton(GetComponentInChildren<DialogueUI>()));

    }
    private IEnumerator WaitBackButton(DialogueUI dialogueUI){
        while (dialogueUI.IsOpen) 
        {
            yield return null;
        }
        backButton.SetActive(true);
    }
    public void CloseScreen()
    {
        mapScreen.SetActive(false);
        IsOpen = false;
    }
}
