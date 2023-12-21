using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    public float width;
    public Color color;

    public static OutlineController instance;
    private void Awake()
    {
        instance = this;
    }
}
