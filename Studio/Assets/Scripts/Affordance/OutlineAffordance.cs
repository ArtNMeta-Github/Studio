using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineAffordance : Outline
{
    public XRBaseInteractable interactable;
    public override void Start()
    {
        base.Start();
        interactable ??= GetComponent<XRBaseInteractable>();

        interactable.firstHoverEntered.AddListener(x => enabled = true);
        interactable.lastHoverExited.AddListener(x => enabled = false);

        interactable.selectEntered.AddListener(x => enabled = false);

        enabled = false;
    }
}
