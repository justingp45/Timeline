using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private Transform audioListnerTrans;
    private AudioClip clip;
    private Dictionary<string, AudioClip> clips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clips = new Dictionary<string, AudioClip>();

        GlobalReferences.SoundManager = this;

        LoadClips();
    }

    private void Start()
    {
        audioListnerTrans = GlobalReferences.CameraShake.transform;
        GlobalReferences.VolumeControl.SetVolume();
        PlayMusic("Timeline Bathroom Escape DRAFT");
    }

    private void LoadClips()
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Sound");

        foreach(AudioClip c in audioClips)
        {
            Debug.Log(c.name);
            clips.Add(c.name, c);
        }
    }

    private bool SetClip(string name)
    {
        AudioClip c = null;

        clips.TryGetValue(name, out c);

        if (!c)
        {
            Debug.LogError("Audio clip not found");
            return false;
        }

        clip = c;
        return true;
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void PlayMusic(string name)
    {
        if (!SetClip(name))
            return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayClip(string name)
    {
        if (!SetClip(name))
            return;

        audioSource.PlayOneShot(clip);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
