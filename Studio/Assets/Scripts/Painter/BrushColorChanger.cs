using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
public class BrushColorChanger : MonoBehaviour
{
    public bool changeBrushColor = false;

    public string materialColorPropertyName;

    public Renderer renderSource;
    
    public GameObject painterSource;

    IColorable colorable;
    Material mat;

    private void Start()
    {
        colorable = painterSource.GetComponent<IColorable>();

        if(changeBrushColor)
        {
            mat = renderSource.material;
            mat.SetColor(materialColorPropertyName, colorable.Color);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PaintPool"))
        {
            var targetColor = other.GetComponent<PaintPool>().Color;

            if(changeBrushColor)
                mat.SetColor(materialColorPropertyName, targetColor);

            colorable.Color = targetColor;
        }            
    }
}
