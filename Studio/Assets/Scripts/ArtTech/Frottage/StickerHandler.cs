using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickerHandler : MonoBehaviour
{
    public static StickerHandler Instance;

    public XRSocketInteractor stickerPrefab;
    XRSocketInteractor sticker;
    WaitForSeconds coroutineWait;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InstanceNewSticker();
        coroutineWait = new WaitForSeconds(2f);
    }
    public void SetStickerPosition(Vector3 position)
    {   
        sticker.transform.position = position;
    }
    public void SetStickZRotation(float z)
    {
        sticker.transform.localEulerAngles = Vector3.forward * z;
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
        targetTransform.GetComponent<StickPointSeeker>().enabled = false;
        targetTransform.GetComponent<XRGrabInteractable>().enabled = false;

        targetTransform.parent = sticker.transform;
        targetTransform.localPosition = Vector3.zero;
        targetTransform.localEulerAngles = Vector3.zero;

        InstanceNewSticker();

        StartCoroutine(ApplayNormalmapGradually(targetTransform));
    }
    IEnumerator ApplayNormalmapGradually(Transform targetTransform)
    {
        var hitNearby = targetTransform.GetComponent<P3dHitNearby>();
        hitNearby.enabled = true;
        yield return coroutineWait;
        hitNearby.enabled = false;
    }
}


