using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.VFX;
using UnityEngine.Events;

public class WateringCan : MonoBehaviour
{
    private AudioSource audioSource;
    public VisualEffect effect;
    public float spraySpeed = 1f;

    public UnityEvent<float> growTree;
    private bool isSpraying = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        effect.Stop();

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
        grabInteractable.selectExited.AddListener(x => StopShoot());
    }
    public void StartShoot()
    {
        effect.Play();
        audioSource.Play();

        isSpraying = true;
    }
    public void StopShoot()
    {
        effect.Stop();
        audioSource.Stop();

        isSpraying = false;
    }

    private void Update()
    {
        if (!isSpraying)
            return;

        growTree.Invoke(spraySpeed * Time.deltaTime);
    }
}
