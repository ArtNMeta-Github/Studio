using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDebugger : MonoBehaviour
{
    private static TextDebugger instance;
    //public static TextDebugger Instance => instance;

    TextMeshPro textMeshPro;
    private void Awake()
    {
        instance = this;
        textMeshPro = GetComponent<TextMeshPro>();
    }
    public static void SetText(string text) => instance.textMeshPro.text = text;
}
