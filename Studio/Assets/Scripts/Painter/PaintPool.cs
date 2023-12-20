using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPool : MonoBehaviour
{   
    public Color Color => color; [SerializeField] private Color color;

    public string materialColorPropertyName;
    private void Start()
    {
        var mat = GetComponent<Renderer>().material;
        
        AdjustColorToMaterial(mat);
    }

    void AdjustColorToMaterial(Material mat) => mat.SetColor(materialColorPropertyName, color);
}
