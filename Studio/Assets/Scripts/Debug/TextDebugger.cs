using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDebugger : MonoBehaviour
{
    private static TextDebugger instance;
    public static TextDebugger Instance => instance;

    TextMeshPro textMeshPro;
    private void Start()
    {
        instance = this;
        textMeshPro = GetComponent<TextMeshPro>();
    }

    public void SetText(string text) => textMeshPro.text = text;
}
