using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Abstract class for player movement
/// </summary>
public abstract class AbstractPlayer_Movement : MonoBehaviour
{
    // Navmesh Agent used for pathing
    protected NavMeshAgent _navMeshAgent;
    
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