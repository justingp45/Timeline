using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using System.Linq;
using System;
using UnityEditor;
public enum VideoNames{
    K177GettingHit
}
public class VideoManager : MonoBehaviour
{
    // Due to the immense size that video files can be, it would be bad practice to load in the file and for the entire game so we can wait to play it
    // Instead, it should be loaded right when a cutscene is being played

    //[SerializeField] private VideoPlayer videoStuff;
    private VideoPlayer Player;
    //[SerializeField] private UnityEvent finishVideo;
    //[SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject videoRenderer;
    [HideInInspector] public bool IsPlaying = false;
    private Dictionary<VideoNames, string> VideoToPath = new Dictionary<VideoNames, string>
    {
        { VideoNames.K177GettingHit,"Assets/Video/Timeline Indigo Knockout.mp4"}
    };
    void Start()
    {
        //videoStuff.Prepare();
    }
    public void PreLoadVideo(VideoNames givenVideo){
        Player.clip = AssetDatabase.LoadAssetAtPath<VideoClip>(VideoToPath[givenVideo]);
        Player.Prepare();
    }
    public void PlayVideo(VideoNames givenVideo)
    {
        videoRenderer.SetActive(true);
        IsPlaying = true;
        StartCoroutine(waitTillEnd());
    }
    /*private IEnumerator waitTillEnd()
    {
        if (!videoStuff.isPrepared)
            yield return null;
        videoStuff.Play();
        Debug.Log(videoStuff.isPlaying);
        while(true)
        {
            player.inCutscene = true;
            yield return null;
            if (!videoStuff.isPlaying)
            {
                yield return null;
                if (!videoStuff.isPlaying) break;
            }

        }
        for (int i = 0; i < 300; i++) yield return null;
        player.inCutscene = false;
        finishVideo.Invoke();
        Debug.Log("video enede");
        videoRenderer.SetActive(false);
    }*/
    private IEnumerator waitTillEnd()
    {
        // Wait for the video to be prepared being playing it
        if (!Player.isPrepared)
            yield return null;
        Player.Play();
        while (true)
        {
            // For some reason, when clicking out of the game while the game is running, for a single frame the video
            // Is marked as not playing, so we have to wait a frame before making sure the video actually ended
            // This is absolutely stupid, but its needed
            if (!Player.isPlaying)
            {
                yield return null;
                if (!Player.isPlaying) break;
            }
            videoRenderer.SetActive(false);
            IsPlaying = false;
        }

    }
}
