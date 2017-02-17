using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Syncs the players position across a network
/// </summary>
public sealed class Player_MovementNetworkSync : NetworkBehaviour
{
    [SerializeField] private Transform myTransform;     // This gameobjects transform
    [SerializeField] private float lerpRate = 18f;      // Rate to lerp at

    [SyncVar] private Vector3 syncPosition;             // Automatically gives network position
    [SyncVar] private Quaternion syncRotation;          // Automatically gives network rotation

    /// <summary>
    /// Called on object creation
    /// </summary>
	private void Start ()
    {	
	}
	
    /// <summary>
    /// Called once per frame
    /// </summary>
	private void Update ()
    {
        // Send position and rotation
        GivePosition();
        GiveRotation();

        // Update this gameobject on other clients
        LerpPosition();
        LerpRotation();
	}

    /// <summary>
    /// Lerps players character for other clients
    /// </summary>
    private void LerpPosition()
    {
        if (isLocalPlayer) return;

        myTransform.position = Vector3.Lerp(myTransform.position, syncPosition , Time.deltaTime * lerpRate);
    }

    /// <summary>
    /// Calls command that will give the server this gameobjects position
    /// which is then updated on the network which can be recived on all other
    /// running clients
    /// </summary>
    [ClientCallback]
    private void GivePosition()
    {
        if (!isLocalPlayer) return;
        CmdGivePosition(myTransform.position);
    }

    /// <summary>
    /// Lerps players rotation for other clients
    /// </summary>
    private void LerpRotation()
    {
        if (isLocalPlayer) return;

        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, syncRotation, Time.deltaTime * lerpRate);
    }

    /// <summary>
    /// Calls command that will give the server this gameobjects position
    /// which is then updated on the network which can be recived on all other
    /// running clients
    /// </summary>
    private void GiveRotation()
    {
        if (!isLocalPlayer) return;

        CmdGiveRotation(myTransform.rotation);
    }

    /// <summary>
    /// Client tells server this
    /// </summary>
    [Command] private void CmdGivePosition(Vector3 position)
    {
        syncPosition = position;
    }

    /// <summary>
    /// Client tells server this
    /// </summary>
    [Command] private void CmdGiveRotation(Quaternion rotation)
    {
        syncRotation = rotation;
    }
}
