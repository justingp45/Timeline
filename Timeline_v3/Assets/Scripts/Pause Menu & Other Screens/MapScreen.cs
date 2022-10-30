using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScreen : UITemplate
{
    [SerializeField] GameObject mapScreen;
    [SerializeField] GameObject backButton;
    void Start()
    {
        CloseUI();
    }
    protected override void OpenUIInternal(){
        mapScreen.SetActive(true); 
    }
    public void FirstOpen(DialogueObject dialogue){
            OpenUI();
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
    protected override void CloseUIInternal()
    {
        mapScreen.SetActive(false);
    }
}
