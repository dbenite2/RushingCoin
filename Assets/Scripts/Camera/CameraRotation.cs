using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationTime = 10f;
    private bool hasRotated = false;
    void LateUpdate()
    {
        if (Time.deltaTime < rotationTime && !hasRotated) { 
            RotateCamera(180);
            hasRotated = true;
        } else {
            // RotateCamera(0);
        }
        
    }


    private void RotateCamera(float rotationDirection) {
        Quaternion targetRotation = Quaternion.Euler(0,0,rotationDirection);
        Quaternion startRotation = transform.rotation;
        transform.rotation = Quaternion.Lerp(startRotation,targetRotation, Time.deltaTime);
    }   
}
