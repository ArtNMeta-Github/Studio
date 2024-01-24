using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class StickPointSeeker : MonoBehaviour
{
    public StickerHandler target;
    string targetTag;
    Transform targetTransform;
    public LayerMask rayTagetLayer;

    public float maxRayDist = 0.15f;
    XRGrabInteractable interactable;

    bool isSelected = false;

    private void Start()
    {
        if(target == null)
            target = StickerHandler.Instance;

        targetTag = target.tag;
        rayTagetLayer = target.gameObject.layer;
        targetTransform = target.transform;        

        interactable = GetComponent<XRGrabInteractable>();

        interactable.firstSelectEntered.AddListener(x => isSelected = true);
        interactable.lastSelectExited.AddListener(x => isSelected = false);
    }

    private void Update()
    {
        if (!isSelected)
            return;

        if (!Physics.Raycast(transform.position, -targetTransform.forward, out RaycastHit hit, maxRayDist, rayTagetLayer))
        {
            return;
        }

        if (!hit.transform.CompareTag(targetTag))
        {
            return;
        }
        target.SetStickZRotation(transform.localEulerAngles.z);
        target.SetStickerPosition(hit.point + targetTransform.forward * 0.001f);
    }
}
