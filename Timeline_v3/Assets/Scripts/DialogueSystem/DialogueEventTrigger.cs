using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogueEventTrigger : MonoBehaviour
{
    // This is supposed to be used for activating events before, or after a dialogue trigger. 
    // This sorta stuff is actually important for some stuff regarding the puzzle screens.
    // Don't use the startTrigger to mess with the actual dialogue activator, else
    // I will come to your house and strangle you.
    [SerializeField] private UnityEvent startTrigger;
    [SerializeField] private UnityEvent endTrigger;
    public UnityEvent StartTrigger => startTrigger;
    public UnityEvent EndTrigger => endTrigger;
}
