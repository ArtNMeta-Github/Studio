using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDrop : MonoBehaviour
{
    bool destroyTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brush"))
            return;

        destroyTrigger = true;
    }

    private void LateUpdate()
    {
        if (destroyTrigger)
            Destroy(gameObject);
    }
}
