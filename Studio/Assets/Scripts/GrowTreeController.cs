using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTreeController : MonoBehaviour
{
    public Renderer pillar;
    public Renderer mainBranch;
    public Renderer bottomLeave;
    public Renderer topLeave;

    Material pillarMat;
    Material mainBranchMat;
    Material bottomLeavesSharedMat;
    Material topLeavesSharedMat;

    public string growPropertyName = "_Grow";
    public string leavesAlphaPropertyName = "_alpha";

    float growValue;
    public float GrowValue => growValue;
    void Start()
    {
        pillarMat = pillar.material;
        mainBranchMat = mainBranch.material;

        bottomLeavesSharedMat = bottomLeave.sharedMaterial;
        topLeavesSharedMat = topLeave.sharedMaterial;

        MainObjGrowController(DayCycle.Instance.TimeOfDay);
    }
    public void ChildObjGrowController(Material mat, float value)
    {
        mat.SetFloat(growPropertyName, value);
    }
    public void MainObjGrowController(float value)
    {
        float unit = 6f;

        pillarMat.SetFloat(growPropertyName, Mathf.InverseLerp(0f, unit, value));
        mainBranchMat.SetFloat(growPropertyName, Mathf.InverseLerp(unit, unit * 2f, value));
        bottomLeavesSharedMat.SetFloat(leavesAlphaPropertyName, Mathf.InverseLerp(unit * 2f, unit * 3f, value));
        topLeavesSharedMat.SetFloat(leavesAlphaPropertyName, Mathf.InverseLerp(unit * 3f, unit * 4f, value));
    }
}
