using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

/// <summary>
/// Manages all scripts and methods relevant to the player
/// </summary>
public class Player_Control : NetworkBehaviour 
{
    [SerializeField] private Transform _mainCameraTransform;        // Reference to the scenes main camera transformo
    [SerializeField] private Vector3 _cameraOffset;                 // The cameras offset so it isn't inside the player

    private AbstractPlayer_Movement _playerMovementScript;          // Player movement script
    private AbstractPlayer_Attack _playerAttackScript;              // Player attack script
    private Player_Health _playerHealthScript;                      // Player health script

    private Vector3 _cameraRotation;                                // Vector that stores the cameras rotation

    private NavMeshAgent _navMeshAgent;

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
        _playerHealthScript = GetComponent<Player_Health>();

        _cameraRotation = new Vector3(60f, -45f, 0f);

        _navMeshAgent = GetComponent<NavMeshAgent>();

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

        // Right mouse button down
        if (Input.GetMouseButtonDown(1) &&
            !EventSystem.current.IsPointerOverGameObject()) Interact();

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

    public void Interact()
    {
        if (!isLocalPlayer) return;

        // Create a ray from the current main camera to the mouse position on screen
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;

        if (Physics.Raycast(ray, out rayInfo, Mathf.Infinity))
        {
            GameObject rayObject = rayInfo.collider.gameObject;

            _navMeshAgent.stoppingDistance = 1f;                        // Reset stopping distance
            _navMeshAgent.isStopped = false;                            // Continue with navmesh pathing

            // Check what the player clicked on...
            if (rayObject.tag == "Interactable")
            {
                print("Interact");
                return;
            }
            else if(rayObject.tag == "Destructable")
            {
                if(Vector3.Distance(gameObject.transform.position, rayObject.transform.position)
                    <= _playerAttackScript.AutoAttackRange)
                {
                    _playerAttackScript.AutoAttack(rayObject);

                    print("destroy");
                    return;
                }
            }

            _playerMovementScript.Move(rayInfo);
            
        }
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