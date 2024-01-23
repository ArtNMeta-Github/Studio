using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickerHandler : MonoBehaviour
{
    public XRSocketInteractor stickerPrefab;
    XRSocketInteractor sticker;
    WaitForSeconds coroutineWait;
    private void Start()
    {   
        InstanceNewSticker();
        coroutineWait = new WaitForSeconds(2f);
    }
    public void SetStickerPosition(Vector3 position)
    {
        sticker.transform.position = position;
    }
    private void InstanceNewSticker()
    {   
        if(sticker != null)
            sticker.GetComponent<Collider>().enabled = false;

        sticker = Instantiate(stickerPrefab, transform);
        sticker.selectEntered.AddListener(StickTarget);        
    }

    void StickTarget(SelectEnterEventArgs call)
    {
        var targetTransform = call.interactableObject.transform;

        targetTransform.GetComponent<XRGrabInteractable>().enabled = false;
        targetTransform.GetComponent<StickPointSeeker>().enabled = false;
        var hitNearby = targetTransform.GetComponent<P3dHitNearby>();
        StartCoroutine(OffHitNearbyAfterUpdate(hitNearby));
        targetTransform.parent = sticker.transform;
        targetTransform.localPosition = Vector3.zero;
        targetTransform.localEulerAngles = Vector3.zero;

        InstanceNewSticker();
    }
    IEnumerator OffHitNearbyAfterUpdate(P3dHitNearby hitNearby)
    {
        hitNearby.enabled = true;
        yield return coroutineWait;
        hitNearby.enabled = false;
    }
}


