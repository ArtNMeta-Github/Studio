using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadioButton : MonoBehaviour
{
    public UnityEvent evt;    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Hand"))
            evt.Invoke();
    }

    private void OnDestroy()
    {
        evt.RemoveAllListeners();
    }
}
