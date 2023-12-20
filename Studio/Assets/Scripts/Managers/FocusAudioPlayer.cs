using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusAudioPlayer : MonoBehaviour
{
    public static FocusAudioPlayer instance;

    void Awake()
    {
        instance = this;
    }
}
