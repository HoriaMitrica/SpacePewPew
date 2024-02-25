using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DelayedRotation : RotationToMouse
{
    public float zRotationAmount = 90f;

    protected override void Rotate()
    {
        base.Rotate();

        Vector3 crossProduct = Vector3.Cross(transform.forward, GetDirectionToMouse());
        float dotProduct = Vector3.Dot(transform.forward, GetDirectionToMouse());
        float zRotation = Mathf.Lerp(crossProduct.y > 0f ? -zRotationAmount : zRotationAmount, 0, dotProduct);
        transform.Rotate(0f, 0f, zRotation);
    }
}
