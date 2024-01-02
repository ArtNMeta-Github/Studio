using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public static DayCycle Instance;

    [SerializeField] private Light sun;
    [SerializeField, Range(0,24)] private float timeOfDay;
    private float timeFraction;
    public float TimeFraction => timeFraction;

    [SerializeField] private float sunRotationSpeed;

    [Header("LightingPreset")]
    [SerializeField] private Gradient skyColor;
    [SerializeField] private Gradient equatorColor;
    [SerializeField] private Gradient sunColor;

    [SerializeField] float minFogDensity;
    [SerializeField] float maxFogDensity;

    private void Awake() => Instance = this;
    private void Update()
    {
        timeOfDay = Mathf.Repeat(timeOfDay + Time.deltaTime * sunRotationSpeed, 24);

        UpdateSunRotation();
        UpdateLighting();
    }
    private void OnValidate() => UpdateEnvironments();
    private void UpdateTimeFraction() => timeFraction = timeOfDay / 24;
    public void SetTimeValue(float value)
    {
        timeOfDay = value;
        UpdateEnvironments();
    } 
    private void UpdateSunRotation()
    {
        float sunRotation = Mathf.Lerp(-90,270, timeFraction);
        sun.transform.rotation = Quaternion.Euler(sunRotation, sun.transform.rotation.y, sun.transform.rotation.z);
    }
    private void UpdateLighting()
    {   
        RenderSettings.ambientEquatorColor = equatorColor.Evaluate(timeFraction);
        RenderSettings.ambientSkyColor = skyColor.Evaluate(timeFraction);
        sun.color = sunColor.Evaluate(timeFraction);
    }
    private void UpdateFog()
    {
        float angle = timeFraction * Mathf.PI * 2f;
        float t = Mathf.Cos(angle) * 0.5f + 0.5f;

        RenderSettings.fogDensity = Mathf.Lerp(minFogDensity, maxFogDensity, t);
    }

    private void UpdateEnvironments()
    {
        UpdateTimeFraction();
        UpdateSunRotation();
        UpdateLighting();
        UpdateFog();
    }
}
