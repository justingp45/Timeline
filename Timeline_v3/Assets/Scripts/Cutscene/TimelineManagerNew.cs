using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using System;


[System.Serializable]
public class DialogueEvent: UnityEvent<DialogueObject>
{

}

[System.Serializable]
public class NpcAnimationEvent: UnityEvent<Animator>
{

}

public class TimelineManagerNew : MonoBehaviour
{
    private PlayableDirector pd;
    private double duration, currentState;

    [SerializeField] private UnityEvent[] callbacks;
    [SerializeField] private DialogueEvent[] dialogues;
    [SerializeField] private NpcAnimationEvent[] npcAnimations;
    [SerializeField] private UnityEvent[] soundEvents;

    public static event Action<bool> UpdateCutsceneStatus;

    private void Awake()
    {
        GlobalReferences.TimelineManager = this;
    }

    void Start()
    {
        pd = GetComponent<PlayableDirector>();
    }

    public void SetPlayableAsset(PlayableAsset playableAsset)
    {
        pd.playableAsset = playableAsset;
        ResetInitialState();
    }

    public void PlayCutscene()
    {
        pd.Play();

        UpdateCutsceneStatus?.Invoke(true);
    }

    public void StopCutscene()
    {
        OnCutsceneEnd();
        pd.Stop();
    }

    public void PauseCutscene(double duration)
    {
        this.duration = duration;
        currentState = pd.time;
        pd.Stop();
    }

    public void ResumeCutscene()
    {
        pd.initialTime = currentState + duration;
        pd.Play();
    }

    public void InvokeCallback(int index)
    {
        try
        {
            callbacks[index]?.Invoke();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Callback function does not exist. Check the callback index");
        }
    }

    public void TriggerDialogue(int index, DialogueObject dialogueObject)
    {
        try
        {
            dialogues[index]?.Invoke(dialogueObject);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Dialogue function does not exist. Check the dialogue index");
        }
    }

    public void TriggerNpcAnimation(int index, Animator animator)
    {
        try
        {
            npcAnimations[index]?.Invoke(animator);
        }
        catch (System.Exception e)
        {
            Debug.LogError("npc animation function does not exist. Check the npc animation index");
        }
    }

    public void TriggerSoundEvent(int index)
    {
        try
        {
            soundEvents[index]?.Invoke();
        }
        catch (System.Exception e)
        {
            Debug.LogError("sound event function does not exist. Check the npc sound event index");
        }
    }

    public void ResetInitialState()
    {
        pd.initialTime = 0;
    }

    public void OnCutsceneEnd()
    {
        UpdateCutsceneStatus?.Invoke(false);
    }
}
