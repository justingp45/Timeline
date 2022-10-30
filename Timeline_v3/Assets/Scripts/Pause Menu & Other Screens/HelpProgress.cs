using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpProgress : MonoBehaviour
{
    //Ight, this stuff is gonna make sure that the help dialogue that is shown is accurate to the progress of the player
    [SerializeField] private DialogueActivator helpActivator;
    [SerializeField] private DialogueObject[] helpDialogueList;
    //[SerializeField] private DialogueUI dialogueUI;
    public bool[] helpDialogueActive;
    public int helpProgressFlag = 0;
    private void Start(){
        helpDialogueActive=new bool[helpDialogueList.Length];
        for (int i=0; i < helpDialogueActive.Length; i++)  helpDialogueActive[i] = true;
    }
    public void playHelp(DialogueUI dialogueUI)
    {
        dialogueUI.CloseUI();
        for (int i = 0; i < helpDialogueActive.Length; i++)
        {
            if (helpDialogueActive[i]) 
            {
                helpActivator.UpdateDialogueObject( helpDialogueList[i] );
                break;
            }
        }
        StartCoroutine(waitStep(dialogueUI));
    }
    private IEnumerator waitStep(DialogueUI dialogueUI){
        yield return null;
        helpActivator.Interact(dialogueUI);
    }
    //public void addLinearProgress(int progressNum){if (progressNum > helpProgressFlag) helpProgressFlag = progressNum;}
    public void deactivateProgressPoint (int index)
    {
        if (index >= helpDialogueActive.Length) return;
        helpDialogueActive[index] = false;
    }
}
 