using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Handles the initialization of the player on the network
/// </summary>
public class Player_NetworkInit : NetworkBehaviour {

    [SerializeField] private Camera _playerCamera;
    [SerializeField] private AudioListener _audioListener;

	void Start ()
    {
        if (!isLocalPlayer) return;

        GameObject.Find("Scene Camera").SetActive(false);
        GetComponent<AbstractPlayer_Movement>().enabled = true;
        //_playerCamera.enabled = true;
        //_audioListener.enabled = true;
	}
}