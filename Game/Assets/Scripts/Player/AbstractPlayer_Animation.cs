using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract for player animations
/// </summary>
public abstract class AbstractPlayer_Animation : MonoBehaviour
{
    protected AbstractPlayer_Movement _parentMoveScript;    // Reference to the parents movement script
    protected Animator _playerAnimator;                     // Animator for the player

    // Use this for initialization
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();
}
