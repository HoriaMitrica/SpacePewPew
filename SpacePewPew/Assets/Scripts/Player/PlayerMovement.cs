using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    private float Thrust = 0f;
    private float MaxThrust=3f;
    private RotationToMouse playerRotation;
    private Rigidbody rb;
    void Start()
    {
        playerRotation=GetComponent<RotationToMouse>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        CheckBoosting();
        
        rb.AddForce(transform.forward * Thrust, ForceMode.Impulse);
    }

    private void CheckBoosting()
    {
        if (Input.GetAxis("Boost") != 0)
        {
            Thrust=Accelerate(Thrust,MaxThrust);
        }
        else
        {
            Thrust = 0f;
        }
    }
    private float Accelerate(float thrust,float maxThrust)
    {
        if(thrust<maxThrust)
        return thrust+Time.deltaTime;
        return maxThrust;
    }
}
