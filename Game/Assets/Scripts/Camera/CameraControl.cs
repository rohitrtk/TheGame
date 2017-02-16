using UnityEngine.Networking;
using UnityEngine;

public class CameraControl : NetworkBehaviour
{
    [HideInInspector] public Transform TargetTransform;

    private Camera _camera;
    private Vector3 myTransform;

	private void Start ()
    {
        if (!isLocalPlayer) return;

        _camera = GetComponent<Camera>();

        Quaternion cameraRotation = Quaternion.Euler(40f, 0f, 0f);
        _camera.transform.rotation = cameraRotation;
	}
	
	private void Update ()
    {
        if (!TargetTransform) return;

        myTransform = transform.position;
        myTransform.x = TargetTransform.position.x;
        myTransform.y = TargetTransform.position.y + 5f;
        myTransform.z = TargetTransform.position.z - 5f;
        
        transform.position = myTransform;
	}
}
