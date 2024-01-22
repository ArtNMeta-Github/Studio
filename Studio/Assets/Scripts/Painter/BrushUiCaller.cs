using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class BrushUiCaller : MonoBehaviour
{
    public GameObject ui;
    LineRenderer lineRenderer;
    protected virtual void Start()
    {        
        var xrGrab = GetComponent<XRGrabInteractable>();
        xrGrab.activated.AddListener(x => CallUI());

        lineRenderer = GetComponent<LineRenderer>();
    }

    void CallUI()
    {
        ui.transform.parent = null;

        ui.SetActive(!ui.activeSelf);
        lineRenderer.enabled = ui.activeSelf;

        var camTransform = Camera.main.transform;

        //ui.transform.LookAt(camTransform.position);
        ui.transform.position = camTransform.position + camTransform.forward;

        Vector3 direction = camTransform.position - ui.transform.position;
        var newRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        newRotation *= Quaternion.Euler(0, -180f, 0);
        ui.transform.rotation = newRotation;
    }
    private void Update()
    {
        if (!ui.activeSelf)
            return;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, ui.transform.position + Vector3.down * 0.3f);
    }
}
