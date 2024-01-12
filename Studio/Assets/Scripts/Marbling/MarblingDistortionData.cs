using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarblingDistortionData : MonoBehaviour
{
    private Renderer target;
    private Material material;

    public float distortionStartValue = 0.5f;
    public float noiseScaleStartValue = 50f;
    private void Start()
    {
        target = gameObject.GetComponent<Renderer>();
        material = target.material;

        SetDistortionValue(distortionStartValue);
        SetNoiseScaleValue(noiseScaleStartValue);
    }

    public string distortionPropertyName = "_Distortion";
    public string noiseScalePropertyName = "_NoiseScale";
    public void SetDistortionValue(float value) => material.SetFloat(distortionPropertyName, value);
    public void SetNoiseScaleValue(float value) => material.SetFloat (noiseScalePropertyName, value);
}
