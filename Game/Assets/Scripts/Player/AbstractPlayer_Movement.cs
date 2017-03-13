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

    // Attack Component
    protected Player_Attack _playerAttack;

    // Nav Mesh Speed
    protected float _playerSpeed;

    // Nav Mesh acceleration
    protected float _playerAcceleration;

    // Nav Mesh deceleration
    protected float _playerDeceleration;

    // Nav Mesh stopping distance
    protected const float _PLAYERSTOPPINGDISTANCE = 1f;

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
    /// Called to check for interactions with the game world
    /// </summary>
    protected abstract void Interact();

    /// <summary>
    /// Called to rotate towards a target
    /// </summary>
    /// <param name="t"></param>
    protected virtual void RotateToTarget(Transform t)
    {
        _navMeshAgent.destination = t.position;
        _navMeshAgent.stoppingDistance = Vector3.Distance(transform.position, _navMeshAgent.destination);

        _navMeshAgent.destination = transform.position;
        _navMeshAgent.stoppingDistance = 1f;
    }

    /// <summary>
    /// Returns the boolean for if the player is moving
    /// </summary>
    /// <returns></returns>
    public virtual bool GetIsMoving()
    {
        //if (!isLocalPlayer) return false;

        return _isMoving;
    }

    /// <summary>
    /// Returns the boolean for if the player is attacking
    /// </summary>
    /// <returns></returns>
    public virtual bool GetIsAttacking()
    {
        //if (!isLocalPlayer) return false;

        return _playerAttack.GetIsAttacking();
    }
}