using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] musicList;
    [SerializeField] private AudioSource[] soundList;
    private int currentPlayingMusicIndex=-1;
    private bool IsFading;
    private float tempVol;
    public void PlayMusic(int index){
        Debug.Log("playing"+index);
        if (IsFading) 
        {
            StopAllCoroutines();
            musicList[currentPlayingMusicIndex].volume = tempVol;
            IsFading = false;
            Debug.Log("QUICK STOP FADING");
        }
        if (currentPlayingMusicIndex!=-1) 
        {
            musicList[currentPlayingMusicIndex].Stop();
        }
        currentPlayingMusicIndex = index;
        musicList[index].Play();
    }

    public void StopMusic()
    {
        Debug.Log("stopped"+currentPlayingMusicIndex);
        if (currentPlayingMusicIndex == -1) return;
        musicList[currentPlayingMusicIndex].Stop();
        currentPlayingMusicIndex =- 1;
    }
    public void FadeStopMusic()
    {  
        Debug.Log("stopping"+currentPlayingMusicIndex);
        if (currentPlayingMusicIndex == -1) return;
        StartCoroutine(fadingStop());
    }
    public void PlaySound(int index)
    {
        soundList[index].Play();
    }
    public void PlaySound(AudioClip givenSound){
        int temp = FindSound(givenSound);
        if (temp != -1) soundList[temp].Play();
    }
    public void YieldPlaySound(AudioClip givenSound){
        int temp = FindSound(givenSound);
        if (temp != -1) YieldPlaySound(temp);
    }
    private int FindSound(AudioClip givenSound)
    {
        //foreach (AudioSource Clip in soundList)'
        for (int i = 0; i<soundList.Length; i++)
        {
            if (soundList[i].clip.Equals(givenSound))  return i;
            Debug.Log(soundList[i].clip);
        }
        Debug.Log("Warning, attempted to play audio clip that doesn't exist");
        return -1;
    }
    public void YieldPlaySound(int index)
    {
        if (!soundList[index].isPlaying)
            soundList[index].Play();
    }
    public void StopSounds()
    {
        foreach (AudioSource thingy in soundList)
        {
            thingy.Stop();
        }
    }
    private IEnumerator fadingStop()
    {
        IsFading = true;
        tempVol = musicList[currentPlayingMusicIndex].volume;
        yield return null;
        while (musicList[currentPlayingMusicIndex].volume > 0)
        {
            musicList[currentPlayingMusicIndex].volume += -0.006f;
            if (musicList[currentPlayingMusicIndex].volume < 0) musicList[currentPlayingMusicIndex].volume=0;
            yield return null;
        }
        musicList[currentPlayingMusicIndex].volume = tempVol;
        StopMusic();
        IsFading = false;
        Debug.Log("volll");
    }
}
