using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

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
        _playerAttack = GetComponent<Player_Attack>();

        // Set up relationship between player values and navmesh agent
        _playerSpeed = 10f;                                                     // Set the players speed
        _playerDeceleration = _playerSpeed++;                                   // Set the players deceleration to the players speed + 1
        _playerAcceleration = _playerDeceleration * 40;                         // Set the players acceleration to the players deceleration * 40
                                                                                // (Stops the navmesh from giving a "sliding" effect due to high deceleration)
        // Assign values to navmesh    
        _navMeshAgent.speed = _playerSpeed;                                     // Set the navmesh speed to the players speed
        _navMeshAgent.acceleration = _playerAcceleration;                       // Set the navmesh acceleration to the players acceleration
        _navMeshAgent.stoppingDistance = _PLAYERSTOPPINGDISTANCE;               // Set the navmesh stopping distance to the desired stopping distance
    }
	
    /// <summary>
    /// Called once per frame
    /// </summary>
	protected override void Update ()
    {
        if (!isLocalPlayer) return;
        
        // Right mouse button down
        if (Input.GetMouseButtonDown(1) &&
            !EventSystem.current.IsPointerOverGameObject()) Interact();

        // If the navmesh has a path; set the navmesh acceleration to the players deceleration value else
        // set the namesh acceleration to the players acceleration value
        if (_navMeshAgent.hasPath)
        {
            _isMoving = true;
            _navMeshAgent.acceleration =
                (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance) ? _playerDeceleration : _playerAcceleration;
        }
        else
        {
            _isMoving = false;
        }
    }

    /// <summary>
    /// Called to interact with the world
    /// </summary>
    protected override void Interact()
    {
        if (!isLocalPlayer) return;

        // Create a ray from the current main camera to the mouse position on screen
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;

        if (Physics.Raycast(ray, out rayInfo, Mathf.Infinity))
        {
            GameObject rayObject = rayInfo.collider.gameObject;

            

            // Check what the player clicked on
            if (rayObject.tag == "Interactable")
            {
                print("Interact");
            }
            else if(rayObject.tag == "Destructable")
            {
                //RotateToTarget(rayObject.transform);

                if (_playerAttack.Cast("AUTO", rayObject, _navMeshAgent) == -1) return;
                else if (_playerAttack.Cast("AUTO", rayObject, _navMeshAgent) == 0) 

                
                _navMeshAgent.Stop();

                print("Auto Attack!");
            }
            else _navMeshAgent.destination = rayInfo.point;
        }
    }
}