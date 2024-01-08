using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GrowTreeController : MonoBehaviour
{
    public Renderer pillar;
    public Renderer mainBranch;
    public Renderer[] bottomLeaves;
    public Renderer[] topLeaves;

    Material pillarMat;
    Material mainBranchMat;
    //Material bottomLeavesSharedMat;
    //Material topLeavesSharedMat;

    Material[] bottomLeavesMat;
    Material[] topLeavesMat;

    public string growPropertyName = "_Grow";
    public string leavesAlphaPropertyName = "_alpha";

    public AnimationCurve curve;

    private int growStep = 0;
    public float startGrowValue = 0.05f;
    private float currGrowValue = 0;
    void Start()
    {
        pillarMat = pillar.material;
        mainBranchMat = mainBranch.material;

        //bottomLeavesSharedMat = bottomLeave.sharedMaterial;
        //topLeavesSharedMat = topLeave.sharedMaterial;

        bottomLeavesMat = new Material[bottomLeaves.Length];
        for(int i = 0; i < bottomLeaves.Length; i++)
            bottomLeavesMat[i] = bottomLeaves[i].material;

        topLeavesMat = new Material[topLeaves.Length];
        for (int i = 0; i < topLeaves.Length; i++)
            topLeavesMat[i] = topLeaves[i].material;

        //ObjGrowByTime(DayCycle.Instance.TimeOfDay);

        currGrowValue = startGrowValue;

        SetGrowStepZero();
    }
    public void ObjGrowByTime(float value)
    {
        if (pillarMat == null) return;

        float unit = 6f;

        pillarMat.SetFloat(growPropertyName, Mathf.InverseLerp(0f, unit, value) * 0.3f) ;
        mainBranchMat.SetFloat(growPropertyName, Mathf.InverseLerp(unit, unit * 2f, value) * 0.3f);

        float bottomLeavesAlphaValue = curve.Evaluate(Mathf.InverseLerp(unit * 2f, unit * 3f, value));

        foreach (var mat in bottomLeavesMat)
            mat.SetFloat(leavesAlphaPropertyName, bottomLeavesAlphaValue);

        float topLeavesAlphaValue = curve.Evaluate(Mathf.InverseLerp(unit * 3f, unit * 4f, value));

        foreach (var mat in topLeavesMat)
            mat.SetFloat(leavesAlphaPropertyName, topLeavesAlphaValue);
    }
    public void ObjGrowByWater(float value)
    {
        currGrowValue += value;

        switch (growStep)
        {
            case 0:
                pillarMat.SetFloat(growPropertyName, currGrowValue);
                break;
            case 1:
                mainBranchMat.SetFloat(growPropertyName, currGrowValue);
                break;
            case 2:
                foreach (var mat in bottomLeavesMat)
                    mat.SetFloat(leavesAlphaPropertyName, currGrowValue);
                break;
            case 3:
                foreach (var mat in topLeavesMat)
                    mat.SetFloat(leavesAlphaPropertyName, currGrowValue);
                break;
        }

        if ((growStep == 1 || growStep == 0) && currGrowValue > 0.4f)
        {
            currGrowValue = 0f;
            ++growStep;
        }   

        if (currGrowValue < 1f)
            return;

        currGrowValue = 0f;
        ++growStep;
    }
    private void SetGrowStepZero()
    {
        pillarMat.SetFloat(growPropertyName, startGrowValue);
        mainBranchMat.SetFloat(growPropertyName, 0f);

        foreach (var mat in bottomLeavesMat)
            mat.SetFloat(leavesAlphaPropertyName, 0f);

        foreach (var mat in topLeavesMat)
            mat.SetFloat(leavesAlphaPropertyName, 0f);
    }
}
