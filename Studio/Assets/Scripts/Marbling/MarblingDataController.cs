using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarblingDataController : MonoBehaviour
{
    public Slider distortionSlider;
    public Slider noiseScaleSlider;

    public MarblingDistortionData distortionData;
    private void Start()
    {
        distortionSlider.minValue = 0f;
        distortionSlider.maxValue = 1f;
        distortionSlider.value = distortionData.distortionStartValue;
        distortionSlider.onValueChanged.AddListener(distortionData.SetDistortionValue);

        noiseScaleSlider.minValue = 0f;
        noiseScaleSlider.maxValue = 100f;
        noiseScaleSlider.value = distortionData.noiseScaleStartValue;
        noiseScaleSlider.onValueChanged.AddListener(distortionData.SetNoiseScaleValue);
    } 
}
