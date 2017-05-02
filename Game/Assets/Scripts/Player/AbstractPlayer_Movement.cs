using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

/// <summary>
/// Abstract class for player movement
/// </summary>
public abstract class AbstractPlayer_Movement : NetworkBehaviour
{
    // Navmesh Agent used for pathing
    protected NavMeshAgent _navMeshAgent;

    // Nav Mesh Speed
    protected float _playerSpeed;

    // Nav Mesh acceleration
    protected float _playerAcceleration;

    // Nav Mesh deceleration
    protected float _playerDeceleration;

    // Nav Mesh stopping distance
    protected float _playerStoppingDistance;

    // Is the character moving
    protected bool _isMoving;

    /// <summary>
    /// Called upon object creation
    /// </summary>
    protected abstract void Start();

    /// <summary>
    /// Called every frame
    /// </summary>
    protected abstract void Update();

    /// <summary>
    /// Attempts to move player to the mouse position
    /// </summary>
    /// <param name="rayInfo"></param>
    public abstract void Move(RaycastHit rayInfo);

    /// <summary>
    /// Returns the boolean for if the player is moving
    /// </summary>
    /// <returns></returns>
    public virtual bool GetIsMoving()
    { 
        return _isMoving;
    }
}