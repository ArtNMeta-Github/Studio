using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollageStamp : MonoBehaviour
{
    XRGrabInteractable grabInteractable;

    Transform target;

    public Transform stampHead;
    public GameObject painter;

    Vector3 newColliderSize = new Vector3(0.2f, 0.2f, 0.01f);
    Vector3 hitPoint;

    private void Start()
    {
        painter.SetActive(false);

        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => TryPaint());
        grabInteractable.deactivated.AddListener(x => TryDetachTarget());
        grabInteractable.selectEntered.AddListener(x => TryDetachTarget());
    }
    void TryPaint()
    {
        if (target != null)
            return;

        if (!Physics.Raycast(stampHead.position, -stampHead.up, out RaycastHit hit, 0.005f))
        {
            return;
        }

        if (!hit.collider.CompareTag("CollagePaper"))
            return;

        hitPoint = hit.point;

        painter.SetActive(true);
        target = hit.transform;
        target.parent = transform;
    }

    void TryDetachTarget()
    {
        if(target == null)
            return;

        painter.SetActive(false);

        var mat = target.GetComponent<Renderer>().material;
        mat.SetFloat("_OnMask", 1f);

        target.GetComponent<Collage>().SetBoxColliderValue(hitPoint, newColliderSize);

        target.parent = null;
        target = null;
    }
}
