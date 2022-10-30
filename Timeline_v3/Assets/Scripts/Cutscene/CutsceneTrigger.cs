using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableAsset playableAsset;
    private TimelineManagerNew timelineManager;

    private void Start()
    {
        timelineManager = GlobalReferences.TimelineManager;
    }

    public void StartCutscene()
    {
        if (!playableAsset)
            return;

        timelineManager.SetPlayableAsset(playableAsset);
        timelineManager.PlayCutscene();
    }

    public void StopCutscene()
    {
        timelineManager.StopCutscene();
    }

    public void Continue()
    {
        timelineManager.ResumeCutscene();
    }
}
