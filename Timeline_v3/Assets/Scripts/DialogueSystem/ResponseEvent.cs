
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class ResponseEvent 
{
    [HideInInspector] public string name;
    [SerializeField] private UnityEvent onPickedResponse;
    public UnityEvent OnPickedResponse => onPickedResponse;
    // Specially made index tag to help give it a unique but recreatable tag
    [HideInInspector] public string DTag;
}
