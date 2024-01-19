using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 코드는 사용되지 않습니다.
//this class is obsolete
public class P3dDecalAngleChanger : MonoBehaviour
{
    public P3dHitBetween hitBetween;
    public P3dPaintDecal paintDecal;

    public Vector3 FinalPosition => hitBetween.finalPosition;
    public void SetAngle(float value) => paintDecal.Angle = value;
}
