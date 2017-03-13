using UnityEngine;

/// <summary>
/// This class handles the players animations; extends from abstract animation
/// </summary>
public class Player_Animation : AbstractPlayer_Animation
{
    /// <summary>
    /// Called when the object is created
    /// </summary>
    protected override void Start()
    {
        if (!isLocalPlayer) return;

        _parentMoveScript = GetComponent<AbstractPlayer_Movement>();                    // Gets reference to the parent move script

        _playerAnimator = GetComponent<Animator>();                                     // Gets the animator component
        _playerAnimator.SetInteger("battle", 1);                                        // Sets the state of the player to "battle"
                                                                                        // (So the animations can work)
    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    protected override void Update()
    {
        if (!isLocalPlayer) return;

        if (_parentMoveScript.GetIsAttacking()) _playerAnimator.SetInteger("moving", Random.Range(3, 5));     // If attacking
        else if (_parentMoveScript.GetIsMoving()) _playerAnimator.SetInteger("moving", 2);   // If moving
        else _playerAnimator.SetInteger("moving", 0);                                   // If not moving
    }
}
