using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Events;
[CreateAssetMenu(menuName ="Cutscene/MiniCutObject")]
public class MiniCutObject : ScriptableObject
{
   //this is so stupid, why can't i just have a simple array list that can hold both timelines and dialogueobjects
   [SerializeField] private DialogueObject dialogueObject;
   //[SerializeField] private TimelinePreferences timelineObject;
   [SerializeField] private TimelineAsset timelineObject;
   [SerializeField] private bool isLoop;
   //[SerializeField] private GameObject[] playableList;
   //[SerializeField] private UnityEvent eventTriggers;
   //public UnityEvent EventTriggers => eventTriggers;
   [SerializeField] public int eventIndex;
   [SerializeField] public bool hasEvent = false;

   //public GameObject[] PlayableList => playableList;
   //[SerializeField] private int playableIndex;
   //0=Leo, 1=K-177
   //public int PlayableIndex => playableIndex;
   public bool HasTimeline => timelineObject != null;
   public bool HasDialogue => dialogueObject != null;
   //public bool HasEvent => eventTriggers != null;
   public bool IsLoop => isLoop;
   public DialogueObject dialogue => dialogueObject;
   public TimelineAsset TimelineObject => timelineObject;
}
