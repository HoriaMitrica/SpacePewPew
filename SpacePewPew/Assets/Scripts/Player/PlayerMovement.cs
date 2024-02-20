using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float thrust = 5f;
    private Camera mainCamera;
    private Vector3 mousePositionWorld;
    private Rigidbody rb;
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y - transform.position.y));
        transform.forward = GetDirectionToMouse();

        CheckBoosting();
        Move();
    }
    public Vector3 GetDirectionToMouse()
    {
        return (mousePositionWorld - transform.position).normalized;
    }
    private void Move()
    {
        float distanceToMouse = Vector3.Distance(mousePositionWorld, transform.position);
        if (distanceToMouse < 1)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        }
    }

    private void CheckBoosting()
    {
        if (Input.GetAxis("Boost") != 0)
        {
            thrust = 5f;
        }
        else
        {
            thrust = 1f;
        }
    }
}
