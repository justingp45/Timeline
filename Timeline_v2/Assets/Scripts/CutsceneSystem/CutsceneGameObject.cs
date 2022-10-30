using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CutsceneGameObject : MonoBehaviour
{
    [SerializeField] private CutsceneObject cutsceneScript;
    public CutsceneObject CutsceneObject => cutsceneScript;
    [SerializeField] private UnityEvent[] cutsceneEvents;
    public UnityEvent[] CutsceneEvents => cutsceneEvents;
    
}
