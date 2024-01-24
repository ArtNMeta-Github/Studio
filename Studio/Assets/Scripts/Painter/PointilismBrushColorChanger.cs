using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointilismBrushColorChanger : BrushColorChanger
{
    IColorable[] colorables;
    protected override void Start()
    {
        base.Start();
        colorables = painterSource.GetComponents<IColorable>();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PaintPool"))
        {
            var targetColor = other.GetComponent<PaintPool>().Color;

            if (changeBrushColor)
                mat.SetColor(materialColorPropertyName, targetColor);

            foreach (var color in colorables)
                color.Color = targetColor;
        }
    }
}
