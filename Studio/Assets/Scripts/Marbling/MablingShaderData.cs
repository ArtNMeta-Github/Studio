using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MablingShaderData : MonoBehaviour
{
    public Renderer main;
    public Renderer distortion;

    private Material mainMat;

    public string distortionProperty = "_DistortionTexture";
    public string distortionValueProperty = "_Distortion";

    public void Start()
    {
        GetComponent<P3dMaterialCloner>().Activate();
        mainMat = main.material;

        distortion.GetComponent<P3dMaterialCloner>().Activate();
        distortion.GetComponent<P3dPaintableTexture>().Activate();

        var distortionMat = distortion.material;
        mainMat.SetTexture(distortionProperty, distortionMat.mainTexture);

        //SetDistortionValue(1f);
    }
    public void SetDistortionValue(float value)
    {        
        mainMat.SetFloat(distortionValueProperty, value);
    }
}
