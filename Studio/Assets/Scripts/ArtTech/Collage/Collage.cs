using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collage : MonoBehaviour
{   
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponentInChildren<BoxCollider>();
    }
    public void ChangeBoxColliderValue(Vector3 newPos, Vector3 newSize, LayerMask layer)
    {
        boxCollider.transform.position = newPos;
        boxCollider.size = newSize;

        gameObject.layer = layer;
    }
    public void InstanceOrigin()
    {
        GetComponent<P3dPaintableTexture>().enabled = false;
        OriginCollagePrinter.InstantiateCollage(transform.position,transform.rotation);
    }
}
