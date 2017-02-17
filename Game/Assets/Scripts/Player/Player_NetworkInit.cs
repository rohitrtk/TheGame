using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Handles the initialization of the player on the network
/// </summary>
public sealed class Player_NetworkInit : NetworkBehaviour
{
    [SerializeField] public CameraControl CameraControlPrefab;          // Reference to the CameraControl prefab

    private CameraControl _playerCameraControl;                         // Camera control object to be instantiated for player

    /// <summary>
    /// Called when script is inited
    /// </summary>
    private void Start()
    {
        if (!isLocalPlayer) return;

        GameObject.Find("Scene Camera").SetActive(false);               // Find the main scene camera and disable it
        GetComponent<AbstractPlayer_Movement>().enabled = true;         // Get the players movement script and enable it

        _playerCameraControl = Instantiate(CameraControlPrefab);        // Instantiate a new camera control prefab
        _playerCameraControl.TargetTransform = gameObject.transform;    // Set the initial target transform to this gameobjects transform
    }
    
    /// <summary>
    /// Called once per frame
    /// </summary>
    private void Update()
    {
        if (!isLocalPlayer) return;

        _playerCameraControl.TargetTransform = gameObject.transform;    // Set the cameras target transform to this gameobjects transform
    }
}