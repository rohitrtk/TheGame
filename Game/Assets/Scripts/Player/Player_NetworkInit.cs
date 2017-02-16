using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Handles the initialization of the player on the network
/// </summary>
public class Player_NetworkInit : NetworkBehaviour
{
    [SerializeField ] public CameraControl CameraControlPrefab; // Reference to the CameraControl prefab

    private CameraControl _playerCameraControl;                 // Camera control object to be instantiated for player

    /// <summary>
    /// Called when script is inited
    /// </summary>
    private void Start()
    {
        if (!isLocalPlayer) return;

        GameObject.Find("Scene Camera").SetActive(false);
        GetComponent<AbstractPlayer_Movement>().enabled = true;

        _playerCameraControl = Instantiate(CameraControlPrefab);
        _playerCameraControl.TargetTransform = gameObject.transform;
    }
    
    /// <summary>
    /// Called once per frame
    /// </summary>
    private void Update()
    {
        if (!isLocalPlayer) return;

        _playerCameraControl.TargetTransform = gameObject.transform;
    }
}