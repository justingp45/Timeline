using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System;

[Serializable]
public class PauseForInputClip : PlayableAsset
{
    [SerializeField]
    private PauseForInputBehaviour template = new PauseForInputBehaviour();

    [NonSerialized] public double start, end;

    public ClipCaps clipCaps
    {
        get
        {
            return ClipCaps.None;
        }
    }
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        template.start = start;
        template.end = end;

        return ScriptPlayable<PauseForInputBehaviour>.Create(graph, template);
    }
}
