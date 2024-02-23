using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public float thrust = 5f;
    private RotationToMouse playerRotation;
    private Rigidbody rb;
    void Start()
    {
        playerRotation=GetComponent<RotationToMouse>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        CheckBoosting();
        Move();
    }

    private void Move() 
    {
        
        float distanceToMouse = Vector3.Distance(playerRotation.GetMousePositionWorld(), transform.position);
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
