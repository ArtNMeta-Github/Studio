using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointilismUI : MonoBehaviour
{
    public Pointilism pointilism;

    public Slider count;
    public Slider scale;
    public Slider dispersion;
    private void Start()
    {
        count.onValueChanged.AddListener(pointilism.SetDotsCount);
        scale.onValueChanged.AddListener(pointilism.SetDotsRadius);
        dispersion.onValueChanged.AddListener(pointilism.SetDotsDispersion);
    }
}
