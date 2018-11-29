using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    //public Camera mainCamera;
    Camera referenceCamera;

    private void Awake()
    {
        // if no camera referenced, grab the main camera
        if (!referenceCamera)
            referenceCamera = Camera.main;
    }
        //Orient the camera after all movement is completed this frame to avoid jittering
    private void LateUpdate()
    {
        transform.LookAt(transform.position + referenceCamera.transform.rotation.x * Vector3.forward,
            referenceCamera.transform.rotation * Vector3.up);
    }
}
