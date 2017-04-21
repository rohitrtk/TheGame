using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Manages all scripts and methods relevant to the player
/// </summary>
public class Player_Control : NetworkBehaviour 
{
    [SerializeField] private Transform _mainCameraTransform;        // Reference to the scenes main camera transformo
    [SerializeField] private Vector3 _cameraOffset;                 // The cameras offset so it isn't inside the player

    private AbstractPlayer_Movement _playerMovementScript;          // Player movement script
    private AbstractPlayer_Attack _playerAttackScript;              // Player attack script

    private Vector3 _cameraRotation;                                // Vector that stores the cameras rotation

    private float _cameraOffsetY;                                   // How much the camera will be offset on the Y axis
    private float _cameraOffsetZ;                                   // How much the camera will be offset on the Z axis

    private const int _MAXZOOM = 10;                                // How many times can the player zoom in before cut off
    private int _currentZoom;                                       // Current number of times player has zoomed in

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
        if (!isLocalPlayer) return;

        _playerMovementScript = GetComponent<AbstractPlayer_Movement>();
        _playerAttackScript = GetComponent<AbstractPlayer_Attack>();

        _cameraRotation = new Vector3(60f, -45f, 0f);

        _cameraOffsetY = 20f;
        _cameraOffsetZ = -10f;
        _cameraOffset = new Vector3(0f, _cameraOffsetY, _cameraOffsetZ);

        _mainCameraTransform = Camera.main.transform;
        _currentZoom = 0;
        MoveCamera();
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
        if (!isLocalPlayer) return;

        MoveCamera();
    }

    /// <summary>
    /// Called to set the camera position and rotation
    /// relative to player also used to set camera zoom
    /// </summary>
    private void MoveCamera()
    {
        var m = Input.GetAxis("Mouse ScrollWheel");

        // If there is mouse wheel movement...
        if (m != 0)
        {
            var cameraRef = _mainCameraTransform.GetComponent<Camera>();
            // Zoom in
            if (m > 0f)
            {
                if (_currentZoom > _MAXZOOM) return;
                cameraRef.fieldOfView -= 3;
                _currentZoom++;
            }
            // Zoom out
            else if (m < 0f)
            {
                if (_currentZoom < 0) return;
                cameraRef.fieldOfView += 3;
                _currentZoom--;
            }
        }

        _mainCameraTransform.position = transform.position;
        _mainCameraTransform.rotation = Quaternion.Euler(_cameraRotation);
        _mainCameraTransform.Translate(_cameraOffset);
        _mainCameraTransform.LookAt(transform);
    }

    /// <summary>
    /// Returns true if player is moving
    /// </summary>
    /// <returns></returns>
    public bool GetIsMoving()
    {
        return _playerMovementScript.GetIsMoving();
    }

    /// <summary>
    /// Returns trues if player is attacking
    /// </summary>
    /// <returns></returns>
    public bool GetIsAttacking()
    {
        return _playerAttackScript.GetIsAttacking();
    }
}