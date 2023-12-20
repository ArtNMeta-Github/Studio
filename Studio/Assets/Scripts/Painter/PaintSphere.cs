using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintSphere : MonoBehaviour
{
    private float originBounciness;

    void Start()
    {
        var physics = GetComponent<Collider>().material;
        originBounciness = physics.bounciness;

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(x => OffBounciness(physics));
        grabInteractable.selectExited.AddListener(x => OnBounciness(physics));
    }

    void OffBounciness(PhysicMaterial physic) => physic.bounciness = 0f;
    void OnBounciness(PhysicMaterial physic) => physic.bounciness = originBounciness;
    
}
