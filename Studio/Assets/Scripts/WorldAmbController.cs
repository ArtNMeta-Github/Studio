using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAmbController : MonoBehaviour
{
    public AudioSource dayAmb;
    public AudioSource nightAmb;

    private float currMainVolume = 1f;
    public float ambSwitchSpeed = 1f;

    private Coroutine ambSwitchCoroutine;

    private void Start()
    {
        DayCycle.Instance.StartEv.AddListener(StartEv);
    }

    private void StartEv(bool isDay)
    {
        AudioSource currAmb = isDay ? dayAmb : nightAmb;
        AudioSource holdAmb = isDay ? nightAmb : dayAmb;

        currAmb.volume = currMainVolume;
        currAmb.Play();

        holdAmb.volume = 0f;
        holdAmb.Stop();
    }
    private IEnumerator AmbSwitchCoroutine(AudioSource sour, AudioSource dest)
    {
        while(currMainVolume < 1f)
        {
            currMainVolume += Time.deltaTime * ambSwitchSpeed;


            yield return null;
        }

        ambSwitchCoroutine = null;
        yield break;
    }
}
