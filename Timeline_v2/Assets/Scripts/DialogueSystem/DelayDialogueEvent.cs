using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DelayDialogueEvent : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    // hhh this is so messy Im so sorry to anyone having to fix up this code in the future
    // unless that person is me
    // then L
    [SerializeField] private UnityEvent[] delayEventList;
    public void delayEvent(int index)
    {
        if (index >= delayEventList.Length) return;
        StartCoroutine(loopTillDialogue(delayEventList[index]));
    }
    private IEnumerator loopTillDialogue(UnityEvent givenEvent)
    {
        while (dialogueUI.IsOpen) yield return null;
        givenEvent.Invoke();
    }
}
