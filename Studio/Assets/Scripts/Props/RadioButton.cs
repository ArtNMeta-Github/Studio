using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class RadioButton : MonoBehaviour
{
    public float pushTime = 0.1f;
    public float pushDepth = 0.00005f;
    public UnityEvent evt;

    Coroutine buttonPushCoroutine;
    XRSimpleInteractable simpleInteractable;
    AudioSource audioSource;

    private void Start()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.selectEntered.AddListener(x => StartPushcoroutine());

        audioSource = GetComponent<AudioSource>();        
    }
    public void StartPushcoroutine()
    {
        if (buttonPushCoroutine != null)
            return;

        evt.Invoke();
        audioSource.Play();
        buttonPushCoroutine = StartCoroutine(PushCoroutine());
    }

    IEnumerator PushCoroutine()
    {
        float timer = 0f;
        float invPushTime = 1 / pushTime;
        Vector3 newPos = Vector3.zero;

        bool isPushing = false;

        while (true)
        {
            if(!isPushing)
            {
                if (timer > pushTime) isPushing = true;

                timer += Time.deltaTime;                
            }

            if(isPushing)
            {
                if (timer < 0f) break;

                timer -= Time.deltaTime;                
            }                

            newPos.x = Mathf.Lerp(0f, pushDepth, timer * invPushTime);
            transform.localPosition = newPos;
            yield return null;
        }

        transform.localPosition = Vector3.zero;

        buttonPushCoroutine = null;
        yield break;
    }
}
