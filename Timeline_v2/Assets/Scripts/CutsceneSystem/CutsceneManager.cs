using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Events;
public class CutsceneManager : MonoBehaviour
{
    [SerializeField] DialogueUI dialogueUI;
    [SerializeField] TimelineManager timelineManager;
    [SerializeField] GameObject player;
    [SerializeField] GameObject screenManager;
    [SerializeField] VideoManager videoManager;
    private bool cutscenePlaying = false;
    private CutsceneGameObject currentCutsceneObject;
    private CutsceneObject currentCutscene;
    private UnityEvent[] cutsceneEventList;
    public void PlayCutscene(CutsceneObject cutsceneStuff){
        cutscenePlaying=true;
        currentCutscene=cutsceneStuff;
        player.GetComponent<PlayerMovement>().inCutscene=true;
        checkForVideo();
        StartCoroutine(StepThroughCutscene());
    }
    public void PlayCutscene(CutsceneGameObject cutsceneStuff){
        currentCutsceneObject = cutsceneStuff;
        cutsceneEventList = cutsceneStuff.CutsceneEvents;
        PlayCutscene(cutsceneStuff.CutsceneObject);
    }
    private void checkForVideo(){
        foreach (CutData shot in currentCutscene.CutsceneData)
            if (shot.Type == CutType.Video)  videoManager.PreLoadVideo(shot.VideoClip);
    }
    private IEnumerator StepThroughCutscene()
    {
        /*for (int i = 0; i < currentCutscene.CutsceneFlow.Length; i++)
        {
            MiniCutObject currentMini = currentCutscene.CutsceneFlow[i];
            if (currentMini.HasTimeline)
            {
                yield return (PlayTimeline(currentMini.TimelineObject, currentMini.IsLoop));
            }
            else if (currentMini.HasDialogue)
            {
                yield return (PlayDialogue(currentMini.dialogue));
            }
            else if (currentMini.hasEvent && currentMini.eventIndex < cutsceneEventList.Length) 
            {
                cutsceneEventList[currentMini.eventIndex].Invoke();
            }   
        }
        player.GetComponent<PlayerMovement>().inCutscene=false;
        cutscenePlaying=false;
        timelineManager.stopTimeline();
        Debug.Log("Cutscene Ended");*/
        foreach (CutData shot in currentCutscene.CutsceneData)
        {
            switch (shot.Type)
            {
                case(CutType.Timeline):
                    yield return (PlayTimeline(shot.Timeline,shot.TimelineLoop));
                    break;

                case(CutType.Dialogue):
                    yield return (PlayDialogue(shot.Dialogue));
                    break;

                case(CutType.Event):
                    yield return (PlayEvent(cutsceneEventList[shot.EventIndex], shot.EventObject));
                    break;

                case(CutType.Wait):
                    yield return PlayWait(shot.WaitTime);
                    break;

                case(CutType.Video):
                    yield return PlayVideo(shot.VideoClip);
                    break;

                default:
                    Debug.Log("Warning, attempting to play next scene in cutscene with an invalid type");
                    break;
            }
        }
    }
    private IEnumerator PlayVideo(VideoNames givenVideo){
        videoManager.PlayVideo(givenVideo);
        while (videoManager.IsPlaying)  yield return null;
    }
    private IEnumerator PlayWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    private IEnumerator PlayEvent(UnityEvent givenEvent, EventType givenType)
    {
        // Add in functionality of waiting for certain events
        givenEvent.Invoke();
        yield return null;
    }
/*
    private IEnumerator PlayTimeline(TimelineAsset givenTimeline, bool isLoop)
    {
        //Debug.Log(timelineManager.isPlaying);
        yield return null;
        timelineManager.stopTimeline();
        //timelineManager.ChangeTimeline(givenTimeline, isLoop);
        //timelineManager.Play();
        timelineManager.PlayTimeline(givenTimeline, isLoop,0);
        //give this to the timeliine manager to play it???
        while (timelineManager.isPlaying())
        {
            yield return null;
        }
    }*/
    private IEnumerator PlayTimeline(TimelineAsset givenTimeline, TimelineAsset loopTimeline)
    {
        yield return null;
        timelineManager.stopTimeline();
        if (givenTimeline != null)
        {
            timelineManager.PlayTimeline(givenTimeline, false);
            while (timelineManager.isPlaying())  yield return null;
        }
        if (loopTimeline != null)
        {
            timelineManager.PlayTimeline(loopTimeline, true);
            while (timelineManager.isPlaying())  yield return null;
        }
    }
    private IEnumerator PlayDialogue(DialogueObject givenDialogue)
    {
        yield return null;
        dialogueUI.CloseDialogueBox();
        dialogueUI.ShowDialogue(givenDialogue);
        while(dialogueUI.IsOpen)
            yield return null;
    }
}
