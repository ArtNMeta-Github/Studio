using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Launch : MonoBehaviour
{
    IXRSelectInteractable m_SelectInteractable;

    protected void OnEnable()
    {
        m_SelectInteractable = GetComponent<IXRSelectInteractable>();
        m_SelectInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    protected void OnDisable()
    {
        if (m_SelectInteractable as Object != null)
            m_SelectInteractable.selectEntered.RemoveListener(OnSelectEntered);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!(args.interactorObject is XRRayInteractor))
            return;

        var attachTransform = args.interactorObject.GetAttachTransform(m_SelectInteractable);
        var originalAttachPose = args.interactorObject.GetLocalAttachPoseOnSelect(m_SelectInteractable);
        SetLocalPose(attachTransform, originalAttachPose);
    }

    private void SetLocalPose(Transform transform, UnityEngine.Pose pose)
    {
#if HAS_SET_LOCAL_POSITION_AND_ROTATION
            transform.SetLocalPositionAndRotation(pose.position, pose.rotation);
#else
        transform.localPosition = pose.position;
        transform.localRotation = pose.rotation;
#endif
    }
}
