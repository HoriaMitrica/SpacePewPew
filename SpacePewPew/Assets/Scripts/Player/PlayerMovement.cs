using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float thrust = 5f;
    private Camera mainCamera;
    private Rigidbody rb;
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePositionScreen=Input.mousePosition;

        Vector3 mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, mainCamera.transform.position.y - transform.position.y));
        Vector3 playerPos=transform.position;
        Vector3 directionToMouse=(mousePositionWorld-playerPos).normalized;
        float distanceToMouse=Vector3.Distance(mousePositionWorld,playerPos);
        transform.forward=directionToMouse;
        Debug.Log(distanceToMouse);
        CheckBoosting();
        if(distanceToMouse<1)
        {
            rb.velocity=Vector3.zero;
        }
        else
        {
            rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        }
        Debug.Log(rb.velocity+" velocity");
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
