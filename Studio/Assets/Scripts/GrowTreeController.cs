using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    float growValue;
    public float GrowValue => growValue;
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


        MainObjGrowController(DayCycle.Instance.TimeOfDay);
    }
    public void ChildObjGrowController(Material mat, float value)
    {
        mat.SetFloat(growPropertyName, value);
    }
    public void MainObjGrowController(float value)
    {
        if (pillarMat == null) return;

        float unit = 6f;

        pillarMat.SetFloat(growPropertyName, Mathf.InverseLerp(0f, unit, value) * 0.3f) ;
        mainBranchMat.SetFloat(growPropertyName, Mathf.InverseLerp(unit, unit * 2f, value) * 0.3f);

        foreach(var mat in bottomLeavesMat)
            mat.SetFloat(leavesAlphaPropertyName, Mathf.InverseLerp(unit * 2f, unit * 3f, value) * Mathf.Sign(Mathf.PI * 2f));

        foreach(var mat in topLeavesMat)
            mat.SetFloat(leavesAlphaPropertyName, Mathf.InverseLerp(unit * 3f, unit * 4f, value) * Mathf.Sign(Mathf.PI * 2f));
    }
}
