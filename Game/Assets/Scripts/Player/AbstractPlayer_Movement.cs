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
}