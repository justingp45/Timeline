using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(252f/255f, 3f/255f, 211f/255f)]
[TrackBindingType(typeof(GameObject))]
[TrackClipType(typeof(PauseForInputClip))]

public class PauseForInputTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        IEnumerable<TimelineClip> clips = GetClips();

        foreach(TimelineClip clip in clips)
        {
            PauseForInputClip pauseForInputClip = clip.asset as PauseForInputClip;

            if(pauseForInputClip)
            {
                pauseForInputClip.start = clip.start;
                pauseForInputClip.end = clip.end;
            }
        }

        return base.CreateTrackMixer(graph, go, inputCount);
    }
}
