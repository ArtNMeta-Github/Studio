using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Brush : MonoBehaviour
{
    private void Start()
    {
        var interactable = GetComponent<XRGrabInteractable>();

        interactable.selectEntered.AddListener(x =>
        {
            var rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        });
    }
}
