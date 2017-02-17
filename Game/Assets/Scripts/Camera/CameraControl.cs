﻿using UnityEngine.Networking;
using UnityEngine;

/// <summary>
/// Handles the following of a player for a gameobject with a camera
/// </summary>
public sealed class CameraControl : NetworkBehaviour
{
    [HideInInspector] public Transform TargetTransform;             // The target that this object will follow

    private Camera _camera;                                         // The camera attached to this gameobject

    /// <summary>
    /// Called on object creations
    /// </summary>
	private void Start ()
    {
        _camera = GetComponent<Camera>();                           // Gets the camera object attached to this gameobject

        Quaternion cameraRotation = Quaternion.Euler(50f, 0f, 0f);  // Quaternion with a 50 degree rotation on the x axis?
        _camera.transform.rotation = cameraRotation;                // Set the cameras rotation to the quaternion above
	}
	
    /// <summary>
    /// Called once per frame
    /// </summary>
	private void Update ()
    {
        if (!TargetTransform) return;                               // If the target transform hasn't been given yet, leave method

        Vector3 myTransform;                                        // Vector position associated with the camera attached to this object
        myTransform = transform.position;                           // Set myTransform to this gameobjects transform (So it can be edited)
        myTransform.x = TargetTransform.position.x;                 // Set myTransform.x to this gameobjects transform.x
        myTransform.y = TargetTransform.position.y + 5f;            // Set myTransform.y to this gameobjects transform.y but 5 units up
        myTransform.z = TargetTransform.position.z - 5f;            // Set myTransform.z to this gameobjects transform.z but 5 units back

        transform.position = myTransform;                           // Set this gameobjects transform to myTransform
	}
}
