using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollageStickerSeeker : MonoBehaviour
{
    public CollageCanvas target;
    string targetTag;
    Transform targetTransform;
    LayerMask rayTagetLayer;

    public Transform rayStart;
    public float maxRayDist = 0.15f;
    XRGrabInteractable interactable;

    bool isSelected = false;
    bool foundTarget = false;

    private void Start()
    {
        if (target == null)
            target = CollageCanvas.Instance;

        rayTagetLayer = 1;

        targetTag = target.tag;
        targetTransform = target.transform;

        interactable = GetComponent<XRGrabInteractable>();

        interactable.firstSelectEntered.AddListener(x => isSelected = true);
        interactable.lastSelectExited.AddListener(x => isSelected = false);
        interactable.lastSelectExited.AddListener(x => StickToTarget());
    }
    private void Update()
    {
        if (!isSelected)
            return;

        if (!Physics.Raycast(rayStart.position, targetTransform.forward, out RaycastHit hit, maxRayDist, rayTagetLayer))
        {
            foundTarget = false;
            return;
        }

        if (!hit.transform.CompareTag(targetTag))
        {
            foundTarget = false;
            return;
        }

        foundTarget = true;

        target.SetStickZRotation(transform.localEulerAngles.z);
        target.SetStickerPosition(hit.point - targetTransform.forward * (0.001f + 0.000001f * target.Count++));
    }

    void StickToTarget()
    {
        if (!foundTarget)
            return;

        rayStart.parent = null;
        rayStart.GetComponent<BoxCollider>().enabled = false;
        transform.parent = rayStart;
        transform.GetComponent<XRGrabInteractable>().enabled = false;

        target.OnStick(rayStart);
    }
}
