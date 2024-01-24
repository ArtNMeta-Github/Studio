using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointilism : MonoBehaviour
{
    public GameObject paint;
    private P3dPaintSphere[] dots;

    public int dotsCount = 5;
    public float dotsRadius = 0.01f;
    public float dispersion = 0.01f;


    private void Start()
    {
        dots = paint.GetComponents<P3dPaintSphere>();
    }
    public void SetDotsCount(float count)
    {
        dotsCount = Mathf.Clamp((int)count, 0, dots.Length);

        for(int i = 0; i < dots.Length; i++)
        {
            dots[i].Opacity = 0;

            if (i < dotsCount)
                dots[i].Opacity = 1;
        }
    }
    public void SetDotsRadius(float radius)
    {
        for(int i = 0; i < dots.Length; i++)
        {
            dots[i].Radius = radius;
        }
    }
    public void SetDotsDispersion(float dispersion)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].Modifiers.GetP3dModifyPositionRandom().Radius = dispersion;
        }
    }
}
