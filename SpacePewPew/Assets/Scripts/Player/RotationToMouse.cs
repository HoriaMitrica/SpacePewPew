using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationToMouse : MonoBehaviour
{

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
        float YawRotation=(YawCrossProduct.y < 0f ? -1f : 1f) * RotationSpeed * Time.deltaTime;
        YawRotator.transform.Rotate(0f, 0f,YawRotation);


        Vector3 PitchCrossProduct = Vector3.Cross(PitchRotator.transform.forward, GetDirectionToMouse());
        
        if(PitchCrossProduct.y<0f)
        {
            float PitchDotProduct = Vector3.Dot(Vector3.up, PitchRotator.transform.forward);
            float PitchRotation=Mathf.Lerp(PitchRotationAmount, 0, Mathf.Abs(PitchDotProduct));//* RotationSpeed * Time.deltaTime;
            PitchRotator.transform.Rotate(PitchRotation , 0f, 0f);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(PitchRotator.transform.up, YawRotator.transform.up * 2);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(PitchRotator.transform.forward, YawRotator.transform.forward * 2);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(PitchRotator.transform.right, YawRotator.transform.right * 2);
    }
}
