using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintTube : MonoBehaviour
{
    public GameObject paintDrop;
    public Transform dropSpawnPoint;
    private bool resetSqueeze = true;

    private void Start()
    {
        var interactable = GetComponent<XRGrabInteractable>();

        interactable.activated.AddListener(x => SpawnPaintDrop());
        interactable.deactivated.AddListener(x => resetSqueeze = true);
    }

    private void SpawnPaintDrop()
    {
        if (!resetSqueeze)
            return;

        resetSqueeze = false;
        Instantiate(paintDrop, dropSpawnPoint.position, Quaternion.identity).SetActive(true);
    }
}
