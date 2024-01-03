using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider AMBSlider;
    private void Start()
    {
        var audioManager = AudioManager.Instance;

        audioManager.SetBGMVolume(BGMSlider.value);
        audioManager.SetSFXVolume(SFXSlider.value);
        audioManager.SetAMBVolume(AMBSlider.value);

        BGMSlider.onValueChanged.AddListener(audioManager.SetBGMVolume);
        SFXSlider.onValueChanged.AddListener(audioManager.SetSFXVolume);
        AMBSlider.onValueChanged.AddListener(audioManager.SetAMBVolume);
    }
}
