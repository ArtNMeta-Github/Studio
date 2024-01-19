using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 코드는 사용되지 않습니다.
//this class is obsolete
public class MarblingRippleGenerator : MonoBehaviour
{
    public P3dDecalAngleChanger decalAngleChanger;
    Vector3 lastHitLocalPos;

    private void Update()
    {
        var currHitLocalPos = transform.InverseTransformPoint(decalAngleChanger.FinalPosition);
        Vector2 dir = currHitLocalPos - lastHitLocalPos;
        lastHitLocalPos = currHitLocalPos;

        if (dir == Vector2.zero)
            return;

        float newAngle = Vector2.Angle(dir.normalized, transform.right);
        //float crossProduct = Vector3.Cross(dir.normalized, Vector2.right).z;

        //if (crossProduct < 0)
        //{
        //    newAngle *= -1;
        //}

        //TextDebugger.Instance.SetText(dir.ToString());

        decalAngleChanger.SetAngle(newAngle);
    }
}
