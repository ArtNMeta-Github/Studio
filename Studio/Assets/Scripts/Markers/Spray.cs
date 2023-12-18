using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spray : MonoBehaviour
{
    public ParticleSystem particles;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
        grabInteractable.hoverExited.AddListener(x => StopShoot());
        grabInteractable.selectExited.AddListener(x => StopShoot());
    }
    public void StartShoot()
    {
        particles.Play();
        audioSource.Play();
    }
    public void StopShoot()
    {
        particles.Stop();
        audioSource.Stop();
    }
}
