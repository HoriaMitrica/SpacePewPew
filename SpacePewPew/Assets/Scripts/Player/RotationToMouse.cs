using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationToMouse : MonoBehaviour
{
    public float RotationSpeed=2f;
    void Start()
    {
    }

    // Update is called once per frame
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
    protected virtual void Rotate()
    {
        transform.forward = Vector3.Slerp(transform.forward, GetDirectionToMouse(), RotationSpeed*Time.deltaTime);
        Debug.Log(transform.forward);
    }

}
