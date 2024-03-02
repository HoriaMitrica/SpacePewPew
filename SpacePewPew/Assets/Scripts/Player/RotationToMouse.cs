using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationToMouse : MonoBehaviour
{
    public Vector3 mouse = new Vector3(1f, 0, -0.8f);
    public float RotationSpeed = 2f;
    [SerializeField]
    private float PitchRotationAmount = 0f;
    [SerializeField]
    private GameObject YawRotator;
    [SerializeField]
    private GameObject PitchRotator;
    void Start()
    {

    }
    void Update()
    {
        Rotate();
    }
    public Vector3 GetMousePositionWorld()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y - transform.position.y;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    public Vector3 GetDirectionToMouse()
    {
        return (GetMousePositionWorld() - transform.position).normalized;
    }
    public float GetDistanceToMouse()
    {
        return Vector3.Distance(GetMousePositionWorld(), transform.position);
    }
    protected virtual void Rotate()
    {
        Vector3 YawCrossProduct = Vector3.Cross(YawRotator.transform.up, GetDirectionToMouse());
        float YawRotation = (YawCrossProduct.y < 0f ? -1f : 1f) * RotationSpeed * Time.deltaTime;
        YawRotator.transform.Rotate(0f, 0f, YawRotation);

         float PitchDotProduct = Vector3.Dot(Vector3.up, PitchRotator.transform.forward);
         float PitchRotation;
         float rotationAngle = RotationSpeed * Time.deltaTime;
        // if (PitchDotProduct < 0.9f)
        // {
        //     PitchRotation = Vector3.Angle(YawRotator.transform.up, GetDirectionToMouse())+20f;
        // }
        // else
        // {
        //     PitchRotation = 0.1f;
        // }
        // PitchRotator.transform.localRotation = Quaternion.Lerp(PitchRotator.transform.localRotation, Quaternion.Euler(PitchRotation, 0f, 0f),rotationAngle);


    float smoothingFactor = 0.1f;
    float smoothedRotationAngle = PitchRotator.transform.localRotation.eulerAngles.x;
    if (PitchDotProduct < 0.9f)
    {
        PitchRotation = Vector3.Angle(YawRotator.transform.up, GetDirectionToMouse()) + 20f;
    }
    else
    {
        PitchRotation = 0.1f; // Example value when condition is met
    }

    smoothedRotationAngle = Mathf.Lerp(smoothedRotationAngle, PitchRotation, smoothingFactor);
    Quaternion targetRotation = Quaternion.Euler(smoothedRotationAngle, 0f, 0f);
    PitchRotator.transform.localRotation = Quaternion.Lerp(PitchRotator.transform.localRotation, targetRotation, rotationAngle);


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawLine(Vector3.up, Vector3.up * 2);
        Gizmos.DrawLine(mouse, mouse * 3);
        Debug.Log(Vector3.Cross(YawRotator.transform.up, mouse).y);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(PitchRotator.transform.up, YawRotator.transform.up * 2);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(PitchRotator.transform.forward, YawRotator.transform.forward * 2);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(PitchRotator.transform.right, YawRotator.transform.right * 2);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(-YawRotator.transform.up, -YawRotator.transform.up * 3);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(YawRotator.transform.forward, YawRotator.transform.forward * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(YawRotator.transform.right, YawRotator.transform.right * 3);
    }
}
