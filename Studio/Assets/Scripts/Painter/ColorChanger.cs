using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
public class ColorChanger : MonoBehaviour
{
    public Color color;
    public string brushTag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(brushTag))
            other.GetComponent<IColorable>().Color = color;
    }
}
