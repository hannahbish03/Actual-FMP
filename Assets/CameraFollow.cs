using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
       
        if (target != null)
        {
            Vector3 desiredposition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed);
            transform.position = smoothedPosition;


        }

    }




}



