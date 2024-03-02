using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerRotation : RotationToMouse
{
    public float zRotationAmount = 75f;
    public float MinDistanceToRotate=0.5f;

    protected override void Rotate()
    {
        //base.Rotate();
        if(GetDistanceToMouse()>MinDistanceToRotate)
        {
        transform.forward = Vector3.Lerp(transform.forward, GetDirectionToMouse(), RotationSpeed*Time.deltaTime);
        Vector3 crossProduct = Vector3.Cross(transform.forward, GetDirectionToMouse());
        float dotProduct = Vector3.Dot(transform.forward, GetDirectionToMouse());
        float zRotation = Mathf.Lerp(crossProduct.y > 0f ? -zRotationAmount : zRotationAmount, 0, Mathf.Abs(dotProduct));
        transform.Rotate(transform.forward*Time.deltaTime*RotationSpeed,zRotation,Space.World);
        }   

    }
}
