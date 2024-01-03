using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayCycle : MonoBehaviour
{
    //Singleton
    public static DayCycle Instance;

    [SerializeField] private Light sun;
    [SerializeField, Range(0,24)] private float timeOfDay;
    public float TimeOfDay => timeOfDay;

    private float timeFraction;
    private float invDayTime = 1 / 24f;
    public float TimeFraction => timeFraction;

    [SerializeField] private float sunRotationSpeed;

    [Header("LightingPreset")]
    [SerializeField] private Gradient skyColor;
    [SerializeField] private Gradient equatorColor;
    [SerializeField] private Gradient sunColor;

    [SerializeField] float minFogDensity;
    [SerializeField] float maxFogDensity;
    public UnityEvent DayChangeEv { get; } = new();
    public UnityEvent NightChangeEv { get; } = new();

    [SerializeField] private bool isDay = true;
    public bool IsDay => isDay;

    public float dayStartTime = 6f;
    public float nightStartTime = 20f;

    private void Awake()
    {
        Instance = this;
        isDay = timeOfDay > dayStartTime && timeOfDay < nightStartTime;
    }
    //private void Update()
    //{
    //    timeOfDay = Mathf.Repeat(timeOfDay + Time.deltaTime * sunRotationSpeed, 24);

    //    UpdateSunRotation();
    //    UpdateLighting();
    //}
    private void OnValidate() => UpdateEnvironments();
    private void UpdateTimeFraction() => timeFraction = timeOfDay * invDayTime;
    private void UpdateDayNightStatus()
    {
        if (isDay)
        {
            if (timeOfDay < dayStartTime || timeOfDay > nightStartTime)
            {
                isDay = false;
                NightChangeEv.Invoke();
                return;
            } 
        }
        else
        {
            if (timeOfDay > dayStartTime && timeOfDay < nightStartTime)
            {
                isDay = true;
                DayChangeEv.Invoke();
                return;
            }
        }
    }

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
        float radian = timeFraction * Mathf.PI * 2f;
        float t = Mathf.Cos(radian) * 0.5f + 0.5f;

        RenderSettings.fogDensity = Mathf.Lerp(minFogDensity, maxFogDensity, t);
    }

    private void UpdateEnvironments()
    {
        UpdateDayNightStatus();
        UpdateTimeFraction();
        UpdateSunRotation();
        UpdateLighting();
        UpdateFog();
    }

    private void OnDestroy()
    {
        DayChangeEv.RemoveAllListeners();
        NightChangeEv.RemoveAllListeners();
    }
}
