using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioClip[] clips;

    int currIdx = 0;
    int clipsCount = 0;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = clips[currIdx];
        audioSource.Play();

        clipsCount = clips.Length;
    }
    public void PlayNext()
    {
        currIdx = ++currIdx % clipsCount;
        audioSource.clip = clips[currIdx];
        audioSource.Play();
    }
    public void PlayBefore()
    {
        currIdx = (--currIdx + clipsCount) % clipsCount;
        audioSource.clip = clips[currIdx];
        audioSource.Play();
    }
}
