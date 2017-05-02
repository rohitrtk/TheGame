using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Handles the initialization of the player on the network
/// </summary>
public sealed class Player_NetworkInit : NetworkBehaviour
{
    /// <summary>
    /// Called when script is inited
    /// </summary>
    private void Start()
    {
        if (!isLocalPlayer) return;

        GetComponent<AbstractPlayer_Movement>().enabled = true;         // Get the players movement script and enable it

        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    }
    
    /// <summary>
    /// Called once per frame
    /// </summary>
    private void Update()
    {
    }

    public override void PreStartClient()
    {
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    }
}