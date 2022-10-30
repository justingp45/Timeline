using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    private const string VOLUME_kEY = "volume";

    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    private Slider slider;
    // Be careful with the orders of Awakes and Starts
    private void Awake()
    {
        slider = GetComponent<Slider>();

        GlobalReferences.VolumeControl = this;
    }

    public void SetVolume()
    {
        float volume = slider.value;

        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_kEY, volume);

            GlobalReferences.SoundManager.SetVolume(volume);
        }
    }

    public float GetValue()
    {
        return PlayerPrefs.GetFloat(VOLUME_kEY);
    }
}
