using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName ="Cutscene/CutsceneObject")]
public class CutsceneObject : ScriptableObject
{
    [SerializeField] private MiniCutObject[] cutsceneFlow;
    public MiniCutObject[] CutsceneFlow => cutsceneFlow;
    [SerializeField] private CutData[] cutsceneData;
    public CutData[] CutsceneData => cutsceneData;
}
