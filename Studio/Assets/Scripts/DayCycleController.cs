using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycleController : MonoBehaviour
{
    Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        var dayCycle = DayCycle.Instance;

        slider.value = dayCycle.TimeOfDay;
        slider.onValueChanged.AddListener(dayCycle.SetTimeValue);
    }

}
