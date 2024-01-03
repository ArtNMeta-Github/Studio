using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer audioMixer;
    private void Awake()
    {
        Instance = this;
    }
    public void ToggleMute() => AudioListener.volume = 1f - AudioListener.volume;

    public void SetBGMVolume(float volume)
    {   
        audioMixer.SetFloat("BGM", Mathf.Log10(Mathf.Lerp(0.0001f, 1f, volume * 0.01f)) * 20f);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(Mathf.Lerp(0.0001f, 1f, volume * 0.01f)) * 20f);
    }
    public void SetAMBVolume(float volume)
    {
        audioMixer.SetFloat("AMB", Mathf.Log10(Mathf.Lerp(0.0001f, 1f, volume * 0.01f)) * 20f);
    }
}
