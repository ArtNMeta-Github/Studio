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
    //public GameObject painter;

    Vector3 newColliderSize = new Vector3(0.2f, 0.2f, 0.01f);
    Vector3 hitPoint;

    private void Start()
    {
        //painter.SetActive(false);

        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => TryDetachTarget());
        grabInteractable.deactivated.AddListener(x => PlaceTarget());
        grabInteractable.selectEntered.AddListener(x => PlaceTarget());
    }
    void TryDetachTarget()
    {
        if (target != null)
            return;

        if (!Physics.Raycast(stampHead.position, -stampHead.up, out RaycastHit hit, 0.006f, 1))
        {
            return;
        }

        if (!hit.collider.CompareTag("CollagePaper"))
            return;

        hitPoint = hit.point;

        //painter.SetActive(true);
        target = hit.transform;

        var mat = target.GetComponent<Renderer>().material;
        mat.SetFloat("_OnMask", 1f);
        target.GetComponent<Collage>().SwitchToOrigin();

        target.parent = transform;
    }

    void PlaceTarget()
    {
        if(target == null)
            return;

        //painter.SetActive(false);

        target.GetComponent<Collage>().SetBoxColliderValue(hitPoint, newColliderSize);

        target.parent = null;
        target = null;
    }
}
