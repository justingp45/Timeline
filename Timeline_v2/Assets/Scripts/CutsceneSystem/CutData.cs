using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Events;
[System.Serializable]
public class CutData 
{
    [SerializeField] private CutType type;
    
    [DrawIf("type", CutType.Timeline)] 
    [Tooltip ("Non-looping timeline goes here. Can be left empty, but only if TimelineLoop is filled.")]
    [SerializeField] private TimelineAsset timeline;

    [DrawIf("type", CutType.Timeline)] 
    [Tooltip ("Loop for the end of previous timeline goes here. Highly recommended unless you have another timeline playing straight after this.")]
    [SerializeField] private TimelineAsset timelineLoop;

    [DrawIf("type", CutType.Dialogue)]  [SerializeField] private DialogueObject dialogue;
    [DrawIf("type", CutType.Event)]     [SerializeField] private EventType eventObject;
    [DrawIf("type", CutType.Event)]     [SerializeField] private int eventIndex ;
    [DrawIf("type", CutType.Wait)]      [Tooltip ("Time in seconds.")]      [SerializeField] private float waitTime ;
    [DrawIf("type", CutType.Audio)]     [SerializeField] private AudioType audioType;
    [DrawIf("type", CutType.Audio)]     [Tooltip ("Set to none to stop music.")]      [SerializeField] private AudioClip playClip;
    [DrawIf("type", CutType.Video)]     [SerializeField] private VideoNames videoClip;
    public CutType Type => type;
    public TimelineAsset Timeline => timeline;
    public DialogueObject Dialogue => dialogue;
    public TimelineAsset TimelineLoop => timelineLoop;
    public int EventIndex => eventIndex;
    public EventType EventObject => eventObject;
    public AudioType AudioType => audioType;
    public AudioClip PlayClip => playClip;
    public float WaitTime => waitTime;
    public VideoNames VideoClip => videoClip;
}
public enum CutType
{
    Timeline,
    Dialogue,
    Event,
    Wait,
    Audio,
    Video,
    None
}
public enum AudioType{
    Sound,
    Music
}
public enum EventType
{
    None
}