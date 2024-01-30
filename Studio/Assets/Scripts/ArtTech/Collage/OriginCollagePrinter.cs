using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OriginCollagePrinter : MonoBehaviour
{
    public GameObject originCollagePrefab;
    static OriginCollagePrinter instance;

    private void Awake()
    {
        instance = this;
    } 
    public static void InstantiateCollage(Vector3 pos, Quaternion rot)
    {
        Instantiate(instance.originCollagePrefab, pos, rot);
    }
}
