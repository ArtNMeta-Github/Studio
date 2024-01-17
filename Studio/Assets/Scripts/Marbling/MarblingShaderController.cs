using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarblingShaderController : MonoBehaviour
{
    Slider slider;

    public MablingShaderData shaderData;
    private void Start()
    {
        slider = GetComponent<Slider>();

        //slider.onValueChanged.AddListener(shaderData.SetDistortionValue);
    }
}
