using UnityEngine;
using UnityEngine.Networking;

public class Player_Control : NetworkBehaviour 
{
    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private Vector3 _cameraOffset;

    private AbstractPlayer_Movement _playerMovementScript;
    private AbstractPlayer_Attack _playerAttackScript;

    private Vector3 _cameraRotation = new Vector3(60f, -45f, 0f);

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
        if (!isLocalPlayer) return;

        _playerMovementScript = GetComponent<AbstractPlayer_Movement>();
        _playerAttackScript = GetComponent<AbstractPlayer_Attack>();

        _cameraOffset = new Vector3(0f, 20f, -10f);

        _mainCameraTransform = Camera.main.transform;
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
    /// Called to set the camera position and rotation relative to player
    /// </summary>
    private void MoveCamera()
    {
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