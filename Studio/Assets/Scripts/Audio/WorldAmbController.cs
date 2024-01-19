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
        AudioSource mainAmb = isDay ? dayAmb : nightAmb;
        AudioSource secondaryAmb = isDay ? nightAmb : dayAmb;

        mainAmb.volume = 1f;
        mainAmb.Play();

        secondaryAmb.volume = 0f;
        secondaryAmb.Stop();
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
