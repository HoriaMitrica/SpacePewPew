using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public float Height=25f;
    public GameObject playerRef;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos=new Vector3(playerRef.transform.position.x,Height,playerRef.transform.position.z);
        transform.position=cameraPos;
    }
}
