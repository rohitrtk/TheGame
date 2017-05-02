using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Basic player movement class, extends from AbstractPlayer_Movement,
/// also handles interaction with the world (Should probably make another script for that >.>)
/// </summary>
public sealed class Player_Movement : AbstractPlayer_Movement
{
    /// <summary>
    /// Called on script init
    /// </summary>
    protected override void Start ()
    {
        if (!isLocalPlayer) return;
        
        _navMeshAgent = GetComponent<NavMeshAgent>();

        // Set up relationship between player values and navmesh agent
        _playerSpeed = 10f;                                                     // Set the players speed
        _playerDeceleration = _playerSpeed++;                                   // Set the players deceleration to the players speed + 1
        _playerAcceleration = _playerDeceleration * 40;                         // Set the players acceleration to the players deceleration * 40
                                                                                // (Stops the navmesh from giving a "sliding" effect due to high deceleration)
        // Assign values to navmesh    
        _navMeshAgent.speed = _playerSpeed;                                     // Set the navmesh speed to the players speed
        _navMeshAgent.acceleration = _playerAcceleration;                       // Set the navmesh acceleration to the players acceleration
        _navMeshAgent.stoppingDistance = _playerStoppingDistance;               // Set the navmesh stopping distance to the desired stopping distance
    }
	
    /// <summary>
    /// Called once per frame
    /// </summary>
	protected override void Update ()
    {
        if (!isLocalPlayer) return;

        // If the navmesh has a path; set the navmesh acceleration to the players deceleration value else
        // set the namesh acceleration to the players acceleration value
        if (_navMeshAgent.hasPath)
        {
            _isMoving = true;
            _navMeshAgent.acceleration =
                (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance) ? _playerDeceleration : _playerAcceleration;
        }
        else _isMoving = false;
    }

    /// <summary>
    /// Attempts to move player to the mouse position
    /// </summary>
    /// <param name="rayInfo"></param>
    public override void Move(RaycastHit rayInfo)
    {
        _navMeshAgent.destination = rayInfo.point;                 // Set the destination of the navmesh to this point and move to it
        if (Mathf.Abs(_navMeshAgent.remainingDistance) <= 1f)      // Prevents the movement animation from playing in the same spot
        {
            _navMeshAgent.stoppingDistance = 0f;
        }
    }
}