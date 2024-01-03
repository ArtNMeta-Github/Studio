using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAmbController : MonoBehaviour
{
    public AudioSource dayAmb;
    public AudioSource nightAmb;

    public float ambSwitchSpeed = 1f;

    private Coroutine ambSwitchCoroutine;

    private void Start()
    {
        var dayCycle = DayCycle.Instance;

        StartEv(dayCycle.IsDay);
        dayCycle.NightChangeEv.AddListener(NightChangeEv);
        dayCycle.DayChangeEv.AddListener(DayChangeEv);
    }
    private void StartEv(bool isDay)
    {
        AudioSource currAmb = isDay ? dayAmb : nightAmb;
        AudioSource holdAmb = isDay ? nightAmb : dayAmb;

        currAmb.volume = 1f;
        currAmb.Play();

        holdAmb.volume = 0f;
        holdAmb.Stop();
    }

    private void NightChangeEv()
    {
        if (ambSwitchCoroutine != null)
            StopCoroutine(ambSwitchCoroutine);

        ambSwitchCoroutine = StartCoroutine(AmbSwitchCoroutine(nightAmb, dayAmb));
    }
    private void DayChangeEv()
    {
        if (ambSwitchCoroutine != null)
            StopCoroutine(ambSwitchCoroutine);

        ambSwitchCoroutine = StartCoroutine(AmbSwitchCoroutine(dayAmb, nightAmb));
    }
    private IEnumerator AmbSwitchCoroutine(AudioSource main, AudioSource secondary)
    {
        if(!main.isPlaying) main.Play();

        if (!secondary.isPlaying) secondary.Play();

        float currMainVolume = 0f;

        while(currMainVolume < 1f)
        {
            float t = Time.deltaTime * ambSwitchSpeed;

            main.volume += t;
            secondary.volume -= t;

            currMainVolume = main.volume;

            yield return null;
        }

        main.volume = 1f;

        secondary.volume = 0f;
        secondary.Stop();

        ambSwitchCoroutine = null;
        yield break;
    }
}
