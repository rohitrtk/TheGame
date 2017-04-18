using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Abstract for player animations
/// </summary>
public abstract class AbstractPlayer_Animation : NetworkBehaviour
{
    protected Player_Control _parentMoveScript;             // Reference to the parents movement script
    protected Animator _playerAnimator;                     // Animator for the player

    // Use this for initialization
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();
}
